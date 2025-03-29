using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    // Stores a list of materials and associated functions
    public class Materials : ICloneable
    {

        // The List of Materials
        private List<Material> MaterialList;

        // Total Cost of materials in the list
        private double TotalMaterialsCost;
        // Total Volume of materials in the list
        private double TotalMaterialsVolume;

        private Material MaterialtoFind;

        // Constructor
        public Materials()
        {
            TotalMaterialsCost = 0d;
            TotalMaterialsVolume = 0d;

            MaterialList = new List<Material>();
        }

        // For doing a deep copy of Materials
        public object Clone()
        {
            var CopyOfMe = new Materials();
            Material TempMat;

            if (!(MaterialList == null))
            {
                for (int i = 0, loopTo = MaterialList.Count - 1; i <= loopTo; i++)
                {
                    TempMat = (Material)MaterialList[i].Clone();
                    CopyOfMe.InsertMaterial(TempMat);
                }
            }
            else
            {
                CopyOfMe.MaterialList = null;
            }

            CopyOfMe.TotalMaterialsCost = TotalMaterialsCost;
            CopyOfMe.TotalMaterialsVolume = TotalMaterialsVolume;

            return CopyOfMe;

        }

        // Resets the List
        public void Clear()
        {
            TotalMaterialsCost = 0d;
            TotalMaterialsVolume = 0d;

            MaterialList = null;
        }

        // Searches the list and finds then returns a material for the name part sent
        public Material SearchListbyName(string SearchText, bool ExactSearch = true)
        {

            if (!(MaterialList == null))
            {
                for (int i = 0, loopTo = MaterialList.Count - 1; i <= loopTo; i++)
                {
                    if (ExactSearch)
                    {
                        if ((MaterialList[i].GetMaterialName() ?? "") == (SearchText ?? ""))
                        {
                            return MaterialList[i];
                        }
                    }
                    else if (Strings.InStr(MaterialList[i].GetMaterialName(), SearchText) != 0) // Look for partial string
                    {
                        return MaterialList[i];
                    }
                }
            }

            return null;

        }

        // Just adds a Full list to the Class
        public void InsertMaterialList(List<Material> SentList)
        {
            int i;

            if (!(SentList == null))
            {
                var loopTo = SentList.Count - 1;
                for (i = 0; i <= loopTo; i++)
                    // clone each or it inserts a reference, which will link to others like it when searched
                    InsertMaterial(SentList[i]);
            }

        }

        // Removes a full list of materials from the list
        public void RemoveMaterialList(List<Material> SentList)
        {
            int i;

            if (!(SentList == null))
            {
                var loopTo = SentList.Count - 1;
                for (i = 0; i <= loopTo; i++)
                    RemoveMaterial(SentList[i]);
            }

        }

        // Inserts a Single material into list
        public void InsertMaterial(Material SentMaterial, double OverrideCost = -1)
        {
            Material TempMat;
            Material CloneMat;

            // Make sure they send a valid material
            if (SentMaterial == null)
            {
                return;
            }

            CloneMat = (Material)SentMaterial.Clone();

            // Find the item
            MaterialtoFind = CloneMat;
            TempMat = MaterialList.Find(FindMaterial);

            if (TempMat is not null)
            {
                // Remove the mat, and update the temp quantity to save later
                MaterialList.Remove(TempMat);
                TempMat.AddQuantity(CloneMat.GetQuantity());
            }
            else
            {
                TempMat = CloneMat;
            }

            if (OverrideCost != -1)
            {
                TempMat.SetTotalCost(OverrideCost);
            }

            // Add the material and update totals
            MaterialList.Add(TempMat);

            // Update the total cost of the class
            TotalMaterialsCost = TotalMaterialsCost + CloneMat.GetTotalCost();

            // Update the total material volume for the list
            TotalMaterialsVolume = TotalMaterialsVolume + CloneMat.GetTotalVolume();

        }

        // Multiplies the quantity of each material in the list by the sent multiple
        public void MultiplyMaterials(int SentMultiple)
        {

            if (SentMultiple <= 1)
            {
                return;
            }

            // See if the material is in the list
            if (!(MaterialList == null))
            {
                // Reset the totals
                TotalMaterialsCost = 0d;
                TotalMaterialsVolume = 0d;
                for (int i = 0, loopTo = MaterialList.Count - 1; i <= loopTo; i++)
                {
                    // Loop through and multiply everything
                    MaterialList[i].AddQuantity(MaterialList[i].GetQuantity() * SentMultiple);
                    // Update the totals
                    TotalMaterialsCost = TotalMaterialsCost + MaterialList[i].GetTotalCost();
                    TotalMaterialsVolume = TotalMaterialsVolume + MaterialList[i].GetTotalVolume();
                }
            }

        }

        // Removes a Single material from the list
        public void RemoveMaterial(Material SentMaterial)
        {
            Material TempMat;

            // Make sure they send a valid material
            if (SentMaterial == null)
            {
                return;
            }

            // Find the item and remove it from the list
            MaterialtoFind = SentMaterial;
            TempMat = MaterialList.Find(FindMaterial);

            if (TempMat is not null)
            {
                // Remove from list first
                MaterialList.Remove(TempMat);
                // If the quantity is not the same, then update the temp and re-add
                if (TempMat.GetQuantity() != SentMaterial.GetQuantity())
                {
                    // Just update quantity (negative to remove), material function will update volume and cost
                    TempMat.AddQuantity(-1 * SentMaterial.GetQuantity());
                    // Add it back
                    MaterialList.Add(TempMat);
                }
            }

            // Update the total cost of the class
            TotalMaterialsCost = TotalMaterialsCost - SentMaterial.GetTotalCost();

            // Update the total material volume for the list
            TotalMaterialsVolume = TotalMaterialsVolume - SentMaterial.GetTotalVolume();

        }

        // Resets the value of the list to the sent value
        public void ResetTotalValue(double TotalValue)
        {
            TotalMaterialsCost = TotalValue;
        }

        // Adds value to the total value of the list 
        public void AddTotalValue(double TotalValue)
        {
            TotalMaterialsCost = TotalMaterialsCost + TotalValue;
        }

        // Adds volume to the total volume of the list
        public void AddTotalVolume(double TotalVolume)
        {
            TotalMaterialsVolume = TotalMaterialsVolume + TotalVolume;
        }

        // "Adds" taxes to the total materials - i.e. takes off the taxes for selling these materials
        public void AdjustTaxedPrice(double TotalTax)
        {
            TotalMaterialsCost = TotalMaterialsCost - TotalTax;
        }

        // Returns the list of Materials
        public List<Material> GetMaterialList()
        {
            return MaterialList;
        }

        // Sorts the Materials by quantity decending (Add more options later)
        public void SortMaterialListByQuantity()
        {
            if (!(MaterialList == null))
            {
                if (MaterialList.Count - 1 > 0)
                {
                    // Sort the list by quantity
                    SortListDesc(MaterialList, 0, MaterialList.Count - 1);
                }
            }
        }

        // Returns the list in a clipboard format with CSV as an option - Include ME will include both the ME and the num Bps
        public string GetClipboardList(string ExportTextFormat, bool IgnorePriceVolume, bool IncludeME, bool IncludeDecryptorRelic, bool IncludeLinks, bool IncludeRunsonName = false)
        {
            string GetClipboardListRet = default;
            int i;
            string OutputString;
            string MatName;
            string DataInterfaces = "";
            string OutputME;
            string RelicDecryptorText = "";
            string NumBps = "";
            string Location = "";
            string Separator = "";

            string BuildMaterialFieldsCSV = "ME, NumBPs, Decryptor/Relic, ";
            string BuildMaterialFieldsSSV = "ME, NumBPs, Decryptor/Relic, ";

            if (!(MaterialList == null))
            {

                switch (ExportTextFormat ?? "")
                {
                    case Public_Variables.CSVDataExport:
                        {
                            Separator = ", ";
                            OutputString = "Material, Quantity, ";
                            if (IncludeME)
                            {
                                OutputString = OutputString + "ME, NumBPs, ";
                            }
                            if (IncludeDecryptorRelic)
                            {
                                OutputString = OutputString + "Decryptor/Relic, ";
                            }
                            OutputString = OutputString + "Cost Per Item, Total Cost, Location" + Constants.vbCrLf;
                            break;
                        }

                    case Public_Variables.SSVDataExport:
                        {
                            Separator = "; ";
                            OutputString = "Material; Quantity; ";
                            if (IncludeME)
                            {
                                OutputString = OutputString + "ME; NumBPs; ";
                            }
                            if (IncludeDecryptorRelic)
                            {
                                OutputString = OutputString + "Decryptor/Relic; ";
                            }
                            OutputString = OutputString + "Cost Per Item; Total Cost; Location" + Constants.vbCrLf;
                            break;
                        }
                    case Public_Variables.MultiBuyDataExport:
                        {
                            OutputString = ""; // no header
                                               // Default
                            break;
                        }

                    default:
                        {
                            OutputString = "Material - Quantity" + Constants.vbCrLf;
                            break;
                        }
                }

                // Loop through all materials
                var loopTo = MaterialList.Count - 1;
                for (i = 0; i <= loopTo; i++)
                {

                    if (IncludeLinks & (ExportTextFormat ?? "") != Public_Variables.MultiBuyDataExport)
                    {
                        // Format so users can link in game
                        // <a href=showinfo:3348>Warfare Link</a> modules
                        MatName = "<a href=showinfo:" + MaterialList[i].GetMaterialTypeID() + ">" + MaterialList[i].GetMaterialName() + "</a>";
                    }
                    else if (IncludeRunsonName)
                    {
                        MatName = MaterialList[i].GetMaterialName();
                    }
                    else
                    {
                        MatName = Public_Variables.RemoveItemNameRuns(MaterialList[i].GetMaterialName());
                    }

                    if (MaterialList[i].GroupName.Contains("|"))
                    {
                        // We have a material from the shopping list, with three values in the material group
                        // .BuildType & "|" & .DecryptorRelic & "|" & .NumBPs & "|" & .Location
                        // Parse the fields
                        string[] ItemColumns = MaterialList[i].GroupName.Split(new char[] { '|' });

                        if ((ItemColumns[1] ?? "") != Public_Variables.None & !string.IsNullOrEmpty(ItemColumns[1]))
                        {
                            RelicDecryptorText = ItemColumns[1];
                        }
                        else
                        {
                            RelicDecryptorText = Public_Variables.None;
                        }

                        NumBps = ItemColumns[2];
                        Location = ItemColumns[4];
                    }
                    else
                    {
                        RelicDecryptorText = Public_Variables.None;
                        NumBps = "-";
                    }

                    if (IncludeME)
                    {
                        OutputME = MaterialList[i].GetItemME();
                        // If we are including an ME, then we are building something
                        // If no numbp sent then set to 1 for now - TODO-MBPS will affect multiple bps
                        if (NumBps == "-")
                        {
                            NumBps = "1";
                        }
                    }
                    else
                    {
                        OutputME = "-";
                    }

                    if ((ExportTextFormat ?? "") == Public_Variables.CSVDataExport | (ExportTextFormat ?? "") == Public_Variables.SSVDataExport)
                    {
                        // Format output for no commas in prices or quantity
                        OutputString = OutputString + MatName + Separator + MaterialList[i].GetQuantity().ToString() + Separator;

                        if (IncludeME)
                        {
                            OutputString = OutputString + OutputME + Separator + NumBps + Separator;
                        }

                        if (IncludeDecryptorRelic)
                        {
                            OutputString = OutputString + RelicDecryptorText + Separator;
                        }

                        OutputString = OutputString + MaterialList[i].GetCostPerItem().ToString() + Separator + MaterialList[i].GetTotalCost().ToString();

                        if (!string.IsNullOrEmpty(Location))
                        {
                            OutputString = OutputString + Separator + Location;
                        }

                        OutputString = OutputString + Constants.vbCrLf;
                    }

                    else if ((ExportTextFormat ?? "") == Public_Variables.MultiBuyDataExport)
                    {
                        // Just the name and quantity for use in evepraisal etc.
                        OutputString = OutputString + MatName + " " + MaterialList[i].GetQuantity() + Constants.vbCrLf;
                    }
                    else
                    {
                        OutputString = OutputString + MatName;

                        if (IncludeME | IncludeDecryptorRelic)
                        {
                            OutputString = OutputString + " ("; // Adding something so start the parens

                            if (OutputME != "-")
                            {
                                OutputString = OutputString + "ME: " + OutputME;
                                OutputString = OutputString + ", NumBPs: " + NumBps;
                            }

                            if (!string.IsNullOrEmpty(RelicDecryptorText) & (RelicDecryptorText ?? "") != Public_Variables.None & IncludeDecryptorRelic)
                            {
                                if (RelicDecryptorText.Contains(Public_Variables.IntactRelic) | RelicDecryptorText.Contains(Public_Variables.MalfunctioningRelic) | RelicDecryptorText.Contains(Public_Variables.WreckedRelic))
                                {
                                    OutputString = OutputString + ", Relic: " + RelicDecryptorText;
                                }
                                else
                                {
                                    // Decryptor
                                    OutputString = OutputString + ", Decryptor: " + RelicDecryptorText;
                                }
                            }

                            OutputString = OutputString + ")";

                        }

                        if (!MatName.Contains("Data Interface"))
                        {
                            OutputString = OutputString + " - " + Strings.FormatNumber(MaterialList[i].GetQuantity(), 0);
                        }

                        if (!string.IsNullOrEmpty(Location))
                        {
                            OutputString = OutputString + Constants.vbCrLf + "Location: " + Location;
                        }

                        OutputString = OutputString + Constants.vbCrLf;

                    }

                SkipFormat:
                    ;

                }

                if ((ExportTextFormat ?? "") != Public_Variables.MultiBuyDataExport)
                {
                    // Add total volume and cost to end
                    if (!IgnorePriceVolume)
                    {

                        OutputString = OutputString + DataInterfaces;

                        if ((ExportTextFormat ?? "") == Public_Variables.CSVDataExport | (ExportTextFormat ?? "") == Public_Variables.SSVDataExport)
                        {
                            Separator = Strings.Trim(Separator); // Remove space
                            OutputString = OutputString + Constants.vbCrLf + "Total Volume of Materials:" + Separator + TotalMaterialsVolume.ToString() + Separator + "m3";
                            OutputString = OutputString + Constants.vbCrLf + "Total Cost of Materials:" + Separator + TotalMaterialsCost.ToString() + Separator + "ISK";
                        }
                        else
                        {
                            OutputString = OutputString + Constants.vbCrLf + "Total Volume of Materials: " + Strings.FormatNumber(TotalMaterialsVolume, 2) + " m3";
                            OutputString = OutputString + Constants.vbCrLf + "Total Cost of Materials: " + Strings.FormatNumber(TotalMaterialsCost, 2) + " ISK";
                        }
                    }

                    // Finally, if the export type is ssv, replace periods with commas
                    if ((ExportTextFormat ?? "") == Public_Variables.SSVDataExport)
                    {
                        OutputString = Public_Variables.ConvertUStoEUDecimal(OutputString);
                    }
                }

                GetClipboardListRet = OutputString;
            }
            else
            {
                GetClipboardListRet = "No items in List" + Constants.vbCrLf;
            }

            return GetClipboardListRet;

        }

        // Returns the total cost of the material list
        public double GetTotalMaterialsCost()
        {
            return TotalMaterialsCost;
        }

        // Returns the total volume of the matierals in the list
        public double GetTotalVolume()
        {
            return TotalMaterialsVolume;
        }

        // Sorts the material list by quantity
        private void SortListDesc(List<Material> MatList, int First, int Last)
        {
            int LowIndex;
            int HighIndex;
            long MidValue;

            // Quicksort
            LowIndex = First;
            HighIndex = Last;
            MidValue = MatList[(First + Last) / 2].GetQuantity();

            do
            {
                while (MatList[LowIndex].GetQuantity() > MidValue)
                    LowIndex = LowIndex + 1;

                while (MatList[HighIndex].GetQuantity() < MidValue)
                    HighIndex = HighIndex - 1;

                if (LowIndex <= HighIndex)
                {
                    Swap(ref LowIndex, ref HighIndex);
                    LowIndex = LowIndex + 1;
                    HighIndex = HighIndex - 1;
                }
            }
            while (LowIndex <= HighIndex);

            if (First < HighIndex)
            {
                SortListDesc(MatList, First, HighIndex);
            }

            if (LowIndex < Last)
            {
                SortListDesc(MatList, LowIndex, Last);
            }

        }

        // This swaps the list values
        private void Swap(ref int IndexA, ref int IndexB)
        {
            Material Temp;

            Temp = MaterialList[IndexA];
            MaterialList[IndexA] = MaterialList[IndexB];
            MaterialList[IndexB] = Temp;

        }

        // Returns boolean comparison of two material lists
        public bool MaterialListsEqual(Materials List1, Materials List2)
        {
            int i, j;
            List<Material> Matlist1, Matlist2;
            var ItemFound = default(bool);

            Matlist1 = List1.GetMaterialList();
            Matlist2 = List2.GetMaterialList();

            var loopTo = Matlist1.Count - 1;
            for (i = 0; i <= loopTo; i++)
            {
                var loopTo1 = Matlist2.Count - 1;
                for (j = 0; j <= loopTo1; j++)
                {
                    // Looking for the item first, if not found then not equal
                    ItemFound = false;
                    if ((Matlist1[i].GetMaterialName() ?? "") == (Matlist2[j].GetMaterialName() ?? ""))
                    {
                        ItemFound = true;
                        if (Matlist1[i].GetMaterialTypeID() != Matlist2[j].GetMaterialTypeID())
                        {
                            return false;
                        }
                        if ((Matlist1[i].GroupName ?? "") != (Matlist2[j].GroupName ?? ""))
                        {
                            return false;
                        }
                        if (Matlist1[i].GetQuantity() != Matlist2[j].GetQuantity())
                        {
                            return false;
                        }
                        if (Matlist1[i].GetVolume() != Matlist2[j].GetVolume())
                        {
                            return false;
                        }
                        if (Matlist1[i].GetCostPerItem() != Matlist2[j].GetCostPerItem())
                        {
                            return false;
                        }
                        if ((Matlist1[i].GetItemME() ?? "") != (Matlist2[j].GetItemME() ?? ""))
                        {
                            return false;
                        }
                        if (Matlist1[i].GetBuildItem() != Matlist2[j].GetBuildItem())
                        {
                            return false;
                        }
                        if (Matlist1[i].GetTotalVolume() != Matlist2[j].GetTotalVolume())
                        {
                            return false;
                        }
                        if (Matlist1[i].GetTotalCost() != Matlist2[j].GetTotalCost())
                        {
                            return false;
                        }
                        if (Matlist1[i].GetItemType() != Matlist2[j].GetItemType())
                        {
                            return false;
                        }
                    }

                    if (ItemFound)
                    {
                        // Exit the loop if we found it
                        break;
                    }
                }

                if (!ItemFound)
                {
                    return false;
                }

            }

            return true;

        }

        // Predicate for finding an item in the profit list
        private bool FindMaterial(Material Mat)
        {
            if ((Mat.GetMaterialName() ?? "") == (MaterialtoFind.GetMaterialName() ?? "") & (Mat.GroupName ?? "") == (MaterialtoFind.GroupName ?? "") & (Mat.GetItemME() ?? "") == (MaterialtoFind.GetItemME() ?? ""))

            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}