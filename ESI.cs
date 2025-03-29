using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace EVE_Isk_per_Hour
{

    public static class ESIGlobals
    {
        public static string ESICharacterSkillsScope = "esi-skills.read_skills"; // only required scope to use IPH
    }

    public class ESI
    {
        private const string ESIAuthorizeURL = "https://login.eveonline.com/v2/oauth/authorize";
        private const string ESITokenURL = "https://login.eveonline.com/v2/oauth/token";
        private const string ESIURL = "https://esi.evetech.net/latest/";
        private const string ESIStatusURL = "https://esi.evetech.net/status.json?version=latest";
        private const string TranquilityDataSource = "?datasource=tranquility";

        private const string LocalHost = "127.0.0.1"; // All calls will redirect to local host.
        private const string LocalPort = "12500"; // Always use this port
        private const string EVEIPHClientID = "2737513b64854fa0a309e125419f8eff"; // IPH Client ID in EVE Developers

        private string AuthorizationToken; // Token returned by ESI on initial authorization - good for 5 minutes
        private string CodeVerifier; // For PKCE - generated code we send to ESI for access codes after sending the hashed version of this for authorization code

        public const string ESICharacterAssetScope = "esi-assets.read_assets";
        public const string ESICharacterResearchAgentsScope = "esi-characters.read_agents_research";
        public const string ESICharacterBlueprintsScope = "esi-characters.read_blueprints";
        public const string ESICharacterStandingsScope = "esi-characters.read_standings";
        public const string ESICharacterIndustryJobsScope = "esi-industry.read_character_jobs";
        public const string ESICharacterSkillsScope = "esi-skills.read_skill";

        public const string ESICorporationAssetScope = "esi-assets.read_corporation_assets";
        public const string ESICorporationBlueprintsScope = "esi-corporations.read_blueprints";
        public const string ESICorporationIndustryJobsScope = "esi-industry.read_corporation_jobs";
        public const string ESICorporationMembership = "esi-corporations.read_corporation_membership";

        public const string ESIUniverseStructuresScope = "esi-universe.read_structures";
        public const string ESIStructureMarketsScope = "esi-markets.structure_markets";

        // ' Rate limits
        // 'For your requests, this means you can send an occasional burst of 400 requests all at once. 
        // 'If you do, you'll hit the rate limit once you try to send your 401st request unless you wait.

        // 'Your bucket refills at a rate of 1 per 1/150th of a second. If you send 400 requests at once, 
        // 'you need to wait 2.67 seconds before you can send another 400 requests (1/150 * 400), if you 
        // 'only wait 1.33 seconds you can send another 200, and so on. Altrnatively, you can send a constant 150 requests every 1 second. 
        // Private Const ESIRatePerSecond As Integer = 150 ' max requests per second
        // Private Const ESIBurstSize As Integer = 400 ' max burst of requests, which need 2.46 seconds to refill before re-bursting
        private const int ESIMaximumConnections = 20;

        private Thread AuthThreadReference; // Reference in case we need to kill this
        private TcpListener myListener = new TcpListener(IPAddress.Parse(LocalHost), Conversions.ToInteger(LocalPort)); // Ref to the listener so we can stop it

        private int StructureCount; // for counting order updates

        public enum ESICallType
        {
            Basic = 0,
            Threaded = 1
        }

        // ESI implements the following scopes:

        // Character
        // esi-assets.read_assets.v1: Allows reading a list of assets that the character owns
        // esi-characters.read_agents_research.v1: Allows reading a character's research status with agents
        // esi-characters.read_blueprints.v1: Allows reading a character's blueprints
        // esi-characters.read_standings.v1: Allows reading a character's standings
        // esi-industry.read_character_jobs.v1: Allows reading a character's industry jobs
        // esi-skills.read_skills.v1: Allows reading of a character's currently known skills.

        // Corporation
        // esi-assets.read_corporation_assets.v1: Allows reading of a character's corporation's assets, if the character has roles to do so.
        // esi-corporations.read_blueprints.v1: Allows reading a corporation's blueprints
        // esi-industry.read_corporation_jobs.v1: Allows reading of a character's corporation's industry jobs, if the character has roles to do so.
        // 
        // esi-universe.read_structure.v1: Allows reading of all public structures in the universe
        // esi-markets.structure_markets.v1: Allows reading of markets for structures the character can use

        /// <summary>
    /// Initialize the class variables as needed
    /// </summary>
        public ESI()
        {
            AuthorizationToken = "";
            CodeVerifier = "";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        /// <summary>
    /// Opens a connection to EVE SSO server and gets an authorization token to get an access token
    /// </summary>
    /// <returns>Authorization Token</returns>
        private string GetAuthorizationToken()
        {

            try
            {
                var StartTime = DateTime.Now;

                // See if we are in an error limited state
                if (Public_Variables.ESIErrorHandler.ErrorLimitReached)
                {
                    // Need to wait until we are ready to continue
                    Thread.Sleep(Public_Variables.ESIErrorHandler.msErrorTimer);
                }

                AuthThreadReference = new Thread(() => GetAuthorizationfromWeb());
                AuthThreadReference.Start();

                // Reset this to make sure it only comes up if they hit the button
                Public_Variables.CancelESISSOLogin = false;

                // Now loop until thread is done, 60 seconds goes by, or cancel clicked
                do
                {
                    if (DateAndTime.DateDiff(DateInterval.Second, StartTime, DateTime.Now) > 60L)
                    {
                        Interaction.MsgBox("Request timed out. You must complete your login within 60 seconds.", Constants.vbInformation, Application.ProductName);
                        myListener.Stop();
                        AuthThreadReference.Abort();
                        return null;
                    }
                    else if (Public_Variables.CancelESISSOLogin)
                    {
                        Interaction.MsgBox("Request Canceled", Constants.vbInformation, Application.ProductName);
                        myListener.Stop();
                        AuthThreadReference.Abort();
                        return null;
                    }
                    else if (!AuthThreadReference.IsAlive)
                    {
                        break;
                    }
                    Application.DoEvents();
                }
                while (true);

                // Get the authtoken after it completed
                return AuthorizationToken;
            }

            catch (WebException ex)
            {

                Public_Variables.ESIErrorHandler.ProcessWebException(ex, ESIErrorProcessor.ESIErrorLocation.AuthToken, false, "");

                // Retry call
                if (Public_Variables.ESIErrorHandler.ErrorCode >= 500 & !Public_Variables.ESIErrorHandler.RetriedCall)
                {
                    Public_Variables.ESIErrorHandler.RetriedCall = true;
                    // Try this call again after waiting a second
                    Thread.Sleep(1000);
                    return GetAuthorizationToken();
                }
            }

            catch (Exception ex)
            {
                Public_Variables.ESIErrorHandler.ProcessException(ex, ESIErrorProcessor.ESIErrorLocation.AuthToken, false);
            }

            return "";

        }

        /// <summary>
    /// Opens the login for EVE SSO and returns the data stream from a successful log in
    /// </summary>
        private void GetAuthorizationfromWeb(string MyURL = "")
        {
            try
            {
                string URL = "";
                string ChallengeCode = "";
                string AuthStreamText = ""; // The return data from the web call
                                            // State is a random number for passing to ESI
                string InitState = DateTime.UtcNow.ToFileTime().ToString();

                // Set the challenge code for this call
                CodeVerifier = GetCodeVerifier();
                ChallengeCode = GetChallengeCode(CodeVerifier);

                // Build the authorization URL
                URL = ESIAuthorizeURL;
                URL += "?client_id=" + EVEIPHClientID;
                URL += "&redirect_uri=" + WebUtility.UrlEncode("http://" + LocalHost + ":" + LocalPort);
                URL += "&response_type=code";
                URL += "&scope=" + WebUtility.UrlEncode(Public_Variables.ESIScopesString);
                URL += "&state=" + InitState;
                URL += "&code_challenge=" + ChallengeCode;
                URL += "&code_challenge_method=S256";

                // Open the browser to get authorization from user
                Process.Start(URL);

                Socket mySocket = null;
                NetworkStream myStream = null;
                StreamReader myReader = null;
                StreamWriter myWriter = null;

                myListener.Start();

                mySocket = myListener.AcceptSocket(); // Wait for response
                myStream = new NetworkStream(mySocket);
                myReader = new StreamReader(myStream);
                myWriter = new StreamWriter(myStream);
                myWriter.AutoFlush = true;

                do
                {
                    // Get the response from the callback
                    AuthStreamText += myReader.ReadLine() + "|";

                    if (AuthStreamText.Contains("code") & AuthStreamText.Contains("state"))
                    {
                        break;
                    }
                }
                while (!myReader.EndOfStream);

                // Strip the code and state from the callback stream text
                AuthStreamText = AuthStreamText.Substring(Strings.InStr(AuthStreamText, "/"));
                int CodeStart = 6; // ?code=
                int CodeEnd = Strings.InStr(AuthStreamText, "&state=") - 1;
                int StateStart = CodeEnd + 7;
                int StateEnd = Strings.InStr(AuthStreamText, " ") - 1;
                // Parse the values - Check the state return first
                string ReturnState = AuthStreamText.Substring(StateStart, StateEnd - StateStart);

                if ((ReturnState ?? "") != (InitState ?? ""))
                {
                    myWriter.Write("The Authorization was unsuccessful. Please retry your request." + Constants.vbCrLf + Constants.vbCrLf + "You can close this window.");
                }
                else
                {
                    myWriter.Write("Authorization Successful!" + Constants.vbCrLf + Constants.vbCrLf + "You can close this window.");
                }

                // Now save the auth token to get access tokens
                AuthorizationToken = AuthStreamText.Substring(CodeStart, CodeEnd - CodeStart);

                myWriter.Close();
                myReader.Close();
                myStream.Close();
                mySocket.Close();
                myListener.Stop();

                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Application.DoEvents();
            }

        }

        /// <summary>
    /// Gets the Access Token data from the EVE server for authorization or refresh tokens.
    /// </summary>
    /// <param name="Token">An Authorization or Refresh Token</param>
    /// <param name="Refresh">If the token is Authorization or Refresh</param>
    /// <returns>Access Token Data object</returns>
        private ESITokenData GetAccessToken(string Token, bool Refresh, ref long TokenCharacterID, ref string TokenScopes)
        {

            if (Token == "No Token" | string.IsNullOrEmpty(Token))
            {
                return null;
            }

            var Output = new ESITokenData();
            bool Success = false;
            var WC = new WebClient();
            byte[] Response;
            string Data = "";

            WC.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            WC.Headers[HttpRequestHeader.Host] = "login.eveonline.com";
            WC.Proxy = Public_Variables.GetProxyData();

            var PostParameters = new NameValueCollection();
            if (!Refresh)
            {
                PostParameters.Add("grant_type", "authorization_code");
                PostParameters.Add("code", Token);
                PostParameters.Add("client_id", EVEIPHClientID);
                PostParameters.Add("code_verifier", CodeVerifier); // PKCE - Send the code verifier for ESI to hash to compare to what we sent earlier
            }
            else
            {
                PostParameters.Add("grant_type", "refresh_token");
                PostParameters.Add("refresh_token", Token);
                PostParameters.Add("client_id", EVEIPHClientID);
            }

            try
            {

                // See if we are in an error limited state
                if (Public_Variables.ESIErrorHandler.ErrorLimitReached)
                {
                    // Need to wait until we are ready to continue
                    Thread.Sleep(Public_Variables.ESIErrorHandler.msErrorTimer);
                }

                // Response in bytes
                Response = WC.UploadValues(ESITokenURL, "POST", PostParameters);

                // Convert byte data to string
                Data = Encoding.UTF8.GetString(Response);

                // Parse the data to the ESI Token Data Class to get the JWT Access Code
                Output = JsonConvert.DeserializeObject<ESITokenData>(Data);

                // Split the authorization token into the header + payload + signature
                string[] JWTAccessTokenParts = Output.access_token.Split('.');
                string Header = FormatJWTStringLength(JWTAccessTokenParts[0]);
                string Payload = FormatJWTStringLength(JWTAccessTokenParts[1]);
                string Signature = JWTAccessTokenParts[2];

                ESIJWTHeader TokenHeader;
                ESIJWTPayload TokenPayload;
                // Convert each part to a byte array, then encode it to a string for JSON parsing
                TokenHeader = JsonConvert.DeserializeObject<ESIJWTHeader>(Encoding.UTF8.GetString(Convert.FromBase64String(Header)));
                TokenPayload = JsonConvert.DeserializeObject<ESIJWTPayload>(Encoding.UTF8.GetString(Convert.FromBase64String(Payload)));

                // TODO - Valiate signature and token

                // Get the character ID from the JWT
                string[] SubjectInfo = TokenPayload.Subject.Split(':');
                TokenCharacterID = Conversions.ToLong(SubjectInfo[2]);

                // Return the scopes as well
                foreach (var entry in TokenPayload.Scopes)
                    TokenScopes += entry + " ";
                TokenScopes = Strings.Trim(TokenScopes);

                Success = true;
            }

            catch (WebException ex)
            {

                Public_Variables.ESIErrorHandler.ProcessWebException(ex, ESIErrorProcessor.ESIErrorLocation.AccessToken, false, "");

                // Retry call
                if (Public_Variables.ESIErrorHandler.ErrorCode >= 500 & !Public_Variables.ESIErrorHandler.RetriedCall)
                {
                    Public_Variables.ESIErrorHandler.RetriedCall = true;
                    // Try this call again after waiting a second
                    Thread.Sleep(1000);
                    Output = GetAccessToken(Token, Refresh, ref TokenCharacterID, ref TokenScopes);
                    if (!(Output == null))
                    {
                        Success = true;
                    }
                }
            }

            catch (Exception ex)
            {
                Public_Variables.ESIErrorHandler.ProcessException(ex, ESIErrorProcessor.ESIErrorLocation.AccessToken, false);
            }

            if (Success)
            {
                return Output;
            }
            else
            {
                return null;
            }

        }
        private static string Base64UrlEncode(string input)
        {
            // Dim output = Convert.ToBase64String(input)
            string output = input;
            output = output.Split('=')[0];
            output = output.Replace('+', '-');
            output = output.Replace('/', '_');
            return output;
        }
        public class ESIJWTHeader
        {
            [JsonProperty("alg")]
            public string Algorithm;
            [JsonProperty("kid")]
            public string KeyID;
            [JsonProperty("typ")]
            public string TokenType;
        }
        public class ESIJWTPayload
        {
            [JsonProperty("scp")]
            public List<string> Scopes;
            [JsonProperty("jti")]
            public string JWTID;
            [JsonProperty("kid")]
            public string KeyID;
            [JsonProperty("sub")]
            public string Subject;
            [JsonProperty("azp")]
            public string AuthParty; // EVEIPH ClientID
            [JsonProperty("tenant")]
            public string Tenant;
            [JsonProperty("tier")]
            public string Tier;
            [JsonProperty("region")]
            public string DataRegion;
            [JsonProperty("aud")]
            public List<string> Audience;
            [JsonProperty("name")]
            public string Name;
            [JsonProperty("owner")]
            public string Owner;
            [JsonProperty("exp")]
            public long ExpirationTime; // Unix time stamp
            [JsonProperty("iat")]
            public long IssuedAt; // Unix time stamp
            [JsonProperty("iss")]
            public string Issuer; // Who created and signed token
        }

        // Adds spacers (=) to the JWT string portion to be converted to Base 64
        private string FormatJWTStringLength(string JWTStringPortion)
        {
            int StrLen = Strings.Len(JWTStringPortion);
            string CorrectedString = JWTStringPortion;

            // Add spacers until mod 4 returns 0
            while (StrLen % 4 != 0)
            {
                CorrectedString += "=";
                StrLen += 1;
            }

            return CorrectedString;

        }

        /// <summary>
    /// Queries the server for public data for the URL sent. If not found, returns nothing
    /// </summary>
    /// <param name="URL">Full public data URL as a string</param>
    /// <returns>Byte Array of response or nothing if call fails</returns>
        private string GetPublicData(string URL, ref DateTime CacheDate, string BodyData = "")
        {
            string Response = "";
            var WC = new WebClient();
            var myWebHeaderCollection = new WebHeaderCollection();
            string Expires = null;
            int Pages = default;
            int ESIErrorLimitRemain = -1;
            int ESIErrorLimitReset = -1;

            try
            {

                // See if we are in an error limited state
                if (Public_Variables.ESIErrorHandler.ErrorLimitReached)
                {
                    // Need to wait until we are ready to continue
                    Thread.Sleep(Public_Variables.ESIErrorHandler.msErrorTimer);
                }

                WC.Proxy = Public_Variables.GetProxyData();

                if (!string.IsNullOrEmpty(BodyData))
                {
                    Response = Encoding.UTF8.GetString(WC.UploadData(URL, Encoding.UTF8.GetBytes(BodyData)));
                }
                else
                {
                    Response = WC.DownloadString(URL);
                }

                // Get the expiration date for the cache date
                myWebHeaderCollection = WC.ResponseHeaders;
                Expires = myWebHeaderCollection["Expires"];
                Pages = Conversions.ToInteger(myWebHeaderCollection["X-Pages"]);
                ESIErrorLimitRemain = Conversions.ToInteger(myWebHeaderCollection["X-ESI-Error-Limit-Remain"]);
                ESIErrorLimitReset = Conversions.ToInteger(myWebHeaderCollection["X-ESI-Error-Limit-Reset"]);

                if (!(Expires == null))
                {
                    CacheDate = Conversions.ToDate(Expires.Replace("GMT", "").Substring(Strings.InStr(Expires, ",") + 1)); // Expiration date is in GMT
                }
                else
                {
                    CacheDate = Public_Variables.NoExpiry;
                }

                if (!(Pages == null))
                {
                    if (Pages > 1)
                    {
                        string TempResponse = "";
                        for (int i = 2, loopTo = Pages; i <= loopTo; i++)
                        {
                            TempResponse = WC.DownloadString(URL + "&page=" + i.ToString());
                            // Combine with the original response - strip the end and leading brackets
                            Response = Response.Substring(0, Strings.Len(Response) - 1) + "," + TempResponse.Substring(1);
                        }
                    }
                }

                return Response;
            }

            catch (WebException ex)
            {

                Public_Variables.ESIErrorHandler.ProcessWebException(ex, ESIErrorProcessor.ESIErrorLocation.PublicData, SettingsVariables.UserApplicationSettings.SupressESIStatusMessages, URL);

                // Retry call
                if (Public_Variables.ESIErrorHandler.ErrorCode >= 500 & !Public_Variables.ESIErrorHandler.RetriedCall)
                {
                    Public_Variables.ESIErrorHandler.RetriedCall = true;
                    // Try this call again after waiting a second
                    Thread.Sleep(1000);
                    return GetPublicData(URL, ref CacheDate, BodyData);
                }
            }

            catch (Exception ex)
            {
                Public_Variables.ESIErrorHandler.ProcessException(ex, ESIErrorProcessor.ESIErrorLocation.PublicData, SettingsVariables.UserApplicationSettings.SupressESIStatusMessages);
            }

            if (!(Response == null))
            {
                if (!string.IsNullOrEmpty(Response))
                {
                    return Response;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        /// <summary>
    /// Queries the server for private, authorized data for data sent. Function will check the 
    /// authorization token and update the sent variable and DB data if expired.
    /// </summary>
    /// <returns>Returns data response as a string</returns>
        private string GetPrivateAuthorizedData(string URL, ESITokenData TokenData, DateTime TokenExpiration, ref DateTime CacheDate, long CharacterID, bool SupressErrorMsgs = false, bool SinglePage = false)
        {
            var WC = new WebClient();
            string Response = "";
            DateTime TokenExpireDate;

            try
            {
                // See if we update the token data first
                if (TokenExpiration <= DateTime.UtcNow)
                {

                    // Update the token
                    long argTokenCharacterID = default;
                    string argTokenScopes = null;
                    TokenData = GetAccessToken(TokenData.refresh_token, true, ref argTokenCharacterID, ref argTokenScopes);

                    if (TokenData == null)
                    {
                        return null;
                    }

                    // Update the token data in the DB for this character
                    string SQL = "";
                    // Update data - only stuff that could (reasonably) change
                    SQL = "UPDATE ESI_CHARACTER_DATA SET ACCESS_TOKEN = '{0}', ACCESS_TOKEN_EXPIRE_DATE_TIME = '{1}', ";
                    SQL += "TOKEN_TYPE = '{2}', REFRESH_TOKEN = '{3}' WHERE CHARACTER_ID = {4}";

                    TokenExpireDate = DateAndTime.DateAdd(DateInterval.Second, TokenData.expires_in, DateTime.UtcNow);
                    SQL = string.Format(SQL, Public_Variables.FormatDBString(TokenData.access_token), Strings.Format(TokenExpireDate, Public_Variables.SQLiteDateFormat), Public_Variables.FormatDBString(TokenData.token_type), Public_Variables.FormatDBString(TokenData.refresh_token), CharacterID);

                    // If we are in a transaction, we want to commit this so it's up to date, so close and reopen
                    if (Public_Variables.EVEDB.TransactionActive())
                    {
                        Public_Variables.EVEDB.CommitSQLiteTransaction();
                        Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                        Public_Variables.EVEDB.BeginSQLiteTransaction();
                    }
                    else
                    {
                        Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                    }

                    // Now update the copy used in IPH so we don't re-query
                    Public_Variables.SelectedCharacter.CharacterTokenData.AccessToken = TokenData.access_token;
                    Public_Variables.SelectedCharacter.CharacterTokenData.RefreshToken = TokenData.refresh_token;
                    Public_Variables.SelectedCharacter.CharacterTokenData.TokenExpiration = TokenExpireDate;

                }

                // See if we are in an error limited state
                if (Public_Variables.ESIErrorHandler.ErrorLimitReached)
                {
                    // Need to wait until we are ready to continue
                    Thread.Sleep(Public_Variables.ESIErrorHandler.msErrorTimer);
                }

                string Auth_header = $"Bearer {TokenData.access_token}";

                WC.Proxy = Public_Variables.GetProxyData();
                WC.Headers[HttpRequestHeader.Authorization] = Auth_header;

                Response = WC.DownloadString(URL);

                // Get the expiration date for the cache date
                var myWebHeaderCollection = WC.ResponseHeaders;
                string Expires = myWebHeaderCollection["Expires"];
                int Pages = Conversions.ToInteger(myWebHeaderCollection["X-Pages"]);

                if (!(Expires == null))
                {
                    CacheDate = Conversions.ToDate(Expires.Replace("GMT", "").Substring(Strings.InStr(Expires, ",") + 1)); // Expiration date is in GMT
                }
                else
                {
                    CacheDate = Public_Variables.NoExpiry;
                }

                if (!(Pages == null))
                {
                    if (Pages > 1)
                    {
                        string TempResponse = "";
                        for (int i = 2, loopTo = Pages; i <= loopTo; i++)
                        {
                            TempResponse = WC.DownloadString(URL + "&page=" + i.ToString());
                            // Combine with the original response - strip the end and leading brackets
                            Response = Response.Substring(0, Strings.Len(Response) - 1) + "," + TempResponse.Substring(1);
                            if (SinglePage)
                            {
                                break;
                            }
                        }
                    }
                }

                return Response;
            }

            catch (WebException ex)
            {

                Public_Variables.ESIErrorHandler.ProcessWebException(ex, ESIErrorProcessor.ESIErrorLocation.PrivateAuthData, SupressErrorMsgs, URL);

                // Retry call
                if (Public_Variables.ESIErrorHandler.ErrorCode >= 500 & !Public_Variables.ESIErrorHandler.RetriedCall)
                {
                    Public_Variables.ESIErrorHandler.RetriedCall = true;
                    // Try this call again after waiting a second
                    Thread.Sleep(1000);
                    return GetPrivateAuthorizedData(URL, TokenData, TokenExpiration, ref CacheDate, CharacterID, SupressErrorMsgs);
                }
            }

            catch (Exception ex)
            {
                Public_Variables.ESIErrorHandler.ProcessException(ex, ESIErrorProcessor.ESIErrorLocation.PrivateAuthData, SupressErrorMsgs);
            }

            if (!string.IsNullOrEmpty(Response))
            {
                return Response;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
    /// Formats a SavedTokenData object to ESITokenData
    /// </summary>
    /// <param name="TokenData">SavedTokenData object</param>
    /// <returns>the ESITokenData object</returns>
        private ESITokenData FormatTokenData(SavedTokenData TokenData)
        {
            var TempTokenData = new ESITokenData();

            TempTokenData.access_token = TokenData.AccessToken;
            TempTokenData.refresh_token = TokenData.RefreshToken;
            TempTokenData.token_type = TokenData.TokenType;

            return TempTokenData;

        }

        /// <summary>
    /// Formats string dates returned from the ESI server into a date object
    /// </summary>
    /// <param name="OriginalDate">ESI date value as a string</param>
    /// <returns>Date object of the sent date as a string</returns>
        public DateTime FormatESIDate(string OriginalDate)
        {
            if (!(OriginalDate == null))
            {
                return Conversions.ToDate(OriginalDate.Replace("T", " ").Replace("Z", ""));
            }
            else
            {
                return Public_Variables.NoDate;
            }
        }

        #region Load Character Data

        /// <summary>
    /// Gets verification and public data about the character returned from logging into the EVE SSO and authorizing 
    /// access for a new character first logging in. If the character has already been loaded, then update the data.
    /// </summary>
    /// <returns>Returns boolean if the function was successful in setting character data.</returns>
        public bool SetCharacterData(bool AccountRefresh, [Optional] ref SavedTokenData CharacterTokenData, [Optional, DefaultParameterValue("")] string ManualAuthToken, [Optional, DefaultParameterValue(false)] bool IgnoreCacheDate, [Optional, DefaultParameterValue(false)] bool SupressMessages, [Optional, DefaultParameterValue(-1)] ref long CorporationID)
        {
            ESITokenData TokenData;
            var CharacterData = new ESICharacterPublicData();
            long CharacterID;
            string Scopes = "";
            var CB = new CacheBox();
            var CacheDate = default(DateTime);

            if (!(CharacterTokenData == null))
            {
                CharacterID = CharacterTokenData.CharacterID;
            }
            else
            {
                CharacterID = 0L;
            }

            try
            {
                if (CB.DataUpdateable(CacheDateType.PublicCharacterData, CharacterID) | IgnoreCacheDate)
                {
                    if (CharacterID == 0L)
                    {
                        // We need to get the token data from the authorization
                        if (!string.IsNullOrEmpty(ManualAuthToken))
                        {
                            TokenData = GetAccessToken(ManualAuthToken, false, ref CharacterID, ref Scopes);
                        }
                        else
                        {
                            TokenData = GetAccessToken(GetAuthorizationToken(), false, ref CharacterID, ref Scopes);
                        }

                        CharacterTokenData = new SavedTokenData();
                    }
                    else
                    {
                        // We need to refresh the token data
                        TokenData = GetAccessToken(CharacterTokenData.RefreshToken, true, ref CharacterID, ref Scopes);
                    }

                    if (TokenData == null)
                    {
                        // They tried to refresh from account data, so open the web auth if it's an invalid token
                        if (AccountRefresh)
                        {
                            // First, reset the scope list based on what they have now
                            Public_Variables.ESIScopesString = CharacterTokenData.Scopes;
                            TokenData = GetAccessToken(GetAuthorizationToken(), false, ref CharacterID, ref Scopes);
                            // Now that we have the token data, make sure they selected the same character as we wanted to update and didn't select a different one
                            if (CharacterID != CharacterTokenData.CharacterID)
                            {
                                Interaction.MsgBox("You must select the same character on the Character Select webpage as the one you select in IPH. Please try again.", Constants.vbExclamation, Application.ProductName);
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }

                    // Update the local copy with the new information
                    CharacterTokenData.AccessToken = TokenData.access_token;
                    CharacterTokenData.RefreshToken = TokenData.refresh_token;
                    CharacterTokenData.TokenType = TokenData.token_type;
                    CharacterTokenData.CharacterID = CharacterID;
                    CharacterTokenData.Scopes = Scopes;

                    // Set the expiration date to pass
                    CharacterTokenData.TokenExpiration = DateAndTime.DateAdd(DateInterval.Second, TokenData.expires_in, DateTime.UtcNow);

                    CharacterData = GetCharacterPublicData(CharacterTokenData.CharacterID, ref CacheDate);
                    if (CharacterData == null)
                    {
                        return false;
                    }

                    // Save the corporationID for reference
                    CorporationID = CharacterData.corporation_id;

                    // Save it in the table if not there, or update it if they selected the character again
                    SQLiteDataReader rsCheck;
                    string SQL;

                    SQL = "SELECT * FROM ESI_CHARACTER_DATA WHERE CHARACTER_ID = " + CharacterTokenData.CharacterID.ToString();

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    rsCheck = Public_Variables.DBCommand.ExecuteReader();

                    if (rsCheck.HasRows)
                    {
                        // Update data - only stuff that could (reasonably) change
                        SQL = "UPDATE ESI_CHARACTER_DATA SET CORPORATION_ID = {0}, DESCRIPTION = '{1}', SCOPES = '{2}', ACCESS_TOKEN = '{3}',";
                        SQL += "ACCESS_TOKEN_EXPIRE_DATE_TIME = '{4}', TOKEN_TYPE = '{5}', REFRESH_TOKEN = '{6}' ";
                        SQL += "WHERE CHARACTER_ID = {7}";

                        SQL = string.Format(SQL, CharacterData.corporation_id, Public_Variables.FormatDBString(Public_Variables.FormatNullString(CharacterData.description)), Public_Variables.FormatDBString(CharacterTokenData.Scopes), Public_Variables.FormatDBString(CharacterTokenData.AccessToken), Strings.Format(CharacterTokenData.TokenExpiration, Public_Variables.SQLiteDateFormat), Public_Variables.FormatDBString(CharacterTokenData.TokenType), Public_Variables.FormatDBString(CharacterTokenData.RefreshToken), CharacterTokenData.CharacterID);
                    }
                    else
                    {
                        // Insert new data
                        SQL = "INSERT INTO ESI_CHARACTER_DATA (CHARACTER_ID, CHARACTER_NAME, CORPORATION_ID, BIRTHDAY, GENDER, RACE_ID, ";
                        SQL += "BLOODLINE_ID, ANCESTRY_ID, DESCRIPTION, ACCESS_TOKEN, ACCESS_TOKEN_EXPIRE_DATE_TIME, TOKEN_TYPE, REFRESH_TOKEN, ";
                        SQL += "SCOPES, OVERRIDE_SKILLS, IS_DEFAULT)";
                        SQL += "VALUES ({0},'{1}',{2},'{3}','{4}',{5},{6},{7},'{8}','{9}','{10}','{11}','{12}','{13}',{14},{15})";
                        SQL = string.Format(SQL, CharacterTokenData.CharacterID, Public_Variables.FormatDBString(CharacterData.name), CharacterData.corporation_id, Strings.Format(Conversions.ToDate(CharacterData.birthday.Replace("T", " ")), Public_Variables.SQLiteDateFormat), Public_Variables.FormatDBString(CharacterData.gender), CharacterData.race_id, CharacterData.bloodline_id, Public_Variables.FormatNullInteger(CharacterData.ancestry_id), Public_Variables.FormatDBString(Public_Variables.FormatNullString(CharacterData.description)), Public_Variables.FormatDBString(CharacterTokenData.AccessToken), Strings.Format(CharacterTokenData.TokenExpiration, Public_Variables.SQLiteDateFormat), Public_Variables.FormatDBString(CharacterTokenData.TokenType), Public_Variables.FormatDBString(CharacterTokenData.RefreshToken), Public_Variables.FormatDBString(CharacterTokenData.Scopes), 0, 0); // Don't set default yet or override skills
                    }

                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                    rsCheck.Close();

                    // Update public cachedate for character now that we have a record
                    CB.UpdateCacheDate(CacheDateType.PublicCharacterData, CacheDate, CharacterTokenData.CharacterID);

                    // While we are here, load the public information of the corporation too
                    SetCorporationData(CharacterData.corporation_id, ref CacheDate);

                    // Update after we update/insert the record
                    CB.UpdateCacheDate(CacheDateType.PublicCorporationData, CacheDate, CharacterData.corporation_id);

                    if (CharacterID == 0L & !SupressMessages)
                    {
                        Interaction.MsgBox("Character successfully added to IPH", Constants.vbInformation, Application.ProductName);
                    }

                    return true;
                }

                else
                {
                    // Just didn't need to update yet
                    return true;
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("Unable to set character data data through ESI: " + ex.Message, Constants.vbInformation, Application.ProductName);
            }

            return false;

        }

        /// <summary>
    /// Retrieves the public data about the character ID sent
    /// </summary>
    /// <param name="CharacterID">CharacterID you want public data for</param>
    /// <returns>Returns data in the ESICharacterPublicData JSON property class</returns>
        public ESICharacterPublicData GetCharacterPublicData(long CharacterID, ref DateTime DataCacheDate)
        {
            ESICharacterPublicData CharacterData;
            string PublicData;

            PublicData = GetPublicData(ESIURL + "characters/" + CharacterID.ToString() + "/" + TranquilityDataSource, ref DataCacheDate);

            if (!(PublicData == null))
            {
                CharacterData = JsonConvert.DeserializeObject<ESICharacterPublicData>(PublicData);
                return CharacterData;
            }
            else
            {
                return null;
            }

        }

        #endregion

        #region Auth Processing

        public EVESkillList GetCharacterSkills(long CharacterID, SavedTokenData TokenData, ref DateTime SkillsCacheDate)
        {
            var SkillData = new ESICharacterSkillsBase();
            string ReturnData;
            var ReturnSkills = new EVESkillList(SettingsVariables.UserApplicationSettings.UseActiveSkillLevels);
            var TempSkill = new EVESkill();

            ReturnData = GetPrivateAuthorizedData(ESIURL + "characters/" + CharacterID.ToString() + "/skills/" + TranquilityDataSource, FormatTokenData(TokenData), TokenData.TokenExpiration, ref SkillsCacheDate, CharacterID);

            if (!(ReturnData == null))
            {
                SkillData = JsonConvert.DeserializeObject<ESICharacterSkillsBase>(ReturnData);

                foreach (var entry in SkillData.skills)
                {
                    TempSkill = new EVESkill();
                    TempSkill.TypeID = entry.skill_id;
                    TempSkill.TrainedLevel = entry.trained_skill_level;
                    TempSkill.ActiveLevel = entry.active_skill_level;
                    TempSkill.SkillPoints = entry.skillpoints_in_skill;

                    ReturnSkills.InsertSkill(TempSkill, true);
                }

                return ReturnSkills;
            }
            else
            {
                return null;
            }

        }

        public EVENPCStandings GetCharacterStandings(long CharacterID, SavedTokenData TokenData, ref DateTime StandingsCacheDate)
        {
            var TempStandingsList = new EVENPCStandings();
            List<ESICharacterStandingsData> StandingsData;
            string ReturnData = "";
            string StandingType = "";

            ReturnData = GetPrivateAuthorizedData(ESIURL + "characters/" + CharacterID.ToString() + "/standings/" + TranquilityDataSource, FormatTokenData(TokenData), TokenData.TokenExpiration, ref StandingsCacheDate, CharacterID);

            if (!(ReturnData == null))
            {
                StandingsData = JsonConvert.DeserializeObject<List<ESICharacterStandingsData>>(ReturnData);

                foreach (var entry in StandingsData)
                {
                    switch (entry.from_type ?? "")
                    {
                        case "agents":
                            {
                                StandingType = "Agent";
                                break;
                            }
                        case "faction":
                            {
                                StandingType = "Faction";
                                break;
                            }
                        case "npc_corp":
                            {
                                StandingType = "Corporation";
                                break;
                            }
                    }
                    TempStandingsList.InsertStanding(entry.from_id, StandingType, "", entry.standing);
                }

                return TempStandingsList;
            }
            else
            {
                return null;
            }

        }

        public List<ESIResearchAgent> GetCurrentResearchAgents(long CharacterID, SavedTokenData TokenData, ref DateTime AgentsCacheDate)
        {
            string ReturnData;

            ReturnData = GetPrivateAuthorizedData(ESIURL + "characters/" + CharacterID.ToString() + "/agents_research/" + TranquilityDataSource, FormatTokenData(TokenData), TokenData.TokenExpiration, ref AgentsCacheDate, CharacterID);

            if (!(ReturnData == null))
            {
                return JsonConvert.DeserializeObject<List<ESIResearchAgent>>(ReturnData);
            }
            else
            {
                return null;
            }

        }

        public List<EVEBlueprint> GetBlueprints(long ID, SavedTokenData TokenData, Public_Variables.ScanType ScanType, ref DateTime BPCacheDate)
        {
            var ReturnedBPs = new List<EVEBlueprint>();
            EVEBlueprint TempBlueprint;
            var RawBPData = new List<ESIBlueprint>();
            string ReturnData = "";
            SQLiteDataReader rsLookup;

            // Set up query string
            if (ScanType == Public_Variables.ScanType.Personal)
            {
                ReturnData = GetPrivateAuthorizedData(ESIURL + "characters/" + ID.ToString() + "/blueprints/" + TranquilityDataSource, FormatTokenData(TokenData), TokenData.TokenExpiration, ref BPCacheDate, ID);
            }
            else // Corp
            {
                ReturnData = GetPrivateAuthorizedData(ESIURL + "corporations/" + ID.ToString() + "/blueprints/" + TranquilityDataSource, FormatTokenData(TokenData), TokenData.TokenExpiration, ref BPCacheDate, ID);
            }

            if (!(ReturnData == null))
            {
                RawBPData = JsonConvert.DeserializeObject<List<ESIBlueprint>>(ReturnData);

                // Process the return data
                foreach (var BP in RawBPData)
                {
                    TempBlueprint.ItemID = BP.item_id;
                    TempBlueprint.TypeID = BP.type_id;
                    // Get the typeName for this bp
                    Public_Variables.DBCommand = new SQLiteCommand("SELECT typeName FROM INVENTORY_TYPES WHERE typeID = " + BP.type_id.ToString(), Public_Variables.EVEDB.DBREf());
                    rsLookup = Public_Variables.DBCommand.ExecuteReader();
                    if (rsLookup.Read())
                    {
                        TempBlueprint.TypeName = rsLookup.GetString(0);
                    }
                    else
                    {
                        TempBlueprint.TypeName = Public_Variables.Unknown;
                    }
                    rsLookup.Close();

                    TempBlueprint.LocationID = BP.location_id;
                    // Get the flag id for this location
                    Public_Variables.DBCommand = new SQLiteCommand("SELECT flagID FROM INVENTORY_FLAGS WHERE flagName = '" + BP.location_flag + "'", Public_Variables.EVEDB.DBREf());
                    rsLookup = Public_Variables.DBCommand.ExecuteReader();
                    if (rsLookup.Read())
                    {
                        TempBlueprint.FlagID = rsLookup.GetInt32(0);
                    }
                    else
                    {
                        TempBlueprint.FlagID = 0;
                    }
                    rsLookup.Close();

                    TempBlueprint.Quantity = BP.quantity;
                    TempBlueprint.MaterialEfficiency = BP.material_efficiency;
                    TempBlueprint.TimeEfficiency = BP.time_efficiency;
                    TempBlueprint.Runs = BP.runs;

                    // We determine the type of bp from quantity
                    if (TempBlueprint.Quantity == (int)Public_Variables.BPType.Original | TempBlueprint.Quantity > 0)
                    {
                        // BPO or stack of BPOs
                        TempBlueprint.BPType = Public_Variables.BPType.Original;
                    }
                    else if (TempBlueprint.Quantity == (int)Public_Variables.BPType.Copy)
                    {
                        // BPC
                        TempBlueprint.BPType = Public_Variables.BPType.Copy;
                    }
                    else
                    {
                        // Not sure what this is
                        TempBlueprint.BPType = 0;
                    }
                    TempBlueprint.Owned = false;
                    TempBlueprint.Scanned = true; // We just scanned it
                    TempBlueprint.Favorite = false;
                    TempBlueprint.AdditionalCosts = 0d;

                    ReturnedBPs.Add(TempBlueprint);
                }

                return ReturnedBPs;
            }
            else
            {
                return null;
            }

        }

        public List<ESIIndustryJob> GetIndustryJobs(long ID, SavedTokenData TokenData, Public_Variables.ScanType JobType, ref DateTime JobsCacheDate)
        {
            string ReturnData = "";
            string URLType = "";

            // Set up query string
            if (JobType == Public_Variables.ScanType.Personal)
            {
                URLType = "characters/";
            }
            else // Corp
            {
                URLType = "corporations/";
            }

            ReturnData = GetPrivateAuthorizedData(ESIURL + URLType + ID.ToString() + "/industry/jobs/" + TranquilityDataSource + "&include_completed=true", FormatTokenData(TokenData), TokenData.TokenExpiration, ref JobsCacheDate, ID);

            if (!(ReturnData == null))
            {
                return JsonConvert.DeserializeObject<List<ESIIndustryJob>>(ReturnData);
            }
            else
            {
                return null;
            }

        }

        public List<ESIAsset> GetAssets(long ID, SavedTokenData TokenData, Public_Variables.ScanType JobType, ref DateTime AssetsCacheDate)
        {
            string ReturnData = "";

            // Set up query string
            if (JobType == Public_Variables.ScanType.Personal)
            {
                ReturnData = GetPrivateAuthorizedData(ESIURL + "characters/" + ID.ToString() + "/assets/" + TranquilityDataSource, FormatTokenData(TokenData), TokenData.TokenExpiration, ref AssetsCacheDate, ID);
            }
            else // Corp
            {
                ReturnData = GetPrivateAuthorizedData(ESIURL + "corporations/" + ID.ToString() + "/assets/" + TranquilityDataSource, FormatTokenData(TokenData), TokenData.TokenExpiration, ref AssetsCacheDate, ID);
            }

            if (!(ReturnData == null))
            {
                return JsonConvert.DeserializeObject<List<ESIAsset>>(ReturnData);
            }
            else
            {
                return null;
            }

        }

        public struct AssetNamePairs
        {
            public double AssetID;
            public string AssetName;
        }

        // Public Function GetAssetNames(ByVal ItemIDs As List(Of Double), ByVal ID As Long, ByVal TokenData As SavedTokenData,
        // ByVal JobType As ScanType, ByRef AssetNamesCacheDate As Date) As List(Of ESICharacterAssetName)
        // Dim Output As New List(Of ESICharacterAssetName)
        // Dim TempOutput As New List(Of ESICharacterAssetName)
        // Dim Success As Boolean = False
        // Dim Data As String = ""
        // Dim Token As ESITokenData = FormatTokenData(TokenData)

        // Dim WC As New WebClient
        // Dim Address As String = ""
        // Dim PostParameters As New NameValueCollection
        // Dim IDList As String = ""

        // Try

        // '' See if we update the token data first
        // 'If TokenData.TokenExpiration <= DateTime.UtcNow Then

        // '    ' Update the token
        // '    Token = GetAccessToken(Token.refresh_token, True, Nothing, Nothing)

        // '    If IsNothing(TokenData) Then
        // '        Return Nothing
        // '    End If

        // '    ' Update the token data in the DB for this character/corporation
        // '    Dim SQL As String = ""
        // '    ' Update data - only stuff that could (reasonably) change
        // '    SQL = "UPDATE ESI_CHARACTER_DATA SET ACCESS_TOKEN = '{0}', ACCESS_TOKEN_EXPIRE_DATE_TIME = '{1}', "
        // '    SQL &= "TOKEN_TYPE = '{2}', REFRESH_TOKEN = '{3}' WHERE CHARACTER_ID = {4}"

        // '    With Token
        // '        TokenData.TokenExpiration = DateAdd(DateInterval.Second, .expires_in, DateTime.UtcNow)
        // '        SQL = String.Format(SQL, FormatDBString(.access_token),
        // '        Format(TokenData.TokenExpiration, SQLiteDateFormat),
        // '        FormatDBString(.token_type), FormatDBString(.refresh_token), ID)
        // '    End With

        // '    ' If we are in a transaction, we want to commit this so it's up to date, so close and reopen
        // '    If EVEDB.TransactionActive Then
        // '        EVEDB.CommitSQLiteTransaction()
        // '        EVEDB.ExecuteNonQuerySQL(SQL)
        // '        EVEDB.BeginSQLiteTransaction()
        // '    Else
        // '        EVEDB.ExecuteNonQuerySQL(SQL)
        // '    End If

        // '    ' Now update the copy used in IPH so we don't re-query
        // '    SelectedCharacter.CharacterTokenData.AccessToken = Token.access_token
        // '    SelectedCharacter.CharacterTokenData.RefreshToken = Token.refresh_token
        // '    SelectedCharacter.CharacterTokenData.TokenExpiration = TokenData.TokenExpiration

        // 'End If

        // ' See if we are in an error limited state
        // 'If ESIErrorHandler.ErrorLimitReached Then
        // '    ' Need to wait until we are ready to continue
        // '    Call Thread.Sleep(ESIErrorHandler.msErrorTimer)
        // 'End If

        // '' See if we are in an error limited state
        // 'If ESIErrorHandler.ErrorLimitReached Then
        // '    ' Need to wait until we are ready to continue
        // '    Call Thread.Sleep(ESIErrorHandler.msErrorTimer)
        // 'End If

        // If JobType = ScanType.Corporation Then
        // Address = ESIURL & "corporations/" & CStr(ID) & "/assets/names/" & TranquilityDataSource
        // Else
        // Address = ESIURL & "characters/" & CStr(ID) & "/assets/names/" & TranquilityDataSource
        // End If

        // WC.Headers(HttpRequestHeader.Authorization) = $"Bearer {Token.access_token}"
        // Dim counter As Integer = 0

        // For Each item In ItemIDs
        // IDList &= CStr(item) & ","
        // counter += 1

        // ' Run every 1000
        // If counter = 1000 Then
        // ' Post data and get response, and parse the data to the class
        // TempOutput = JsonConvert.DeserializeObject(Of List(Of ESICharacterAssetName))(WC.UploadString(Address, "POST", "[" & IDList.Substring(0, Len(IDList) - 1) & "]"))
        // Call Output.AddRange(TempOutput)
        // IDList = ""
        // counter = 0
        // End If
        // Next

        // ' Add the remainder of items
        // TempOutput = JsonConvert.DeserializeObject(Of List(Of ESICharacterAssetName))(WC.UploadString(Address, "POST", "[" & IDList.Substring(0, Len(IDList) - 1) & "]"))
        // Call Output.AddRange(TempOutput)

        // Success = True

        // Catch ex As WebException
        // Call ESIErrorHandler.ProcessWebException(ex, ESIErrorProcessor.ESIErrorLocation.AccessToken, False, "")
        // Catch ex As Exception
        // Call ESIErrorHandler.ProcessException(ex, ESIErrorProcessor.ESIErrorLocation.AccessToken, False)
        // End Try

        // If Success Then
        // Return Output
        // Else
        // Return Nothing
        // End If

        // End Function

        public List<ESICorporationRoles> GetCorporationRoles(long CharacterID, long CorporationID, SavedTokenData TokenData, ref DateTime RolesCacheDate)
        {
            string ReturnData;

            ReturnData = GetPrivateAuthorizedData(ESIURL + "corporations/" + CorporationID.ToString() + "/roles/" + TranquilityDataSource, FormatTokenData(TokenData), TokenData.TokenExpiration, ref RolesCacheDate, CharacterID);

            if (!(ReturnData == null))
            {
                return JsonConvert.DeserializeObject<List<ESICorporationRoles>>(ReturnData);
            }
            else
            {
                // No corp roles returned
                return null;
            }

        }

        public void SetCorporationData(long ID, ref DateTime DataCacheDate)
        {
            string ReturnData = "";
            string SQL = "";
            ESICorporation CorpData = null;

            // Set up query string
            if (ID != 0L)
            {
                ReturnData = GetPublicData(ESIURL + "corporations/" + ID.ToString() + TranquilityDataSource, ref DataCacheDate);
            }
            else
            {
                ReturnData = null;
            }

            if (!(ReturnData == null))
            {
                CorpData = JsonConvert.DeserializeObject<ESICorporation>(ReturnData);

                if (!(CorpData == null))
                {

                    // See if we insert or update
                    SQLiteDataReader rsCheck;
                    // Load up all the data for the corporation
                    SQL = "SELECT * FROM ESI_CORPORATION_DATA WHERE CORPORATION_ID = " + ID;

                    Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                    rsCheck = Public_Variables.DBCommand.ExecuteReader();

                    if (rsCheck.Read())
                    {
                        // Found a record, so update the data
                        SQL = "UPDATE ESI_CORPORATION_DATA SET ";
                        SQL += "CORPORATION_NAME = " + Public_Variables.BuildInsertFieldString(CorpData.name) + ",";
                        SQL += "TICKER = " + Public_Variables.BuildInsertFieldString(CorpData.ticker) + ",";
                        SQL += "MEMBER_COUNT = " + Public_Variables.BuildInsertFieldString(CorpData.member_count) + ",";
                        SQL += "FACTION_ID = " + Public_Variables.BuildInsertFieldString(CorpData.faction_id) + ",";
                        SQL += "ALLIANCE_ID = " + Public_Variables.BuildInsertFieldString(CorpData.alliance_id) + ",";
                        SQL += "CEO_ID = " + Public_Variables.BuildInsertFieldString(CorpData.ceo_id) + ",";
                        SQL += "CREATOR_ID = " + Public_Variables.BuildInsertFieldString(CorpData.creator_id) + ",";
                        SQL += "HOME_STATION_ID = " + Public_Variables.BuildInsertFieldString(CorpData.home_station_id) + ",";
                        SQL += "SHARES = " + Public_Variables.BuildInsertFieldString(CorpData.shares) + ",";
                        SQL += "TAX_RATE = " + Public_Variables.BuildInsertFieldString(CorpData.tax_rate) + ",";
                        SQL += "DESCRIPTION = " + Public_Variables.BuildInsertFieldString(CorpData.description) + ",";
                        SQL += "DATE_FOUNDED = " + Public_Variables.BuildInsertFieldString(CorpData.date_founded) + ",";
                        SQL += "URL = " + Public_Variables.BuildInsertFieldString(CorpData.date_founded) + " ";
                        SQL += "WHERE CORPORATION_ID = " + ID.ToString();
                    }
                    else
                    {
                        // New record
                        SQL = "INSERT INTO ESI_CORPORATION_DATA VALUES (";
                        SQL += Public_Variables.BuildInsertFieldString(ID) + ",";
                        SQL += Public_Variables.BuildInsertFieldString(CorpData.name) + ",";
                        SQL += Public_Variables.BuildInsertFieldString(CorpData.ticker) + ",";
                        SQL += Public_Variables.BuildInsertFieldString(CorpData.member_count) + ",";
                        SQL += Public_Variables.BuildInsertFieldString(CorpData.faction_id) + ",";
                        SQL += Public_Variables.BuildInsertFieldString(CorpData.alliance_id) + ",";
                        SQL += Public_Variables.BuildInsertFieldString(CorpData.ceo_id) + ",";
                        SQL += Public_Variables.BuildInsertFieldString(CorpData.creator_id) + ",";
                        SQL += Public_Variables.BuildInsertFieldString(CorpData.home_station_id) + ",";
                        SQL += Public_Variables.BuildInsertFieldString(CorpData.shares) + ",";
                        SQL += Public_Variables.BuildInsertFieldString(CorpData.tax_rate) + ",";
                        SQL += Public_Variables.BuildInsertFieldString(CorpData.description) + ",";
                        SQL += Public_Variables.BuildInsertFieldString(CorpData.date_founded) + ",";
                        SQL += Public_Variables.BuildInsertFieldString(CorpData.url) + ",";
                        SQL += "NULL,NULL,NULL,NULL,NULL)";

                    }

                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                    rsCheck.Close();

                }
            }

        }

        public ESIUniverseStructure GetStructureData(long ID, SavedTokenData TokenData, ref DateTime StructureCacheDate, bool SuppressErrors)
        {
            string ReturnData = "";

            // Set up query string - choose a suppress error message setting since this will probably have the most issues
            ReturnData = GetPrivateAuthorizedData(ESIURL + "universe/structures/" + ID.ToString() + "/" + TranquilityDataSource, FormatTokenData(TokenData), TokenData.TokenExpiration, ref StructureCacheDate, TokenData.CharacterID, SuppressErrors);

            if (!(ReturnData == null))
            {
                return JsonConvert.DeserializeObject<ESIUniverseStructure>(ReturnData);
            }
            else
            {
                return null;
            }

        }

        // Updates the DB with orders from structures for all items on the market in the structure for the system/region pair sent
        public bool UpdateStructureMarketOrders(List<Public_Variables.SystemRegion> PriceSystemRegions, SavedTokenData Tokendata, ref ToolStripProgressBar refPG)
        {
            string SQL;
            SQLiteDataReader rsCheck;
            var CacheDate = Public_Variables.NoDate;
            string PublicData = "";
            var Threads = new ThreadingArray();
            var StructureIDs = new List<long>();
            string RegionList = "";

            if (PriceSystemRegions.Count == 0)
            {
                return true;
            }

            // Build the list of structures to check
            foreach (var item in PriceSystemRegions)
            {
                if (!string.IsNullOrEmpty(item.SystemID))
                {
                    // Only look up structures in this system
                    SQL = "SELECT DISTINCT STATION_ID FROM STATIONS WHERE SOLAR_SYSTEM_ID =" + item.SystemID + " AND STATION_ID >70000000";
                }
                else
                {
                    // Get all the structures in that region
                    SQL = "SELECT DISTINCT STATION_ID FROM STATIONS WHERE REGION_ID =" + item.RegionID + " AND STATION_ID >70000000";
                }

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                rsCheck = Public_Variables.DBCommand.ExecuteReader();

                while (rsCheck.Read())
                {
                    if (!StructureIDs.Contains(rsCheck.GetInt64(0)))
                    {
                        StructureIDs.Add(rsCheck.GetInt64(0));
                    }
                }

                rsCheck.Close();
            }

            if (StructureIDs.Count > 0)
            {
                // For processing
                var ThreadPairs = new List<StructureDataQueryInfo>();
                var Pair = new StructureDataQueryInfo();
                int PairMarker = 0;
                var SP = new StructureProcessor();

                // Load all the query data
                foreach (var SID in StructureIDs)
                {
                    Pair.StructureID = SID;
                    Pair.TokenData = Tokendata;
                    Pair.SupressMessages = true;
                    Pair.ProgressBarRef = null;
                    ThreadPairs.Add(Pair);
                }

                // Start by updating all the structure data for the list - this way we don't need to do it for each price returned
                SP.UpdateStructuresData(StructureIDs, Public_Variables.SelectedCharacter.CharacterTokenData, refPG);

                Public_Variables.EVEDB.BeginSQLiteTransaction();
                Application.DoEvents();

                // Call this manually if it's just one item to update
                if (ThreadPairs.Count == 1)
                {
                    // Set the refPG so it's updated inside the single run of the structure orders
                    var TempPair = new StructureDataQueryInfo();
                    TempPair = ThreadPairs[0];
                    TempPair.ProgressBarRef = refPG;
                    ThreadPairs = new List<StructureDataQueryInfo>();
                    ThreadPairs.Add(TempPair);
                    LoadStructureMarketOrders(ThreadPairs[0]);
                }
                else
                {
                    // Reset the value of the progress bar for counting structures
                    if (!(refPG == null))
                    {
                        refPG.Visible = true;
                        refPG.Value = 0;
                        StructureCount = 0;
                        refPG.Maximum = StructureIDs.Count;
                    }

                    // Call each thread for the pairs
                    for (int i = 0, loopTo = ThreadPairs.Count - 1; i <= loopTo; i++)
                    {
                        var UPHThread = new Thread((_) => this.LoadStructureMarketOrders());
                        UPHThread.Start(ThreadPairs[i]);
                        // Save the thread if we need to kill it
                        Threads.AddThread(UPHThread);
                    }

                    bool Stillworking = true;
                    int PrevCount = 0;
                    var StartTime = DateTime.Now;

                    while (!Threads.Complete())
                    {
                        // Update the progress bar with current count every time we check (only if we finished at least one run)
                        if (StructureCount > PrevCount)
                        {
                            IncrementToolStripProgressBar(StructureCount, ref refPG);
                        }
                        PrevCount = StructureCount;
                        Application.DoEvents();

                        // Check if we need to leave - cancel pressed or 2 minutes passed
                        if (Public_Variables.CancelUpdatePrices | StartTime != Public_Variables.NoDate & DateAndTime.DateDiff(DateInterval.Second, StartTime, DateTime.Now) >= 120L)
                        {
                            Threads.StopAllThreads();
                            // Reset the error handler
                            Public_Variables.ESIErrorHandler = new ESIErrorProcessor();
                            Public_Variables.EVEDB.RollbackSQLiteTransaction();
                            if (Public_Variables.CancelUpdatePrices)
                            {
                                return true; // They wanted this so don't error
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }

                    // Make sure all threads are not running
                    Threads.StopAllThreads();
                    // Reset the error handler
                    Public_Variables.ESIErrorHandler = new ESIErrorProcessor();

                }

                Public_Variables.EVEDB.CommitSQLiteTransaction();
            }

            return true;

        }

        public struct StructureDataQueryInfo
        {
            public long StructureID;
            public SavedTokenData TokenData;
            public ToolStripProgressBar ProgressBarRef;
            public bool SupressMessages;
        }

        // Updates the class referenced toolbar 
        private void IncrementToolStripProgressBar(int inValue, ref ToolStripProgressBar PG)
        {

            if (PG == null)
            {
                return;
            }

            // Updates the value in the progressbar for a smooth progress (slows procesing a little)
            if (inValue <= PG.Maximum - 1 & inValue != 0)
            {
                PG.Value = inValue;
                PG.Value = inValue - 1;
                PG.Value = inValue;
            }
            else
            {
                PG.Value = inValue;
            }

        }

        // Loads the sent structureID market orders - for use with threading call
        public bool LoadStructureMarketOrders(object SetQueryInfo)
        {
            List<ESIMarketOrder> MarketOrdersOutput;
            string SQL;
            SQLiteDataReader rsCache;
            var CacheDate = Public_Variables.NoDate;
            string OrderData = "";

            StructureDataQueryInfo QueryInfo = (StructureDataQueryInfo)SetQueryInfo;

            // First look up the cache date to see if it's time to run the update for the structure
            SQL = "SELECT CACHE_DATE FROM STRUCTURE_MARKET_ORDERS_UPDATE_CACHE WHERE STRUCTURE_ID = " + QueryInfo.StructureID.ToString();
            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsCache = Public_Variables.DBCommand.ExecuteReader();
            CacheDate = Public_Variables.ProcessCacheDate(ref rsCache);
            rsCache.Close();

            // For each structure, update the total record count for the progressbar on frmMain regardless of whether we do anything with it
            StructureCount += 1;

            // If it's later than now, update
            if (CacheDate <= DateTime.UtcNow)
            {
                // Delete any records for this structure since we have a fresh set to load
                Public_Variables.EVEDB.ExecuteNonQuerySQL("DELETE FROM STRUCTURE_MARKET_ORDERS WHERE LOCATION_ID = " + QueryInfo.StructureID.ToString());

                // Get the data from ESI 
                OrderData = GetPrivateAuthorizedData(ESIURL + "markets/structures/" + QueryInfo.StructureID.ToString() + "/" + TranquilityDataSource, FormatTokenData(QueryInfo.TokenData), QueryInfo.TokenData.TokenExpiration, ref CacheDate, QueryInfo.TokenData.CharacterID, QueryInfo.SupressMessages);

                if (!(OrderData == null))
                {
                    MarketOrdersOutput = JsonConvert.DeserializeObject<List<ESIMarketOrder>>(OrderData);

                    // Parse the data
                    if (MarketOrdersOutput.Count > 0)
                    {
                        Application.DoEvents();

                        StructureProcessor.StructureStationInformation StructureLocation;
                        var SP = new StructureProcessor();

                        // Get information but don't refresh
                        StructureLocation = SP.GetStationInformation(QueryInfo.StructureID, QueryInfo.TokenData, false);

                        if (!(QueryInfo.ProgressBarRef == null))
                        {
                            QueryInfo.ProgressBarRef.Value = 0;
                            QueryInfo.ProgressBarRef.Maximum = MarketOrdersOutput.Count - 1;
                            QueryInfo.ProgressBarRef.Visible = true;
                        }

                        // Now read through all the output items that are not in the table insert them in MARKET_ORDERS
                        for (int i = 0, loopTo = MarketOrdersOutput.Count - 1; i <= loopTo; i++)
                        {
                            {
                                var withBlock = MarketOrdersOutput[i];

                                string OrderDownloadType = "";

                                var IssueDate = FormatESIDate(withBlock.issued);

                                // Insert all the new records
                                SQL = "INSERT INTO STRUCTURE_MARKET_ORDERS VALUES (" + withBlock.order_id.ToString() + "," + withBlock.type_id.ToString() + ",";
                                SQL += withBlock.location_id + "," + StructureLocation.RegionID.ToString() + "," + StructureLocation.SystemID.ToString() + ",'";
                                SQL += Conversions.ToString(IssueDate) + "'," + withBlock.duration + "," + Conversions.ToInteger(withBlock.is_buy_order).ToString() + "," + withBlock.price + "," + withBlock.volume_total + ",";
                                SQL += withBlock.min_volume + "," + withBlock.volume_remain + ",'" + withBlock.range + "')";
                                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                            }
                            if (!(QueryInfo.ProgressBarRef == null))
                            {
                                QueryInfo.ProgressBarRef.Value = i;
                            }
                            Application.DoEvents();
                        }

                    }
                }
                else
                {
                    return false;
                }

                // Set the Cache Date for everything queried 
                Public_Variables.EVEDB.ExecuteNonQuerySQL("DELETE FROM STRUCTURE_MARKET_ORDERS_UPDATE_CACHE WHERE STRUCTURE_ID = " + QueryInfo.StructureID.ToString());
                Public_Variables.EVEDB.ExecuteNonQuerySQL("INSERT INTO STRUCTURE_MARKET_ORDERS_UPDATE_CACHE VALUES (" + QueryInfo.StructureID.ToString() + ",'" + Strings.Format(CacheDate, Public_Variables.SQLiteDateFormat) + "')");


                return true;
            }
            else
            {
                return false;
            }

            return true;

        }

        // Just tries to download market prices - if it gets prices, then returns true else false
        public bool CheckStructureMarketData(long StructureID, SavedTokenData TokenData, bool SupressErrors)
        {
            string PriceData = "";

            DateTime argCacheDate = default;
            PriceData = GetPrivateAuthorizedData(ESIURL + "markets/structures/" + StructureID.ToString() + "/" + TranquilityDataSource, FormatTokenData(TokenData), TokenData.TokenExpiration, ref argCacheDate, Public_Variables.SelectedCharacter.ID, SupressErrors, true);

            if (!(PriceData == null))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion

        #region Public Data

        // Get the status of all ESI endpoints
        public void GetESIStatus([Optional] ref Label UpdateLabel, [Optional] ref ProgressBar PB)
        {
            try
            {

                Label TempLabel;
                ProgressBar TempPB;
                string RawData;
                var CB = new CacheBox();
                var CacheDate = default(DateTime);
                var ESIData = new ESI();
                var StatusItems = new List<ESIStatusItem>();
                string tag1;
                string tag2;
                string tag3;

                SQLiteDataReader rsUpdate;
                string SQL;

                if (UpdateLabel == null)
                {
                    TempLabel = new Label();
                }
                else
                {
                    TempLabel = UpdateLabel;
                }

                if (PB == null)
                {
                    TempPB = new ProgressBar();
                }
                else
                {
                    TempPB = PB;
                }

                // Update public structures only if dummy not selected, since we need a token to update the structure data
                if (CB.DataUpdateable(CacheDateType.ESIStatus))
                {
                    TempLabel.Text = "Downloading Public Structure Data...";
                    Application.DoEvents();

                    RawData = ESIData.GetPublicData(ESIStatusURL, ref CacheDate);

                    if (!(RawData == null))
                    {
                        StatusItems = JsonConvert.DeserializeObject<List<ESIStatusItem>>(RawData);
                        Public_Variables.EVEDB.BeginSQLiteTransaction();

                        // Set all to red first - if one goes down or is removed from the list (e.g., assets) then we will see it as down
                        Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format("UPDATE ESI_STATUS_ITEMS SET status = 'red'"));

                        // Add all to status table incase we use one in the future that's not used now
                        foreach (var item in StatusItems)
                        {
                            tag1 = "";
                            tag2 = "";
                            tag3 = "";
                            switch (item.tags.Count)
                            {
                                case 1:
                                    {
                                        tag1 = item.tags[0];
                                        break;
                                    }
                                case 2:
                                    {
                                        tag1 = item.tags[0];
                                        tag2 = item.tags[1];
                                        break;
                                    }
                                case 3:
                                    {
                                        tag1 = item.tags[0];
                                        tag2 = item.tags[1];
                                        tag3 = item.tags[2];
                                        break;
                                    }
                            }

                            // Look up each entry and if not in there, insert, if there, update
                            SQL = "SELECT 'X' FROM ESI_STATUS_ITEMS WHERE route = '" + item.route + "'";
                            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                            rsUpdate = Public_Variables.DBCommand.ExecuteReader();
                            rsUpdate.Read();

                            if (rsUpdate.HasRows)
                            {
                                // just update the values
                                Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format("UPDATE ESI_STATUS_ITEMS SET endpoint='{0}', method='{1}', status='{2}', tag1='{3}',tag2='{4}',tag3='{5}' WHERE route = '{6}'", item.endpoint, item.@method, item.status, tag1, tag2, tag3, item.route));
                            }
                            else
                            {
                                Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format("INSERT INTO ESI_STATUS_ITEMS VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", item.endpoint, item.@method, item.route, item.status, tag1, tag2, tag3));
                            }

                            rsUpdate.Close();
                        }

                        Public_Variables.EVEDB.CommitSQLiteTransaction();
                    }

                    CB.UpdateCacheDate(CacheDateType.ESIStatus, CacheDate);
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("Unable to get ESI Status: " + ex.Message, Constants.vbInformation, Application.ProductName);
            }

        }

        // Gets the ESI file from CCP for the current Market orders (buy and sell) for the region_id and type_id sent
        // Open transaction will open an SQL transaction here instead of the calling function
        // Returns boolean if the history was updated or not
        public bool UpdateMarketOrders(ref DBConnection MHDB, long TypeID, long RegionID, bool OpenTransaction = true, bool IgnoreCacheLookup = false)
        {
            List<ESIMarketOrder> MarketOrdersOutput;
            string SQL;
            SQLiteDataReader rsCache;
            var CacheDate = Public_Variables.NoDate;
            string PublicData = "";
            bool DataFound = true;

            if (!IgnoreCacheLookup)
            {
                // First look up the cache date to see if it's time to run the update
                SQL = "SELECT CACHE_DATE FROM MARKET_ORDERS_UPDATE_CACHE WHERE TYPE_ID = " + TypeID.ToString() + " AND REGION_ID = " + RegionID.ToString();
                Public_Variables.DBCommand = new SQLiteCommand(SQL, MHDB.DBREf());
                rsCache = Public_Variables.DBCommand.ExecuteReader();

                CacheDate = Public_Variables.ProcessCacheDate(ref rsCache);

                rsCache.Close();
            }
            else
            {
                CacheDate = Public_Variables.NoDate;
            }

            // If it's later than now, update
            if (CacheDate <= DateTime.UtcNow)
            {

                // Delete any records for this type and region since we have a fresh set to load
                MHDB.ExecuteNonQuerySQL("DELETE FROM MARKET_ORDERS WHERE TYPE_ID = " + TypeID.ToString() + " AND REGION_ID = " + RegionID.ToString());

                // Get the data from ESI 
                PublicData = GetPublicData(ESIURL + "markets/" + RegionID.ToString() + "/orders/" + TranquilityDataSource + "&type_id=" + TypeID.ToString(), ref CacheDate);

                if (!(PublicData == null))
                {
                    MarketOrdersOutput = JsonConvert.DeserializeObject<List<ESIMarketOrder>>(PublicData);

                    foreach (var item in MarketOrdersOutput)
                    {
                        if (!Public_Variables.LocationIDs.Contains(item.location_id))
                        {
                            Public_Variables.LocationIDs.Add(item.location_id);
                        }
                    }

                    // Parse the data
                    if (MarketOrdersOutput.Count > 0)
                    {
                        Application.DoEvents();

                        // Now read through all the output items that are not in the table insert them in MARKET_ORDERS
                        for (int i = 0, loopTo = MarketOrdersOutput.Count - 1; i <= loopTo; i++)
                        {
                            {
                                var withBlock = MarketOrdersOutput[i];
                                StructureProcessor.StructureStationInformation StationData;
                                string OrderDownloadType = "";
                                var SP = new StructureProcessor();

                                // Look up data for the station/structure - don't refresh it as we can do that in one call later if not found
                                StationData = SP.GetStationInformation(withBlock.location_id, Public_Variables.SelectedCharacter.CharacterTokenData, false);

                                var IssueDate = FormatESIDate(withBlock.issued);

                                // Insert all the new records
                                SQL = "INSERT INTO MARKET_ORDERS VALUES (" + withBlock.order_id.ToString() + "," + TypeID.ToString() + ",";
                                SQL += withBlock.location_id + "," + StationData.RegionID.ToString() + "," + StationData.SystemID.ToString() + ",'";
                                SQL += Conversions.ToString(IssueDate) + "'," + withBlock.duration + "," + Conversions.ToInteger(withBlock.is_buy_order).ToString() + "," + withBlock.price + "," + withBlock.volume_total + ",";
                                SQL += withBlock.min_volume + "," + withBlock.volume_remain + ",'" + withBlock.range + "')";
                                MHDB.ExecuteNonQuerySQL(SQL);
                            }

                            Application.DoEvents();
                        }

                    }
                    DataFound = true;
                }
                else
                {
                    // Json file didn't download
                    DataFound = false;
                }

                // Set the Cache Date for everything queried 
                MHDB.ExecuteNonQuerySQL("DELETE FROM MARKET_ORDERS_UPDATE_CACHE WHERE TYPE_ID = " + TypeID.ToString() + " AND REGION_ID = " + RegionID.ToString());
                MHDB.ExecuteNonQuerySQL("INSERT INTO MARKET_ORDERS_UPDATE_CACHE VALUES (" + TypeID.ToString() + "," + RegionID.ToString() + "," + "'" + Strings.Format(CacheDate, Public_Variables.SQLiteDateFormat) + "')");

                return DataFound;
            }

            else
            {
                return false;
            }

            return true;

        }

        // Provides per day summary of market activity for 13 months for the region_id and type_id sent. (cache: 23 hours)
        // Open transaction will open an SQL transaction here instead of the calling function
        // Returns boolean if the history was updated or not
        public bool UpdateMarketHistory(ref DBConnection MHDB, long TypeID, long RegionID)
        {
            List<ESIMarketHistoryItem> MarketPricesOutput;
            string SQL = "";
            var CacheDate = Public_Variables.NoDate;
            string PublicData = "";
            ToolStripProgressBar argSentPG = null;
            var MPI = new MarketPriceInterface(ref argSentPG);
            var Pair = new MarketPriceInterface.ItemRegionPairs();

            try
            {
                // Check if it can be updated
                Pair.ItemID = TypeID;
                Pair.RegionID = RegionID;

                // If it's later than now, update
                if (MPI.UpdatableMarketData(Pair, MarketPriceInterface.MarketPriceCacheType.History))
                {

                    // Get the data from ESI
                    PublicData = GetPublicData(ESIURL + "markets/" + RegionID.ToString() + "/history/" + TranquilityDataSource + "&type_id=" + TypeID.ToString(), ref CacheDate);
                    MarketPricesOutput = JsonConvert.DeserializeObject<List<ESIMarketHistoryItem>>(PublicData);

                    // Read in the data
                    if (!(MarketPricesOutput == null))
                    {
                        if (MarketPricesOutput.Count > 0)
                        {
                            // Delete all records from history so we update with a fresh set
                            MHDB.ExecuteNonQuerySQL(string.Format("DELETE FROM MARKET_HISTORY WHERE TYPE_ID = {0} AND REGION_ID = {1}", TypeID, RegionID));

                            // Refresh data
                            foreach (var PriceEntry in MarketPricesOutput)
                            {
                                SQL = "INSERT INTO MARKET_HISTORY VALUES (" + TypeID.ToString() + "," + RegionID.ToString() + ",'" + Strings.Format(FormatESIDate(PriceEntry.history_date), Public_Variables.SQLiteDateFormat) + "',";
                                SQL += PriceEntry.lowest.ToString() + "," + PriceEntry.highest.ToString() + "," + PriceEntry.average.ToString() + "," + PriceEntry.order_count.ToString() + "," + PriceEntry.volume.ToString() + ")";
                                MHDB.ExecuteNonQuerySQL(SQL);

                                Application.DoEvents();
                            }
                        }

                        // Set the Cache Date for everything queried 
                        MHDB.ExecuteNonQuerySQL("DELETE FROM MARKET_HISTORY_UPDATE_CACHE WHERE TYPE_ID = " + TypeID.ToString() + " AND REGION_ID = " + RegionID.ToString());
                        MHDB.ExecuteNonQuerySQL("INSERT INTO MARKET_HISTORY_UPDATE_CACHE VALUES (" + TypeID.ToString() + "," + RegionID.ToString() + "," + "'" + Strings.Format(CacheDate, Public_Variables.SQLiteDateFormat) + "')");

                        return true;

                    }
                    // Json file didn't download
                    return false;
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        // Returns the list of trade-able types and their average market price, as shown in the inventory UI in the EVE client. 
        // Also includes an adjusted market price which is used in industry calculations.
        public bool UpdateAdjAvgMarketPrices([Optional] ref Label UpdateLabel, [Optional] ref ProgressBar PB)
        {
            List<ESIMarketAdjustedPrice> MarketPricesOutput;
            string SQL;
            Label TempLabel;
            ProgressBar TempPB;
            string PublicData;

            if (UpdateLabel == null)
            {
                TempLabel = new Label();
            }
            else
            {
                TempLabel = UpdateLabel;
            }

            if (PB == null)
            {
                TempPB = new ProgressBar();
            }
            else
            {
                TempPB = PB;
            }

            var CB = new CacheBox();
            var CacheDate = default(DateTime);

            // Get the current list of agents updated
            if (CB.DataUpdateable(CacheDateType.MarketPrices))
            {

                TempLabel.Text = "Downloading Adjusted Market Price Data...";
                Application.DoEvents();

                // Get the data from ESI
                PublicData = GetPublicData(ESIURL + "markets/prices/" + TranquilityDataSource, ref CacheDate);

                if (!(PublicData == null))
                {
                    MarketPricesOutput = JsonConvert.DeserializeObject<List<ESIMarketAdjustedPrice>>(PublicData);

                    // Read in the data
                    if (!(MarketPricesOutput == null))
                    {
                        if (MarketPricesOutput.Count > 0)
                        {
                            Public_Variables.EVEDB.BeginSQLiteTransaction();

                            // Clear the old records first
                            Public_Variables.EVEDB.ExecuteNonQuerySQL("UPDATE ITEM_PRICES_FACT SET ADJUSTED_PRICE = 0, AVERAGE_PRICE = 0");

                            TempLabel.Text = "Saving Adjusted Market Price Data...";
                            TempPB.Minimum = 0;
                            TempPB.Value = 0;
                            TempPB.Maximum = MarketPricesOutput.Count - 1;
                            TempPB.Visible = true;
                            Application.DoEvents();

                            // Now read through all the output items and update them in ITEM_PRICES
                            for (int i = 0, loopTo = MarketPricesOutput.Count - 1; i <= loopTo; i++)
                            {
                                {
                                    var withBlock = MarketPricesOutput[i];
                                    string AdjustedPrice;
                                    if (!(withBlock.adjusted_Price == null))
                                    {
                                        AdjustedPrice = Public_Variables.ConvertEUDecimaltoUSDecimal(withBlock.adjusted_Price);
                                    }
                                    else
                                    {
                                        AdjustedPrice = "0.00";
                                    }

                                    string AveragePrice;
                                    if (!(withBlock.average_Price == null))
                                    {
                                        AveragePrice = Public_Variables.ConvertEUDecimaltoUSDecimal(withBlock.average_Price);
                                    }
                                    else
                                    {
                                        AveragePrice = "0.00";
                                    }
                                    SQL = "UPDATE ITEM_PRICES_FACT SET ADJUSTED_PRICE = " + AdjustedPrice + ", AVERAGE_PRICE = " + AveragePrice;
                                    SQL += " WHERE ITEM_ID = " + withBlock.type_id.ToString();
                                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                                }

                                // For each record, update the progress bar
                                Public_Variables.IncrementProgressBar(ref TempPB);
                                Application.DoEvents();

                            }

                            // All set, update cache date before leaving
                            CB.UpdateCacheDate(CacheDateType.MarketPrices, CacheDate);

                            // Done updating
                            Public_Variables.EVEDB.CommitSQLiteTransaction();
                            return true;
                        }
                    }
                }
                // Data didn't download
                return false;
            }

            return true;

        }

        // Updates the cost index for installing industry jobs per type of activity. This does not include wormhole space.
        public bool UpdateIndustrySystemsCostIndex([Optional] ref Label UpdateLabel, [Optional] ref ProgressBar PB)
        {
            List<ESISystemCostIndices> IndustrySystemsIndex;
            string SQL;
            SQLiteDataReader rsLookup;
            string PublicData;
            int SolarSystemID;
            string SolarSystemName;
            int ActivityID;

            Label TempLabel;
            ProgressBar TempPB;

            if (UpdateLabel == null)
            {
                TempLabel = new Label();
            }
            else
            {
                TempLabel = UpdateLabel;
            }

            if (PB == null)
            {
                TempPB = new ProgressBar();
            }
            else
            {
                TempPB = PB;
            }

            var CB = new CacheBox();
            var CacheDate = default(DateTime);

            // Get the current list of agents updated
            if (CB.DataUpdateable(CacheDateType.IndustrySystems))
            {
                TempLabel.Text = "Downloading System Index Data...";
                Application.DoEvents();

                // Get the data from ESI
                PublicData = GetPublicData(ESIURL + "industry/systems/" + TranquilityDataSource, ref CacheDate);

                if (!(PublicData == null))
                {
                    IndustrySystemsIndex = JsonConvert.DeserializeObject<List<ESISystemCostIndices>>(PublicData);

                    // Read in the data
                    if (!(IndustrySystemsIndex == null))
                    {
                        if (IndustrySystemsIndex.Count > 0)
                        {
                            Public_Variables.EVEDB.BeginSQLiteTransaction();

                            TempLabel.Text = "Saving System Index Data...";
                            TempPB.Minimum = 0;
                            TempPB.Value = 0;
                            TempPB.Maximum = IndustrySystemsIndex.Count - 1;
                            TempPB.Visible = true;
                            Application.DoEvents();

                            // Now read through all the output items and input them into the DB
                            for (int i = 0, loopTo = IndustrySystemsIndex.Count - 1; i <= loopTo; i++)
                            {

                                SolarSystemID = IndustrySystemsIndex[i].solar_system_id;
                                SolarSystemName = Public_Variables.GetSolarSystemName(SolarSystemID);

                                for (int j = 0, loopTo1 = IndustrySystemsIndex[i].cost_indices.Count - 1; j <= loopTo1; j++)
                                {
                                    {
                                        var withBlock = IndustrySystemsIndex[i].cost_indices[j];
                                        // Update name
                                        // copying, duplicating, invention, manufacturing, none, reaction, researching_material_efficiency, researching_technology, researching_time_efficiency, reverse_engineering 
                                        if (withBlock.activity == "reaction")
                                        {
                                            withBlock.activity = "Reactions";
                                        }
                                        else if (withBlock.activity.Contains("_"))
                                        {
                                            withBlock.activity = withBlock.activity.Replace("_", " "); // replace underscores with spaces
                                        }

                                        // Format for title 
                                        withBlock.activity = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(withBlock.activity);

                                        ActivityID = Public_Variables.GetActivityID(withBlock.activity);
                                        // Look up each system and if found, update it. If not, insert - this way if the ESI is having issues, we won't delete all the station data (which doesn't change much)
                                        SQL = "SELECT 'X' FROM INDUSTRY_SYSTEMS_COST_INDICIES WHERE SOLAR_SYSTEM_ID = " + SolarSystemID.ToString() + " AND ACTIVITY_ID = " + ActivityID.ToString();

                                        Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                                        rsLookup = Public_Variables.DBCommand.ExecuteReader();

                                        if (rsLookup.Read())
                                        {
                                            // Update the old
                                            SQL = "UPDATE INDUSTRY_SYSTEMS_COST_INDICIES ";
                                            SQL += "SET SOLAR_SYSTEM_NAME = '" + Public_Variables.FormatDBString(SolarSystemName) + "',";
                                            SQL += "ACTIVITY_ID = " + ActivityID.ToString() + ",";
                                            SQL += "ACTIVITY_NAME = '" + Public_Variables.FormatDBString(withBlock.activity) + "',";
                                            SQL += "COST_INDEX = " + withBlock.cost_index.ToString() + " ";
                                            SQL += "WHERE SOLAR_SYSTEM_ID = " + SolarSystemID.ToString() + " AND ACTIVITY_ID = " + ActivityID.ToString();
                                        }
                                        else
                                        {
                                            // Insert the new record
                                            SQL = "INSERT INTO INDUSTRY_SYSTEMS_COST_INDICIES VALUES(" + SolarSystemID.ToString() + ",'" + Public_Variables.FormatDBString(SolarSystemName) + "',";
                                            SQL += ActivityID.ToString() + ",'" + Public_Variables.FormatDBString(withBlock.activity) + "'," + withBlock.cost_index.ToString() + ")";
                                        }
                                        rsLookup.Close();

                                        Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                                    }
                                }

                                // For each record, update the progress bar
                                Public_Variables.IncrementProgressBar(ref TempPB);
                                Application.DoEvents();
                            }

                            TempPB.Visible = false;

                            // Rebuild indexes
                            Public_Variables.EVEDB.ExecuteNonQuerySQL("REINDEX IDX_ISCI_SSID_AID");

                            // All set, update cache date before leaving
                            CB.UpdateCacheDate(CacheDateType.IndustrySystems, CacheDate);

                            // Done updating
                            Public_Variables.EVEDB.CommitSQLiteTransaction();

                            return true;

                        }
                    }
                }
                // Json file didn't download or other error
                return false;
            }

            return true;

        }

        // Downloads all public structure ID's that have markets and then refreshes the data on them in the Stations Table.
        public bool UpdatePublicStructureswithMarkets([Optional] ref Label UpdateLabel, [Optional] ref ProgressBar PB)
        {

            try
            {
                Label TempLabel;
                ProgressBar TempPB;
                string PublicData;
                var PublicStructureIDs = new List<long>();
                var TempList = new List<long>();
                var Threads = new ThreadingArray();

                if (UpdateLabel == null)
                {
                    TempLabel = new Label();
                }
                else
                {
                    TempLabel = UpdateLabel;
                }

                if (PB == null)
                {
                    TempPB = new ProgressBar();
                }
                else
                {
                    TempPB = PB;
                }

                var CB = new CacheBox();
                var CacheDate = default(DateTime);

                // Update public structures only if dummy not selected, since we need a token to update the structure data
                if (CB.DataUpdateable(CacheDateType.PublicStructures) & Public_Variables.SelectedCharacter.ID != Public_Variables.DummyCharacterID)
                {

                    TempLabel.Text = "Downloading Public Structure Data...";
                    Application.DoEvents();

                    // Get all the public structure IDs from ESI with a market module
                    PublicData = GetPublicData(ESIURL + "universe/structures/" + TranquilityDataSource + "&filter=market", ref CacheDate);

                    if (!(PublicData == null))
                    {
                        PublicStructureIDs = JsonConvert.DeserializeObject<List<long>>(PublicData);

                        if (!(PublicStructureIDs == null))
                        {
                            if (PublicStructureIDs.Count > 0)
                            {

                                Public_Variables.EVEDB.BeginSQLiteTransaction();

                                // Delete all structures from the table first, so that we have a fresh list. Industry jobs and Asset updates will refresh their structures if needed
                                Public_Variables.ResetPublicStructureData();

                                // Set the labels and progress bar if needed
                                TempLabel.Text = "Saving Public Structure Data...";
                                TempPB.Visible = false; // don't show this one
                                Application.DoEvents();

                                // Now read through all the output items and update them in STATIONS - using a thread per look up
                                // Call each thread for the pairs
                                foreach (var ID in PublicStructureIDs)
                                {
                                    var SP = new StructureProcessor();
                                    var Params = new StructureProcessor.StructureIDTokenEntryFlag();
                                    Params.StructureID = ID;
                                    Params.TokenData = Public_Variables.SelectedCharacter.CharacterTokenData;
                                    Params.RefPG = null;
                                    Params.ManualEntry = false;

                                    var SDThread = new Thread(SP.UpdateStructureData);
                                    SDThread.Start(Params);
                                    // Save the thread if we need to kill it
                                    Threads.AddThread(SDThread);
                                }

                                bool stillworking = true;

                                while (!Threads.Complete())
                                    Application.DoEvents();

                                // Make sure all threads are not running
                                Threads.StopAllThreads();
                                // Reset the error handler
                                Public_Variables.ESIErrorHandler = new ESIErrorProcessor();

                                // All set, update cache date before leaving
                                CB.UpdateCacheDate(CacheDateType.PublicStructures, CacheDate);

                                // Done updating
                                Public_Variables.EVEDB.CommitSQLiteTransaction();

                                return true;

                            }
                        }
                    }

                    // Data didn't download
                    return false;
                }

                return true;
            }

            catch (Exception ex)
            {
                Interaction.MsgBox("Failed to update public structure data: " + ex.Message, Constants.vbInformation, Application.ProductName);
                Public_Variables.EVEDB.CommitSQLiteTransaction();

                return false;

            }

        }

        #endregion

        #region Supporting Functions

        public List<ESIFactionData> GetFactionData()
        {
            string PublicData;

            try
            {
                DateTime argCacheDate = default;
                PublicData = GetPublicData(ESIURL + "universe/factions/" + TranquilityDataSource, ref argCacheDate);

                return JsonConvert.DeserializeObject<List<ESIFactionData>>(PublicData);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        // Looks up the name for the list of IDs
        public List<ESINameData> GetNameData(List<long> IDList)
        {
            string IDs = "[";
            string PublicData;

            foreach (var ID in IDList)
                IDs += ID.ToString() + ",";

            IDs = IDs.Substring(0, Strings.Len(IDs) - 1); // strip comma
            IDs += "]";

            DateTime argCacheDate = default;
            PublicData = GetPublicData(ESIURL + "universe/names/" + TranquilityDataSource, ref argCacheDate, IDs);

            if (!(PublicData == null))
            {
                return JsonConvert.DeserializeObject<List<ESINameData>>(PublicData);
            }
            else
            {
                return null;
            }

        }

        public int GetMaximumConnections()
        {
            return ESIMaximumConnections;
        }

        private string GetCodeVerifier()
        {
            byte[] RandomBytes = new byte[33];
            var RandomNumber = new RNGCryptoServiceProvider();

            RandomNumber.GetBytes(RandomBytes);

            return GetURLSafeCode(RandomBytes);

        }

        private string GetChallengeCode(string CodeVerifier)
        {
            var Hash256 = new SHA256Managed();

            // Make sure it can work in web calls
            return GetURLSafeCode(Hash256.ComputeHash(Encoding.ASCII.GetBytes(CodeVerifier)));

        }

        private string GetURLSafeCode(byte[] SentCode)
        {
            // Note, says on jwt that we can't pad with "=" https://tools.ietf.org/html/rfc7515#section-2
            return Convert.ToBase64String(SentCode).Replace("+", "-").Replace("/", "_").TrimEnd('=');
        }

        #endregion

    }

    public class ESIErrorProcessor
    {

        public bool ErrorLimitReached; // Flag whether we are waiting on the error window
        public int msErrorTimer; // Time in milliseconds until we go again
        public bool RetriedCall;
        public int ErrorCode;
        public string ErrorResponse;
        private ErrorCounter LocalErrorCounter;
        [DllImport("User32", EntryPoint = "FindWindowA")]
        public static extern IntPtr FindWindowA(string lpClassName, string lpWindowName);

        public enum ESIErrorLocation
        {
            PrivateAuthData = 0,
            PublicData = 1,
            CharacterVerification = 2,
            AccessToken = 3,
            AuthToken = 4
        }

        public ESIErrorProcessor()
        {
            ErrorCode = 0;
            ErrorResponse = "";
            RetriedCall = false;
            ErrorLimitReached = false;
            msErrorTimer = 0;
            LocalErrorCounter = new ErrorCounter();
        }

        public void ProcessWebException(WebException ExceptionData, ESIErrorLocation Location, bool SupressErrorMessage, string URL)
        {
            var ESIJsonError = new ESIError();
            string MsgBoxText = "";
            var myWebHeaderCollection = new WebHeaderCollection();

            int ESIErrorLimitRemain; // how many errors responses will be returned to you in the current error window 
            int ESIErrorLimitReset; // indicates the number of seconds until the end of the current error window

            if (!(ExceptionData.Response == null))
            {
                ErrorCode = (int)((HttpWebResponse)ExceptionData.Response).StatusCode;
                ErrorResponse = GetErrorResponseBody(ExceptionData, ref ESIJsonError);

                // Look at our error limits
                myWebHeaderCollection = new WebHeaderCollection();
                myWebHeaderCollection = ExceptionData.Response.Headers;
                ESIErrorLimitRemain = Conversions.ToInteger(myWebHeaderCollection["X-ESI-Error-Limit-Remain"]);
                ESIErrorLimitReset = Conversions.ToInteger(myWebHeaderCollection["X-ESI-Error-Limit-Reset"]);
            }

            else
            {
                ErrorCode = -1;
                ErrorResponse = "Unknown Error";
                ESIErrorLimitRemain = -1;
                ESIErrorLimitReset = -1;
            }

            // Count the error
            LocalErrorCounter.AddError(ErrorCode);

            // If we are at max errors, wait until the next window before running more queries (IPH only allows 25 less than max to limit 420's in threads)
            if (ESIErrorLimitRemain - 25 <= 0)
            {
                ErrorLimitReached = true;
                // Set the time for all threads to use
                msErrorTimer = ESIErrorLimitReset * 1000 + 1000;
                // Set the time to wait for all threads and wait until the window closes plus 1 second
                Thread.Sleep(msErrorTimer);
                ErrorLimitReached = false; // Can run new calls
            }

            if (ErrorResponse.Contains("Character not in corporation") | ErrorResponse.Contains("Character cannot grant roles"))
            {
                // Assume this error came from checking on NPC corp roles or a character that doesn't have any roles and just exit with nothing
                return;
            }

            // Ignore these for now
            if (ErrorCode == 304 | ErrorCode == -1 | ErrorCode > 500)
            {
                return;
            }

            if (ErrorCode == 403 & ErrorResponse.Contains("required role(s)") & URL.Contains("/corporations/"))
            {
                // This is a call to corporation roles that now errors if you don't have any roles. The response will return all roles for the characters in the corp and you 
                // need personel manager or director to really do it so don't error if it's just a character with those roles only
                return;
            }

            if (ErrorCode == 404 & ErrorResponse == "Type not found!")
            {
                return;
            }

            // This is the error we get if you switch corps and the old corp id is attached to your account info, which may not need to be updated
            // The change in corp number seems to take a bit to complete, so they will have to wait until this info is refereshed in ESI - so we will supress this error
            if (ErrorResponse == "Received bad session variable(s): \"corporation_id\" " & URL.Contains("/corporations/"))
            {
                return;
            }

            // If a refresh token expires, then we should just exit and the error log will capture it to tell them to reset
            if (ErrorResponse.Contains("Invalid refresh token. Token missing/expired"))
            {
                return;
            }

            // Build Messagebox text
            MsgBoxText = Constants.vbCrLf + Constants.vbCrLf + "Error Code: " + ErrorCode + Constants.vbCrLf + "Message: " + ExceptionData.Message + Constants.vbCrLf + "Description: " + ErrorResponse;

            switch (Location)
            {
                case ESIErrorLocation.AccessToken:
                    {
                        MsgBoxText = "The request failed to get Access Token. " + MsgBoxText;
                        break;
                    }
                case ESIErrorLocation.AuthToken:
                    {
                        MsgBoxText = "The request failed to get Authorization Token. " + MsgBoxText;
                        break;
                    }
                case ESIErrorLocation.CharacterVerification:
                    {
                        MsgBoxText = "The request failed to get Character Verification data. " + MsgBoxText;
                        break;
                    }
                case ESIErrorLocation.PrivateAuthData:
                    {
                        MsgBoxText = "The request failed to get Authorized data. " + MsgBoxText;
                        break;
                    }
                case ESIErrorLocation.PublicData:
                    {
                        MsgBoxText = "The request failed to get Public data. " + MsgBoxText;
                        break;
                    }
            }

            // For threading but if we get this error more than 200 times, set the flag to cancel threads 
            if (LocalErrorCounter.GetErrorCount(ErrorCode) > 100)
            {
                Public_Variables.CancelThreading = true;
            }

            if (!string.IsNullOrEmpty(URL))
            {
                MsgBoxText += Constants.vbCrLf + Constants.vbCrLf + "URL: " + URL;
            }

            // If they have the error more than 5 times, then stop showing the message box
            if (!SupressErrorMessage)
            {
                if (ErrorCode != 420) // 420's are handled above
                {
                    string arglpClassName = null;
                    string arglpWindowName = "ESI Data Import Error";
                    if (ESIErrorProcessor.FindWindowA(arglpClassName, arglpWindowName) == IntPtr.Zero)
                    {
                        Interaction.MsgBox(MsgBoxText, Constants.vbInformation, "ESI Data Import Error");
                    }
                }
            }

        }

        public void ProcessException(Exception ExceptionData, ESIErrorLocation Location, bool SupressErrorMessage)
        {

            // This HR result is for thread aborts. Test out for awhile to see how it works and leave sub without error message
            if (ExceptionData.HResult == -2146233040)
            {
                return;
            }

            if (SupressErrorMessage)
            {
                return;
            }

            switch (Location)
            {
                case ESIErrorLocation.AccessToken:
                    {
                        Interaction.MsgBox("The request failed to get Access Token. " + ExceptionData.Message, Constants.vbInformation, Application.ProductName);
                        break;
                    }
                case ESIErrorLocation.AuthToken:
                    {
                        Interaction.MsgBox("The request failed to get Authorization Token. " + ExceptionData.Message, Constants.vbInformation, Application.ProductName);
                        break;
                    }
                case ESIErrorLocation.CharacterVerification:
                    {
                        Interaction.MsgBox("The request failed to get Character Verification data. " + ExceptionData.Message, Constants.vbInformation, Application.ProductName);
                        break;
                    }
                case ESIErrorLocation.PrivateAuthData:
                    {
                        Interaction.MsgBox("The request failed to get Authorized data. " + ExceptionData.Message, Constants.vbInformation, Application.ProductName);
                        break;
                    }
                case ESIErrorLocation.PublicData:
                    {
                        Interaction.MsgBox("The request failed to get Public data. " + ExceptionData.Message, Constants.vbInformation, Application.ProductName);
                        break;
                    }
            }

        }

        private string GetErrorResponseBody(WebException Webex, ref ESIError RefErrorData)
        {
            try
            {
                string resp = new StreamReader(Webex.Response.GetResponseStream()).ReadToEnd();
                var ErrorData = JsonConvert.DeserializeObject<ESIError>(resp);
                string Response = "";

                if (!(ErrorData == null))
                {
                    // save the data for reference
                    RefErrorData = ErrorData;
                    if (ErrorData.ErrorDescription == null)
                    {
                        ErrorData.ErrorDescription = "";
                    }

                    if (!string.IsNullOrEmpty(ErrorData.ErrorDescription))
                    {
                        return ErrorData.ErrorText + " - " + ErrorData.ErrorDescription;
                    }
                    else
                    {
                        return ErrorData.ErrorText;
                    }
                }

                else
                {
                    RefErrorData.ErrorText = Webex.Message;
                    RefErrorData.ErrorDescription = "";
                    return Webex.Message;
                }
            }
            catch (Exception ex)
            {
                return "Unknown error";
            }

        }

    }

    public class ErrorCounter
    {
        private List<ErrorTracker> TotalErrors; // count of total errors we have with description
        private object Lock = new object();
        private int ErrorNumbertoFind; // predicate search

        public ErrorCounter()
        {
            ErrorNumbertoFind = 0;
            TotalErrors = new List<ErrorTracker>();
        }

        private struct ErrorTracker
        {
            public int TotalNumErrors;
            public int ErrorNumber;
        }

        public void AddError(int ErrorCode)
        {
            lock (Lock)
            {
                // Count the errors we get
                ErrorTracker TempError;
                ErrorNumbertoFind = ErrorCode;
                TempError = TotalErrors.Find(FindError);

                if (TempError.TotalNumErrors != 0)
                {
                    // increment the number, and then save it
                    TotalErrors.Remove(TempError);
                    TempError.TotalNumErrors += 1;
                    TotalErrors.Add(TempError);
                }
                else
                {
                    TempError.ErrorNumber = ErrorCode;
                    TempError.TotalNumErrors = 1;
                    TotalErrors.Add(TempError);
                }

            }
        }

        // Returns the number of errors we have for the code sent
        public int GetErrorCount(int ErrorCode)
        {
            ErrorTracker TempError;
            ErrorNumbertoFind = ErrorCode;
            TempError = TotalErrors.Find(FindError);

            return TempError.TotalNumErrors;

        }

        // Predicate for finding an in the list of decryptors
        private bool FindError(ErrorTracker Entry)
        {
            if (Entry.ErrorNumber == ErrorNumbertoFind)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    #region JSON Classes

    public class ESIStatusItem
    {
        [JsonProperty("endpoint")]
        public string endpoint;
        [JsonProperty("method")]
        public string @method;
        [JsonProperty("route")]
        public string route;
        [JsonProperty("status")]
        public string status;
        [JsonProperty("tags")]
        public List<string> tags;
    }

    public class ESIError
    {
        [JsonProperty("error")]
        public string ErrorText;
        [JsonProperty("error_description")]
        public string ErrorDescription;
        [JsonProperty("sso_status")]
        public int sso_status;
        [JsonProperty("timeout")]
        public int timeout;
    }

    public class ESIMarketOrder
    {
        [JsonProperty("order_id")]
        public long order_id;
        [JsonProperty("type_id")]
        public int type_id;
        [JsonProperty("location_id")]
        public long location_id;
        [JsonProperty("system_id")]
        public int system_id;
        [JsonProperty("volume_total")]
        public int volume_total;
        [JsonProperty("volume_remain")]
        public int volume_remain;
        [JsonProperty("min_volume")]
        public int min_volume;
        [JsonProperty("price")]
        public double price;
        [JsonProperty("is_buy_order")]
        public bool is_buy_order;
        [JsonProperty("duration")]
        public int duration;
        [JsonProperty("issued")]
        public string issued; // date
        [JsonProperty("range")]
        public string range;
    }

    public class ESIMarketAdjustedPrice
    {
        [JsonProperty("adjusted_Price")]
        public string adjusted_Price; // String for easy processing
        [JsonProperty("average_Price")]
        public string average_Price; // String for easy processing
        [JsonProperty("type_id")]
        public int type_id;
    }

    public class ESIMarketPriceItems
    {
        [JsonProperty("date")]
        public string date_str;
        [JsonProperty("volume")]
        public long volume;
        [JsonProperty("orderCount")]
        public long orderCount;
        [JsonProperty("highPrice")]
        public string highPrice; // Use string for EU processing
        [JsonProperty("avgPrice")]
        public string avgPrice; // Use string for EU processing
        [JsonProperty("lowPrice")]
        public string lowPrice; // Use string for EU processing
    }

    public class ESIMarketHistoryItem
    {
        [JsonProperty("average")]
        public double average;
        [JsonProperty("date")]
        public string history_date;
        [JsonProperty("highest")]
        public double highest;
        [JsonProperty("lowest")]
        public double lowest;
        [JsonProperty("order_count")]
        public long order_count;
        [JsonProperty("volume")]
        public long volume;
    }

    public class ESISystemCostIndices
    {
        [JsonProperty("cost_indices")]
        public List<ESIcostIndex> cost_indices;
        [JsonProperty("solar_system_id")]
        public int solar_system_id;
    }

    public class ESIcostIndex
    {
        [JsonProperty("activity")]
        public string activity;
        [JsonProperty("cost_index")]
        public double cost_index;
    }

    public class ESIIndustryFacility
    {
        [JsonProperty("facility_id")]
        public long facility_id;
        [JsonProperty("owner_id")]
        public int owner_id;
        [JsonProperty("region_id")]
        public int region_id;
        [JsonProperty("solar_system_id")]
        public int solar_system_id;
        [JsonProperty("tax")]
        public double tax;
        [JsonProperty("type_id")]
        public int type_id;
    }

    public class ESIStationData
    {
        [JsonProperty("name")]
        public string name;
        [JsonProperty("office_rental_cost")]
        public double office_rental_cost;
        [JsonProperty("owner")]
        public int owner;
        [JsonProperty("position")]
        public ESIPosition position;
        [JsonProperty("reprocessing_efficiency")]
        public double reprocessing_efficiency;
        [JsonProperty("reprocessing_stations_take")]
        public double reprocessing_stations_take;
        [JsonProperty("services")]
        public List<string> services;
        [JsonProperty("station_id")]
        public int station_id;
        [JsonProperty("system_id")]
        public int system_id;
        [JsonProperty("type_id")]
        public int type_id;
    }

    public class ESIPosition
    {
        [JsonProperty("x")]
        public double x;
        [JsonProperty("y")]
        public double y;
        [JsonProperty("z")]
        public double z;
    }

    public class ESINameData
    {
        [JsonProperty("category")]
        public string category; // [ alliance, character, constellation, corporation, inventory_type, region, solar_system, station ]
        [JsonProperty("id")]
        public int id;
        [JsonProperty("name")]
        public string name;
    }

    public class ESIFactionData
    {
        [JsonProperty("faction_id")]
        public int faction_id;
        [JsonProperty("corporation_id")]
        public int corporation_id;
        [JsonProperty("description")]
        public string description;
        [JsonProperty("is_unique")]
        public bool is_unique;
        [JsonProperty("militia_corporation_id")]
        public int militia_corporation_id;
        [JsonProperty("name")]
        public string name;
        [JsonProperty("size_factor")]
        public double size_factor;
        [JsonProperty("solar_system_id")]
        public int solar_system_id;
        [JsonProperty("station_count")]
        public int station_count;
        [JsonProperty("station_system_count")]
        public int station_system_count;
    }

    #endregion

    #region Character and Token Processing

    public class SavedTokenData
    {
        public long CharacterID;
        public string AccessToken;
        public string TokenType;
        public DateTime TokenExpiration;
        public string RefreshToken;
        public string Scopes;

        public SavedTokenData()
        {
            CharacterID = 0L;
            AccessToken = "";
            TokenType = "";
            TokenExpiration = Public_Variables.NoDate;
            RefreshToken = "";
            Scopes = "";
        }

    }

    public class ESITokenData
    {
        [JsonProperty("access_token")]
        public string access_token;
        [JsonProperty("token_type")]
        public string token_type;
        [JsonProperty("expires_in")]
        public int expires_in; // in seconds
        [JsonProperty("refresh_token")]
        public string refresh_token;
    }

    public class ESICharacterVerificationData
    {
        [JsonProperty("CharacterID")]
        public string CharacterID;
        [JsonProperty("CharacterName")]
        public string CharacterName;
        [JsonProperty("ExpiresOn")]
        public string ExpiresOn;
        [JsonProperty("Scopes")]
        public string Scopes;
        [JsonProperty("TokenType")]
        public string TokenType;
        [JsonProperty("CharacterOwnerHash")]
        public string CharacterOwnerHash;
        [JsonProperty("IntellectualProperty")]
        public string IntellectualProperty;
    }

    public class ESICharacterPublicData
    {
        [JsonProperty("name")]
        public string name;
        [JsonProperty("birthday")]
        public string birthday;
        [JsonProperty("gender")]
        public string gender;
        [JsonProperty("race_id")]
        public int race_id;
        [JsonProperty("description")]
        public string description;
        [JsonProperty("bloodline_id")]
        public int bloodline_id;
        [JsonProperty("ancestry_id")]
        public int ancestry_id;
        [JsonProperty("corporation_id")]
        public int corporation_id;
        [JsonProperty("alliance_id")]
        public int alliance_id;
        [JsonProperty("faction_id")]
        public int faction_id;
        [JsonProperty("security_status")]
        public double security_status;
    }

    #endregion

    #region Character Data Objects

    public class ESICharacterStandingsData
    {
        [JsonProperty("from_id")]
        public long from_id;
        [JsonProperty("from_type")]
        public string from_type;
        [JsonProperty("standing")]
        public double standing;
    }

    public class ESICharacterSkillsBase
    {
        [JsonProperty("skills")]
        public ESICharacterSkillsData[] skills;
        [JsonProperty("total_sp")]
        public int total_sp;
        [JsonProperty("unallocated_sp")]
        public int unallocated_sp;
    }

    public class ESICharacterSkillsData
    {
        [JsonProperty("skill_id")]
        public int skill_id;
        [JsonProperty("skillpoints_in_skill")]
        public int skillpoints_in_skill;
        [JsonProperty("trained_skill_level")]
        public int trained_skill_level;
        [JsonProperty("active_skill_level")]
        public int active_skill_level;
    }

    public class ESIResearchAgent
    {
        [JsonProperty("agent_id")]
        public long agent_id;
        [JsonProperty("skill_type_id")]
        public int skill_type_id;
        [JsonProperty("started_at")]
        public string started_at;
        [JsonProperty("points_per_day")]
        public double points_per_day;
        [JsonProperty("remainder_points")]
        public double remainder_points;
    }

    public class ESICorporationRoles
    {
        [JsonProperty("character_id")]
        public long character_id;
        [JsonProperty("grantable_roles")]
        public List<string> grantable_roles;
        [JsonProperty("grantable_roles_at_base")]
        public List<string> grantable_roles_at_base;
        [JsonProperty("grantable_roles_at_hq")]
        public List<string> grantable_roles_at_hq;
        [JsonProperty("grantable_roles_at_other")]
        public List<string> grantable_roles_at_other;
        [JsonProperty("roles")]
        public List<string> roles;
        [JsonProperty("roles_at_base")]
        public List<string> roles_at_base;
        [JsonProperty("roles_at_hq")]
        public List<string> roles_at_hq;
        [JsonProperty("roles_at_other")]
        public List<string> roles_at_other;
    }

    public class ESIBlueprint
    {
        [JsonProperty("item_id")]
        public long item_id;
        [JsonProperty("type_id")]
        public int type_id;
        [JsonProperty("location_id")]
        public long location_id;
        [JsonProperty("location_flag")]
        public string location_flag;
        [JsonProperty("quantity")]
        public int quantity;
        [JsonProperty("time_efficiency")]
        public int time_efficiency;
        [JsonProperty("material_efficiency")]
        public int material_efficiency;
        [JsonProperty("runs")]
        public int runs;
    }

    public class ESIIndustryJob
    {
        [JsonProperty("job_id")]
        public int job_id;
        [JsonProperty("installer_id")]
        public int installer_id;
        [JsonProperty("facility_id")]
        public long facility_id;
        [JsonProperty("station_id")]
        public long station_id; // Add both but use location id in end
        [JsonProperty("location_id")]
        public long location_id; // Add both but use location ID in the end
        [JsonProperty("activity_id")]
        public int activity_id;
        [JsonProperty("blueprint_id")]
        public long blueprint_id;
        [JsonProperty("blueprint_type_id")]
        public int blueprint_type_id;
        [JsonProperty("blueprint_location_id")]
        public long blueprint_location_id;
        [JsonProperty("output_location_id")]
        public long output_location_id;
        [JsonProperty("runs")]
        public long runs;
        [JsonProperty("cost")]
        public double cost;
        [JsonProperty("licensed_runs")]
        public int licensed_runs;
        [JsonProperty("probability")]
        public double probability;
        [JsonProperty("product_type_id")]
        public int product_type_id;
        [JsonProperty("status")]
        public string status; // [ active, cancelled, delivered, paused, ready, reverted ]
        [JsonProperty("duration")]
        public int duration;
        [JsonProperty("start_date")]
        public string start_date;
        [JsonProperty("end_date")]
        public string end_date;
        [JsonProperty("pause_date")]
        public string pause_date;
        [JsonProperty("completed_date")]
        public string completed_date;
        [JsonProperty("completed_character_id")]
        public int completed_character_id;
        [JsonProperty("successful_runs")]
        public int successful_runs;
    }

    public class ESIAsset
    {
        [JsonProperty("location_flag")]
        public string location_flag;
        [JsonProperty("location_id")]
        public long location_id;
        [JsonProperty("is_singleton")]
        public bool is_singleton;
        [JsonProperty("type_id")]
        public long type_id;
        [JsonProperty("item_id")]
        public double item_id;
        [JsonProperty("location_type")]
        public string location_type;
        [JsonProperty("quantity")]
        public int quantity;
    }

    public class ESICorporation
    {
        [JsonProperty("alliance_id")]
        public int alliance_id;
        [JsonProperty("ceo_id")]
        public int ceo_id;
        [JsonProperty("creator_id")]
        public int creator_id;
        [JsonProperty("date_founded")]
        public string date_founded;
        [JsonProperty("description")]
        public string description;
        [JsonProperty("faction_id")]
        public int faction_id;
        [JsonProperty("home_station_id")]
        public int home_station_id;
        [JsonProperty("member_count")]
        public int member_count;
        [JsonProperty("name")]
        public string name;
        [JsonProperty("shares")]
        public long shares;
        [JsonProperty("tax_rate")]
        public double tax_rate;
        [JsonProperty("ticker")]
        public string ticker;
        [JsonProperty("url")]
        public string url;
    }

    public class ESIUniverseStructure
    {
        [JsonProperty("name")]
        public string name;
        [JsonProperty("owner_id")]
        public int owner_id;
        [JsonProperty("position")]
        public ESIPosition position;
        [JsonProperty("solar_system_id")]
        public int solar_system_id;
        [JsonProperty("type_id")]
        public int type_id;
    }

    public class ESIPostion
    {
        [JsonProperty("x")]
        public double x;
        [JsonProperty("y")]
        public double y;
        [JsonProperty("z")]
        public double z;
    }

    public class ESICharacterAssetName
    {
        [JsonProperty("item_id")]
        public double item_id;
        [JsonProperty("name")]
        public string name;
    }
}

#endregion
