using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public class EVEBlueprints
    {
        private List<EVEBlueprint> BlueprintList;
        private SavedTokenData KeyData;

        public EVEBlueprints()
        {

            BlueprintList = new List<EVEBlueprint>();

        }

        // Loads all blueprints for the character from the DB
        public void LoadBlueprints(long ID, SavedTokenData CharacterTokenData, Public_Variables.ScanType BlueprintType, bool UpdateBPs)
        {
            string SQL;
            SQLiteDataReader readerBlueprints;
            EVEBlueprint TempBlueprint;
            var Blueprints = new List<EVEBlueprint>();

            // Update Industry Blueprints first
            UpdateBlueprints(ID, CharacterTokenData, BlueprintType, UpdateBPs);

            // See what ID we use for character bps
            long CharID = 0L;
            if (SettingsVariables.UserApplicationSettings.LoadBPsbyChar)
            {
                // Use the ID sent
                CharID = Public_Variables.SelectedCharacter.ID;
            }
            else
            {
                CharID = Public_Variables.CommonLoadBPsID;
            }

            // Load the blueprints
            SQL = "SELECT ITEM_ID, LOCATION_ID, BLUEPRINT_ID, BLUEPRINT_NAME, FLAG_ID, QUANTITY, ME, TE, ";
            SQL += "RUNS, BP_TYPE, OWNED, SCANNED, FAVORITE, ADDITIONAL_COSTS ";
            SQL += "FROM OWNED_BLUEPRINTS WHERE USER_ID = " + CharID;

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerBlueprints = Public_Variables.DBCommand.ExecuteReader();

            while (readerBlueprints.Read())
            {

                TempBlueprint.ItemID = readerBlueprints.GetInt64(0);
                TempBlueprint.LocationID = readerBlueprints.GetInt64(1);
                TempBlueprint.TypeID = readerBlueprints.GetInt64(2);
                TempBlueprint.TypeName = readerBlueprints.GetString(3);
                TempBlueprint.FlagID = readerBlueprints.GetInt32(4);
                TempBlueprint.Quantity = readerBlueprints.GetInt32(5);
                TempBlueprint.TimeEfficiency = readerBlueprints.GetInt32(6);
                TempBlueprint.MaterialEfficiency = readerBlueprints.GetInt32(7);
                TempBlueprint.Runs = readerBlueprints.GetInt32(8);
                TempBlueprint.BPType = (Public_Variables.BPType)readerBlueprints.GetInt32(9);
                TempBlueprint.Owned = Conversions.ToBoolean(readerBlueprints.GetInt32(10));
                TempBlueprint.Scanned = Conversions.ToBoolean(readerBlueprints.GetInt32(11));
                TempBlueprint.Favorite = Conversions.ToBoolean(readerBlueprints.GetInt32(12));
                TempBlueprint.AdditionalCosts = readerBlueprints.GetDouble(13);

                // Insert blueprint
                Blueprints.Add(TempBlueprint);

            }

            readerBlueprints.Close();
            Public_Variables.DBCommand = null;
            readerBlueprints = null;

            BlueprintList = Blueprints;

        }

        // Updates Blueprints from ESI for the character/corp and inserts them into the Database for later queries
        private void UpdateBlueprints(long ID, SavedTokenData CharacterTokenData, Public_Variables.ScanType BlueprintType, bool UpdateBPs)
        {
            SQLiteDataReader readerBlueprints;
            SQLiteDataReader readerCheck;
            string SQL;

            var IndyBlueprints = new List<EVEBlueprint>();
            var InsertBP = default(bool);
            bool IgnoreBP;
            int ScannedFlag;

            double MEValue;
            double TEValue;

            var ESIData = new ESI();
            var CB = new CacheBox();
            var CacheDate = default(DateTime);

            CacheDateType CDType;

            if (BlueprintType == Public_Variables.ScanType.Personal)
            {
                CDType = CacheDateType.PersonalBlueprints;
                ScannedFlag = 1;
            }
            else
            {
                CDType = CacheDateType.CorporateBlueprints;
                ScannedFlag = 2;
            }

            // See what ID we save for character bps
            long TempID = 0L;
            if (SettingsVariables.UserApplicationSettings.LoadBPsbyChar | BlueprintType == Public_Variables.ScanType.Corporation)
            {
                // Use the ID sent
                TempID = ID;
            }
            else
            {
                TempID = Public_Variables.CommonLoadBPsID;
            }

            // Look up the industry Blueprints cache date first      
            if (CB.DataUpdateable(CDType, ID))
            {
                IndyBlueprints = ESIData.GetBlueprints(ID, CharacterTokenData, BlueprintType, ref CacheDate);

                if (!(IndyBlueprints == null))
                {
                    if (IndyBlueprints.Count > 0)
                    {
                        Public_Variables.EVEDB.BeginSQLiteTransaction();

                        // First delete all bps for this ID in the 
                        Public_Variables.EVEDB.ExecuteNonQuerySQL("DELETE FROM ALL_OWNED_BLUEPRINTS WHERE OWNER_ID = " + TempID.ToString());

                        // Insert blueprint data
                        for (int i = 0, loopTo = IndyBlueprints.Count - 1; i <= loopTo; i++)
                        {

                            {
                                var withBlock = IndyBlueprints[i];
                                // Load all bps in ALL_OWNED_BLUEPRINTS and only limit OWNED_BLUEPRINTS to single records
                                SQL = "INSERT INTO ALL_OWNED_BLUEPRINTS (OWNER_ID, ITEM_ID, LOCATION_ID, BLUEPRINT_ID, BLUEPRINT_NAME, FLAG_ID, ";
                                SQL += "QUANTITY, ME, TE, RUNS, BP_TYPE) ";
                                SQL += "VALUES (" + TempID.ToString() + "," + withBlock.ItemID.ToString() + "," + withBlock.LocationID.ToString() + ",";
                                SQL += withBlock.TypeID.ToString() + ",'" + Public_Variables.FormatDBString(withBlock.TypeName) + "',";
                                SQL += withBlock.FlagID.ToString() + ",1," + withBlock.MaterialEfficiency.ToString() + "," + withBlock.TimeEfficiency.ToString() + ",";
                                SQL += withBlock.Runs + "," + ((int)withBlock.BPType).ToString() + ")";

                                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

                                // Make sure it's not already in there before adding to owned
                                // For now, only include unique BPs until I get the multiple BP support done - use Max ME for the determination or Max TE if they are the same ME
                                SQL = "SELECT ME, TE, BP_TYPE, ITEM_ID, OWNED, SCANNED FROM OWNED_BLUEPRINTS ";
                                SQL += "WHERE BLUEPRINT_ID = " + withBlock.TypeID + " And USER_ID = " + TempID.ToString();

                                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                                readerBlueprints = Public_Variables.DBCommand.ExecuteReader();
                                readerBlueprints.Read();

                                if (readerBlueprints.HasRows)
                                {

                                    // Do not overwrite anything saved by the user (owned = -1 for user owned, 0 for not owned but favorite/ignore/bptype) 
                                    if (readerBlueprints.GetInt32(4) == 1)
                                    {
                                        MEValue = readerBlueprints.GetInt32(0);
                                        TEValue = readerBlueprints.GetInt32(1);

                                        // If greater ME, or the ME is equal and TE is greater, update it if it's the same type of bp
                                        if (MEValue < IndyBlueprints[i].MaterialEfficiency & readerBlueprints.GetInt32(2) == (int)withBlock.BPType)
                                        {
                                            InsertBP = false;
                                            IgnoreBP = false;
                                        }
                                        else if (MEValue == IndyBlueprints[i].MaterialEfficiency & TEValue < IndyBlueprints[i].TimeEfficiency & readerBlueprints.GetInt32(2) == (int)withBlock.BPType)
                                        {
                                            InsertBP = false;
                                            IgnoreBP = false;
                                        }
                                        else if (readerBlueprints.GetInt32(2) == (int)Public_Variables.BPType.Copy & withBlock.BPType == Public_Variables.BPType.Original) // Only update if the new BP is a BPO
                                        {
                                            InsertBP = false;
                                            IgnoreBP = false;
                                        }
                                        else
                                        {
                                            // We don't want to do anything with this bp
                                            IgnoreBP = true;
                                        }
                                    }
                                    else
                                    {
                                        // We don't want to do anything with this bp
                                        IgnoreBP = true;
                                        InsertBP = false;
                                    }
                                }
                                else
                                {
                                    IgnoreBP = false;
                                    InsertBP = true;
                                }

                                if (!IgnoreBP)
                                {
                                    // Set the correct BP_Type for the BPs they have 
                                    var CurrentBPType = withBlock.BPType;
                                    // If T2 and a copy, set to invented copy if the ME/TE match, else use what was sent
                                    if (CurrentBPType == Public_Variables.BPType.Copy)
                                    {
                                        SQL = "SELECT TECH_LEVEL FROM ALL_BLUEPRINTS WHERE BLUEPRINT_ID = " + withBlock.TypeID.ToString();
                                        Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                                        readerCheck = Public_Variables.DBCommand.ExecuteReader();
                                        if (readerCheck.Read())
                                        {
                                            var TempDecryptorList = new DecryptorList();
                                            var FoundDecryptor = TempDecryptorList.GetDecryptor(withBlock.MaterialEfficiency, withBlock.TimeEfficiency, withBlock.Runs, readerCheck.GetInt32(0));

                                            // If it finds a decryptor, even no decryptor, then set it to invented, else assume it's a copy from a BPO
                                            if (FoundDecryptor.TypeID != 0L | withBlock.MaterialEfficiency == Public_Variables.BaseT2T3ME & withBlock.TimeEfficiency == Public_Variables.BaseT2T3TE)
                                            {
                                                CurrentBPType = Public_Variables.BPType.InventedBPC;
                                            }

                                            readerCheck.Close();
                                        }

                                    }

                                    if (InsertBP)
                                    {
                                        SQL = "INSERT INTO OWNED_BLUEPRINTS (USER_ID, ITEM_ID, LOCATION_ID, BLUEPRINT_ID, BLUEPRINT_NAME, FLAG_ID, ";
                                        SQL += "QUANTITY, ME, TE, RUNS, BP_TYPE, OWNED, SCANNED, FAVORITE, ADDITIONAL_COSTS) ";
                                        SQL += "VALUES (" + TempID.ToString() + "," + withBlock.ItemID.ToString() + "," + withBlock.LocationID.ToString() + ",";
                                        SQL += withBlock.TypeID.ToString() + ",'" + Public_Variables.FormatDBString(withBlock.TypeName) + "',";
                                        SQL += withBlock.FlagID.ToString() + ",1," + withBlock.MaterialEfficiency.ToString() + "," + withBlock.TimeEfficiency.ToString() + ",";
                                        SQL += withBlock.Runs + "," + ((int)CurrentBPType).ToString() + ",1," + ScannedFlag.ToString() + ", 0, 0)";
                                    }
                                    else
                                    {
                                        // Update the BP 
                                        SQL = "UPDATE OWNED_BLUEPRINTS SET ";
                                        SQL += "LOCATION_ID = " + withBlock.LocationID.ToString() + ",";
                                        SQL += "FLAG_ID = " + withBlock.FlagID.ToString() + ",";
                                        SQL += "ME = " + withBlock.MaterialEfficiency.ToString() + ",";
                                        SQL += "TE = " + withBlock.TimeEfficiency.ToString() + ",";
                                        SQL += "RUNS = " + withBlock.Runs.ToString() + ",";
                                        SQL += "QUANTITY = 1,"; // Helps determine copies (-2), bpos (-1), or stacks of BPO's (any number), 
                                                                // but we will set for 1 now and later the total of BPS with the same ME/TE

                                        // Also reset the unqiue itemid
                                        SQL += "ITEM_ID = " + withBlock.ItemID.ToString() + ",";
                                        // Could go from a copy to orginial (with single bp loading, will change with multi)
                                        SQL += "BP_TYPE = " + ((int)CurrentBPType).ToString() + ",";
                                        // Mark all from ESI as owned
                                        SQL += "OWNED = 1,";
                                        SQL += "BLUEPRINT_NAME = '" + Public_Variables.FormatDBString(withBlock.TypeName) + "', "; // If it changes
                                        SQL += "SCANNED = " + ScannedFlag + " ";

                                        if (readerBlueprints.GetInt64(3) != 0L)
                                        {
                                            // Search with ITEM_ID
                                            SQL += "WHERE ITEM_ID = " + readerBlueprints.GetInt64(3).ToString() + " AND USER_ID = " + TempID.ToString();
                                        }
                                        else
                                        {
                                            // Search with the ID of the bp and the user ID - they must have saved this manually
                                            SQL += "WHERE BLUEPRINT_ID = " + withBlock.TypeID + " AND USER_ID = " + TempID.ToString();
                                        }

                                    }

                                    readerBlueprints.Close();

                                    Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);
                                }

                            }
                        }

                        Public_Variables.DBCommand = null;

                        Public_Variables.EVEDB.CommitSQLiteTransaction();

                    }

                    // Update cache date now that it's all set
                    CB.UpdateCacheDate(CDType, CacheDate, ID);

                }
            }

        }

    }

    // For outputing lists of blueprints
    public struct EVEBlueprint
    {
        public long ItemID;
        public long LocationID;
        public long TypeID;
        public string TypeName;
        public int FlagID;
        public int Quantity;
        public int TimeEfficiency;
        public int MaterialEfficiency;
        public int Runs;
        public Public_Variables.BPType BPType;
        public bool Owned;
        public bool Scanned;
        public bool Favorite;
        public double AdditionalCosts;
    }
}