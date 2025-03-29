using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace EVE_Isk_per_Hour
{

    public class Corporation
    {

        public string Name; // Corp name
        public long CorporationID; // Corp ID
        public string Ticker;
        public int FactionID;
        public int AllianceID;
        public long CEOID;
        public long CreatorID;
        public int HomeStationID;
        public long Shares;
        public int MemberCount;
        public string Description;
        public double TaxRate;
        public DateTime DateFounded;
        public string URL;

        private EVEAssets Assets;
        public bool AssetAccess;
        private EVEBlueprints Blueprints;
        public bool BlueprintsAccess;
        private EVEIndustryJobs Jobs;
        public bool JobsAccess;

        public Corporation()
        {

            AssetAccess = false;
            BlueprintsAccess = false;
            JobsAccess = false;

            Assets = new EVEAssets();
            Blueprints = new EVEBlueprints();
            Jobs = new EVEIndustryJobs();

        }

        // Loads the corporation data from token information sent
        public void LoadCorporationData(long CorpID, SavedTokenData CharacterTokenData, bool RefreshAssets, bool RefreshBlueprints, bool ResetData = true)
        {
            string SQL;
            SQLiteDataReader rsData;
            var CorpRoles = new List<string>();

            // Get the public data about corporation and update it
            UpdateCorporationData(CorpID);

            // Load up all the data for the corporation
            SQL = "SELECT * FROM ESI_CORPORATION_DATA WHERE CORPORATION_ID = " + CorpID;

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            rsData = Public_Variables.DBCommand.ExecuteReader();

            while (rsData.Read())
            {
                // Save data
                CorporationID = CorpID;
                Name = rsData.GetString(1);
                Ticker = rsData.GetString(2);
                MemberCount = rsData.GetInt32(3);
                FactionID = Public_Variables.FormatNullInteger(rsData.GetValue(4));
                AllianceID = Public_Variables.FormatNullInteger(rsData.GetValue(5));
                CEOID = rsData.GetInt32(6);
                CreatorID = rsData.GetInt32(7);
                HomeStationID = Public_Variables.FormatNullInteger(rsData.GetValue(8));
                Shares = Public_Variables.FormatNullLong(rsData.GetValue(9));
                TaxRate = rsData.GetDouble(10);
                Description = Public_Variables.FormatNullString(rsData.GetValue(11));
                DateFounded = Public_Variables.FormatNullDate(rsData.GetValue(12));
                URL = Public_Variables.FormatNullString(rsData.GetValue(13));
            }

            rsData.Close();

            bool FactoryManager = false;
            bool Director = false;

            // See what permissions we have access to in the corporation for this character and only query those we can see
            if (CharacterTokenData.Scopes.Contains(ESI.ESICorporationMembership))
            {
                var CharacterCorpRoles = GetCorporationRoles(CorporationID, CharacterTokenData);

                foreach (var Role in CharacterCorpRoles)
                {
                    switch (Role ?? "")
                    {
                        case "Factory_Manager":
                            {
                                FactoryManager = true;
                                break;
                            }
                        case "Director":
                            {
                                Director = true;
                                break;
                            }
                    }
                }
            }

            // Industry Jobs - needs FactoryManager role
            if (CharacterTokenData.Scopes.Contains(ESI.ESICorporationIndustryJobsScope) & FactoryManager)
            {
                JobsAccess = true;
                if (ResetData)
                {
                    Jobs = new EVEIndustryJobs();
                    Jobs.LoadIndustryJobs(CorporationID, CharacterTokenData, Public_Variables.ScanType.Corporation); // use character ID because only characters can install jobs
                }
            }

            // Blueprints - needs Director role
            if (CharacterTokenData.Scopes.Contains(ESI.ESICorporationBlueprintsScope) & Director)
            {
                BlueprintsAccess = true;
                if (ResetData)
                {
                    Blueprints = new EVEBlueprints();
                    Blueprints.LoadBlueprints(CorporationID, CharacterTokenData, Public_Variables.ScanType.Corporation, RefreshBlueprints);
                }
            }

            // Assets - needs Director role
            if (CharacterTokenData.Scopes.Contains(ESI.ESICorporationAssetScope) & Director)
            {
                AssetAccess = true;
                if (ResetData)
                {
                    Assets = new EVEAssets(Public_Variables.ScanType.Corporation);
                    Assets.LoadAssets(CorporationID, CharacterTokenData, RefreshAssets);
                }
            }

        }

        // Updates the public informaton about the corporation in DB. 
        private void UpdateCorporationData(long CorporationID)
        {
            var ESIData = new ESI();
            var CB = new CacheBox();
            var CacheDate = default(DateTime);

            // Update the corp data if we can
            if (CB.DataUpdateable(CacheDateType.PublicCorporationData, CorporationID))
            {
                ESIData.SetCorporationData(CorporationID, ref CacheDate);
                // Update after we update/insert the record
                CB.UpdateCacheDate(CacheDateType.PublicCorporationData, CacheDate, CorporationID);
            }

        }

        // Loads the dummy corporation into the dummy character
        public void LoadDummyCorporationData()
        {
            string SQL = "";

            // Delete the dummy information if in there
            Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format("DELETE FROM ESI_CORPORATION_DATA WHERE CORPORATION_ID = {0}", Public_Variables.DummyCorporationID));

            // Load the variables
            CorporationID = Public_Variables.DummyCorporationID;
            Name = Public_Variables.None;
            Ticker = Public_Variables.None;
            MemberCount = 1;
            FactionID = 0;
            AllianceID = 0;
            CEOID = 0L;
            CreatorID = 0L;
            HomeStationID = 0;
            Shares = 0L;
            TaxRate = 0d;
            Description = "";
            DateFounded = Public_Variables.NoDate;
            URL = "";

            SQL = "INSERT INTO ESI_CORPORATION_DATA VALUES (";
            SQL += Public_Variables.BuildInsertFieldString(CorporationID) + ",";
            SQL += Public_Variables.BuildInsertFieldString(Name) + ",";
            SQL += Public_Variables.BuildInsertFieldString(Ticker) + ",";
            SQL += Public_Variables.BuildInsertFieldString(MemberCount) + ",";
            SQL += Public_Variables.BuildInsertFieldString(FactionID) + ",";
            SQL += Public_Variables.BuildInsertFieldString(AllianceID) + ",";
            SQL += Public_Variables.BuildInsertFieldString(CEOID) + ",";
            SQL += Public_Variables.BuildInsertFieldString(CreatorID) + ",";
            SQL += Public_Variables.BuildInsertFieldString(HomeStationID) + ",";
            SQL += Public_Variables.BuildInsertFieldString(Shares) + ",";
            SQL += Public_Variables.BuildInsertFieldString(TaxRate) + ",";
            SQL += Public_Variables.BuildInsertFieldString(Description) + ",";
            SQL += Public_Variables.BuildInsertFieldString(Public_Variables.NoDate) + ",";
            SQL += Public_Variables.BuildInsertFieldString(URL) + ",";
            SQL += Public_Variables.BuildInsertFieldString(Public_Variables.NoExpiry) + ","; // Set this here too to stop calls to update dummy corp through ESI
            SQL += Public_Variables.BuildInsertFieldString(Public_Variables.NoExpiry) + ",";
            SQL += Public_Variables.BuildInsertFieldString(Public_Variables.NoExpiry) + ",";
            SQL += Public_Variables.BuildInsertFieldString(Public_Variables.NoExpiry) + ",";
            SQL += Public_Variables.BuildInsertFieldString(Public_Variables.NoExpiry) + ")";

            // Insert the dummy corp
            Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

        }

        public List<string> GetCorporationRoles(long CorporationID, SavedTokenData TokenData)
        {
            var RoleESI = new ESI();
            List<ESICorporationRoles> RoleData;
            var ReturnRoles = new List<string>();
            var CB = new CacheBox();
            var CacheDate = default(DateTime);

            SQLiteDataReader rsRoles;
            string SQL = "";

            if (CB.DataUpdateable(CacheDateType.CorporateRoles, CorporationID))
            {
                // Get all the roles for all characters in corporation. Note, the roles can only be pulled for a character with personnel manager
                RoleData = RoleESI.GetCorporationRoles(TokenData.CharacterID, CorporationID, TokenData, ref CacheDate);

                // Delete current role data and update
                Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format("DELETE FROM ESI_CORPORATION_ROLES WHERE CORPORATION_ID = {0} AND CHARACTER_ID = {1}", CorporationID, TokenData.CharacterID));

                if (!(RoleData == null))
                {
                    Public_Variables.EVEDB.BeginSQLiteTransaction();
                    // Check roles - for places they can carry out the role
                    // Grantable is that they can give the role to others
                    foreach (var Character in RoleData)
                    {
                        // Insert only role data (read access) for later checks
                        foreach (var Role in Character.roles)
                            Public_Variables.EVEDB.ExecuteNonQuerySQL(string.Format("INSERT INTO ESI_CORPORATION_ROLES VALUES ({0}, {1},'{2}','Roles')", CorporationID, Character.character_id, Public_Variables.FormatDBString(Role)));
                    }
                    Public_Variables.EVEDB.CommitSQLiteTransaction();
                }
                CB.UpdateCacheDate(CacheDateType.CorporateRoles, CacheDate, CorporationID);
            }

            // Look up roles for the character sent in DB
            SQL = "SELECT ROLE FROM ESI_CORPORATION_ROLES WHERE CORPORATION_ID = {0} AND CHARACTER_ID = {1}";
            Public_Variables.DBCommand = new SQLiteCommand(string.Format(SQL, CorporationID, TokenData.CharacterID), Public_Variables.EVEDB.DBREf());
            rsRoles = Public_Variables.DBCommand.ExecuteReader();

            while (rsRoles.Read())
                ReturnRoles.Add(rsRoles.GetString(0));

            rsRoles.Close();

            return ReturnRoles;

        }

        public EVEIndustryJobs GetIndustryJobs()
        {
            return Jobs;
        }

        public EVEAssets GetAssets()
        {
            return Assets;
        }

        public EVEBlueprints GetBlueprints()
        {
            return Blueprints;
        }

    }
}