using System;
using System.Data.SQLite;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    public class CacheBox
    {

        private struct CacheData
        {
            public string FieldName;
            public string TableName;
            public string IDName;
        }

        // Updates the database with the cache date for the type sent
        public void UpdateCacheDate(CacheDateType UpdateCacheType, DateTime SentDate, long CharacterID = 0L)
        {
            string SQL;
            CacheData UpdateInfo;

            UpdateInfo = GetCacheUpdateInfo(UpdateCacheType);

            // If we don't have a record in the public cache dates, add one
            if (UpdateInfo.TableName == "ESI_PUBLIC_CACHE_DATES")
            {
                SQLiteDataReader rsCheck;
                Public_Variables.DBCommand = new SQLiteCommand("SELECT * FROM ESI_PUBLIC_CACHE_DATES", Public_Variables.EVEDB.DBREf());
                rsCheck = Public_Variables.DBCommand.ExecuteReader();

                if (!rsCheck.HasRows)
                {
                    // Insert a record
                    Public_Variables.EVEDB.ExecuteNonQuerySQL("INSERT INTO ESI_PUBLIC_CACHE_DATES VALUES (NULL,NULL,NULL,NULL,NULL)");
                }
                rsCheck.Close();
            }

            if (!string.IsNullOrEmpty(UpdateInfo.FieldName))
            {
                // Update the cache date
                SQL = string.Format("UPDATE {0} SET {1} = '" + Strings.Format(SentDate, Public_Variables.SQLiteDateFormat) + "'", UpdateInfo.TableName, UpdateInfo.FieldName);
                if (!string.IsNullOrEmpty(UpdateInfo.IDName))
                {
                    SQL = string.Format(SQL + " WHERE {0} = {1}", UpdateInfo.IDName, CharacterID);
                }

                Public_Variables.EVEDB.ExecuteNonQuerySQL(SQL);

            }

        }

        public bool DataUpdateable(CacheDateType UpdateCacheType, long CharacterID = 0L)
        {
            string SQL;
            SQLiteDataReader rsDate;
            CacheData UpdateInfo;

            UpdateInfo = GetCacheUpdateInfo(UpdateCacheType);

            if (!string.IsNullOrEmpty(UpdateInfo.FieldName))
            {
                SQL = string.Format("SELECT {0} FROM {1}", UpdateInfo.FieldName, UpdateInfo.TableName);

                if (!string.IsNullOrEmpty(UpdateInfo.IDName))
                {
                    SQL = string.Format(SQL + " WHERE {0} = {1}", UpdateInfo.IDName, CharacterID);
                }

                Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
                rsDate = Public_Variables.DBCommand.ExecuteReader();

                if (rsDate.Read())
                {
                    if (!(rsDate.GetValue(0) is DBNull))
                    {
                        if (Conversions.ToDate(rsDate.GetString(0)) <= DateTime.UtcNow)
                        {
                            return true; // Time to update
                        }
                        else
                        {
                            return false;
                        } // Don't update yet

                    }
                }
                rsDate.Close();
            }

            return true; // Always update if we don't have a date

        }

        private CacheData GetCacheUpdateInfo(CacheDateType CacheType)
        {
            CacheData ReturnData;

            switch (CacheType)
            {
                case CacheDateType.Skills:
                    {
                        ReturnData.FieldName = "SKILLS_CACHE_DATE";
                        break;
                    }
                case CacheDateType.Standings:
                    {
                        ReturnData.FieldName = "STANDINGS_CACHE_DATE";
                        break;
                    }
                case CacheDateType.ResearchAgents:
                    {
                        ReturnData.FieldName = "RESEARCH_AGENTS_CACHE_DATE";
                        break;
                    }
                case CacheDateType.PersonalBlueprints:
                    {
                        ReturnData.FieldName = "BLUEPRINTS_CACHE_DATE";
                        break;
                    }
                case CacheDateType.PersonalAssets:
                    {
                        ReturnData.FieldName = "ASSETS_CACHE_DATE";
                        break;
                    }
                case CacheDateType.PersonalIndyJobs:
                    {
                        ReturnData.FieldName = "INDUSTRY_JOBS_CACHE_DATE";
                        break;
                    }
                case CacheDateType.CorporateBlueprints:
                    {
                        ReturnData.FieldName = "BLUEPRINTS_CACHE_DATE";
                        break;
                    }
                case CacheDateType.CorporateAssets:
                    {
                        ReturnData.FieldName = "ASSETS_CACHE_DATE";
                        break;
                    }
                case CacheDateType.CorporateIndyJobs:
                    {
                        ReturnData.FieldName = "INDUSTRY_JOBS_CACHE_DATE";
                        break;
                    }
                case CacheDateType.PublicCharacterData:
                    {
                        ReturnData.FieldName = "PUBLIC_DATA_CACHE_DATE";
                        break;
                    }
                case CacheDateType.PublicCorporationData:
                    {
                        ReturnData.FieldName = "PUBLIC_DATA_CACHE_DATE";
                        break;
                    }
                case CacheDateType.IndustrySystems:
                    {
                        ReturnData.FieldName = "INDUSTRY_SYSTEMS_CACHED_UNTIL";
                        break;
                    }
                case CacheDateType.MarketPrices:
                    {
                        ReturnData.FieldName = "MARKET_PRICES_CACHED_UNTIL";
                        break;
                    }
                case CacheDateType.PublicStructures:
                    {
                        ReturnData.FieldName = "PUBLIC_STRUCTURES_CACHED_UNTIL";
                        break;
                    }
                case CacheDateType.CorporateRoles:
                    {
                        ReturnData.FieldName = "CORP_ROLES_CACHE_DATE";
                        break;
                    }
                case CacheDateType.ESIStatus:
                    {
                        ReturnData.FieldName = "PUBLIC_ESI_STATUS_CACHED_UNTIL";
                        break;
                    }

                default:
                    {
                        ReturnData.FieldName = "";
                        break;
                    }
            }

            switch (CacheType)
            {
                case CacheDateType.CorporateAssets:
                case CacheDateType.CorporateBlueprints:
                case CacheDateType.CorporateIndyJobs:
                case CacheDateType.PublicCorporationData:
                case CacheDateType.CorporateRoles:
                    {
                        ReturnData.TableName = "ESI_CORPORATION_DATA";
                        ReturnData.IDName = "CORPORATION_ID";
                        break;
                    }
                case CacheDateType.IndustryFacilities:
                case CacheDateType.IndustrySystems:
                case CacheDateType.MarketPrices:
                case CacheDateType.PublicStructures:
                case CacheDateType.ESIStatus:
                    {
                        ReturnData.TableName = "ESI_PUBLIC_CACHE_DATES";
                        ReturnData.IDName = "";
                        break;
                    }

                default:
                    {
                        ReturnData.TableName = "ESI_CHARACTER_DATA";
                        ReturnData.IDName = "CHARACTER_ID";
                        break;
                    }
            }

            return ReturnData;

        }

    }

    public enum CacheDateType
    {
        Skills = 0,
        Standings = 1,
        ResearchAgents = 2,
        PersonalBlueprints = 3,
        PersonalAssets = 4,
        PersonalIndyJobs = 5,

        CorporateRoles = 14,
        CorporateBlueprints = 6,
        CorporateAssets = 7,
        CorporateIndyJobs = 8,

        PublicCharacterData = 9,
        PublicCorporationData = 10,

        // Public Cache dates
        IndustrySystems = 11,
        IndustryFacilities = 12,
        MarketPrices = 13,
        PublicStructures = 15,
        ESIStatus = 16

    }
}