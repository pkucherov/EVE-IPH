using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace EVE_Isk_per_Hour
{

    // List of decryptors for use in Manufacturing tab
    public class DecryptorList
    {

        private List<Decryptor> Decryptors = new List<Decryptor>();
        private int RaceID;
        private Decryptor DecryptortoFind = new Decryptor();

        // All decryptors are merged with pheobe
        public DecryptorList()
        {
            SQLiteDataReader readerDecryptor;
            string SQL;

            SQL = "SELECT typeName, groupID FROM INVENTORY_TYPES WHERE groupID = 1304"; // Only one Decryptor Group with Pheobe

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerDecryptor = Public_Variables.DBCommand.ExecuteReader();

            while (readerDecryptor.Read())
                LoadRacialDecryptor(readerDecryptor.GetString(0));

            readerDecryptor.Close();

        }

        // Function will return a decryptor of group and multiplier that is in the list, if not returns no decryptor
        public Decryptor GetDecryptor(double ProbabilityMult)
        {
            int i;

            var loopTo = Decryptors.Count - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (Decryptors[i].ProductionMod == ProbabilityMult)
                {
                    return Decryptors[i];
                }
            }

            return DecryptorVariables.NoDecryptor;

        }

        // Function returns the full decryptor for the name sent
        public Decryptor GetDecryptor(string DecryptorName)
        {
            int i;

            var loopTo = Decryptors.Count - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if ((Decryptors[i].Name ?? "") == (DecryptorName ?? ""))
                {
                    return Decryptors[i];
                }
            }

            return DecryptorVariables.NoDecryptor;

        }

        // Returns the list of decryptors
        public List<Decryptor> GetDecryptorList()
        {
            return Decryptors;
        }

        // Function returns the decryptor for the ME/TE/Runs values sent
        public Decryptor GetDecryptor(int BPME, int BPTE, int BPRuns, int TechLevel, double ProbabilityModifier = -1)
        {

            var RunsModifier = default(int);
            int MEModifier = BPME - Public_Variables.BaseT2T3ME;
            int TEModifier = BPTE - Public_Variables.BaseT2T3TE;

            if (MEModifier == -2 & TEModifier == 2)
            {
                // We used the decryptor with max run modifier of 9 (hardcode to get around the decryptor with 9 extra runs for 1 run bpcs, which then makes 10 and is the same as the base for modules)
                RunsModifier = 9;
            }
            else if (TechLevel == 2)
            {
                // Either ships or modules
                if (BPRuns >= 10)
                {
                    RunsModifier = BPRuns - 10;
                }
                else
                {
                    RunsModifier = BPRuns - 1;
                }
            }
            else if (TechLevel == 3)
            {
                if (BPRuns >= 3)
                {
                    // Wrecked
                    RunsModifier = BPRuns - 3;
                }
                else if (BPRuns >= 10)
                {
                    // Malfunctioning
                    RunsModifier = BPRuns - 10;
                }
                else if (BPRuns >= 20)
                {
                    // Intact
                    RunsModifier = BPRuns - 20;
                }
            }

            for (int i = 0, loopTo = Decryptors.Count - 1; i <= loopTo; i++)
            {
                {
                    var withBlock = Decryptors[i];
                    if (withBlock.MEMod == MEModifier & withBlock.TEMod == TEModifier & withBlock.RunMod == RunsModifier & Conversions.ToBoolean(Interaction.IIf(ProbabilityModifier != -1, withBlock.ProductionMod == ProbabilityModifier, true)))
                    {
                        return Decryptors[i];
                    }
                }
            }

            // If still not found, look for just ME and TE
            for (int i = 0, loopTo1 = Decryptors.Count - 1; i <= loopTo1; i++)
            {
                {
                    var withBlock1 = Decryptors[i];
                    if (withBlock1.MEMod == MEModifier & withBlock1.TEMod == TEModifier)
                    {
                        return Decryptors[i];
                    }
                }
            }

            return DecryptorVariables.NoDecryptor;

        }

        // Loads the racial decryptor into the class array list
        private void LoadRacialDecryptor(string DecryptorName)
        {
            SQLiteDataReader readerDecryptor;
            string SQL;
            var TempDecryptor = new Decryptor();

            // Set the Decryptor first
            SQL = "SELECT INVENTORY_TYPES.typeID, attributeID, value ";
            SQL += "FROM INVENTORY_TYPES, TYPE_ATTRIBUTES ";
            SQL += "WHERE TYPE_ATTRIBUTES.typeID = INVENTORY_TYPES.typeID ";
            SQL += "AND INVENTORY_TYPES.typeName = '" + DecryptorName + "'";

            Public_Variables.DBCommand = new SQLiteCommand(SQL, Public_Variables.EVEDB.DBREf());
            readerDecryptor = Public_Variables.DBCommand.ExecuteReader();

            if (!(readerDecryptor == null))
            {
                TempDecryptor.Name = DecryptorName;
                while (readerDecryptor.Read())
                {
                    TempDecryptor.TypeID = readerDecryptor.GetInt64(0);

                    switch (readerDecryptor.GetInt32(1))
                    {
                        case 1112:
                            {
                                TempDecryptor.ProductionMod = readerDecryptor.GetDouble(2);
                                break;
                            }
                        case 1113:
                            {
                                TempDecryptor.MEMod = (int)Math.Round(readerDecryptor.GetDouble(2));
                                break;
                            }
                        case 1114:
                            {
                                TempDecryptor.TEMod = (int)Math.Round(readerDecryptor.GetDouble(2));
                                break;
                            }
                        case 1124:
                            {
                                TempDecryptor.RunMod = (int)Math.Round(readerDecryptor.GetDouble(2));
                                break;
                            }
                    }
                }

                // Insert the decryptor into the main list
                Decryptor FoundDecryptor;
                DecryptortoFind = TempDecryptor;
                FoundDecryptor = Decryptors.Find(FindDecryptor);

                if (FoundDecryptor is null)
                {
                    Decryptors.Add(TempDecryptor);
                }

            }

            readerDecryptor.Close();

        }

        // Predicate for finding an item in the profit list
        private bool FindDecryptor(Decryptor Mat)
        {
            if ((Mat.Name ?? "") == (DecryptortoFind.Name ?? "") & Mat.TypeID == DecryptortoFind.TypeID & Mat.MEMod == DecryptortoFind.MEMod & Mat.RunMod == DecryptortoFind.RunMod & Mat.ProductionMod == DecryptortoFind.ProductionMod)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public class Decryptor
    {
        public string Name;
        public long TypeID;
        public int MEMod;
        public int TEMod;
        public int RunMod;
        public double ProductionMod;

        public Decryptor()
        {
            Name = "None";
            TypeID = 0L;
            MEMod = 0;
            TEMod = 0;
            RunMod = 0;
            ProductionMod = 1.0d;
        }
    }

    public static class DecryptorVariables
    {
        // Set the dummy decryptor in case one not entered or we don't want to send one when one entered
        public static Decryptor NoDecryptor = new Decryptor();
    }
}