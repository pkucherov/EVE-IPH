using System;
using Microsoft.VisualBasic;

namespace EVE_Isk_per_Hour
{

    public class Material : ICloneable
    {

        private long TypeID;
        private string TypeName;
        private string _GroupName;
        private long Quantity;
        private double DQuantity;
        private double Volume;

        // Look up cost per item when not set
        private double CostPerItem;

        // If this material is a buildable item, store the ME for the grid
        private string ItemME;
        private string ItemTE;
        private bool BuildItem; // Whether we should build the item or not

        // Calculate
        private double TotalMatVolume;
        private double TotalCost;

        private int ItemType; // My item type value

        public Material(long SentTypeID, string SentTypeName, string SentGroupName, long SentQuantity, double SentVolume, double SentPrice, string SentItemME, string SentItemTE, bool isBuiltItem = false, int SentItemType = 0)
        {
            TypeID = SentTypeID;
            TypeName = SentTypeName;
            Quantity = SentQuantity;
            DQuantity = -1;
            Volume = SentVolume;
            _GroupName = SentGroupName;
            BuildItem = isBuiltItem;
            ItemType = SentItemType;

            if (!string.IsNullOrEmpty(Strings.Trim(SentItemME)))
            {
                ItemME = SentItemME;
            }
            else
            {
                ItemME = "-";
            }

            if (!string.IsNullOrEmpty(Strings.Trim(SentItemTE)))
            {
                ItemTE = SentItemTE;
            }
            else
            {
                ItemTE = "-";
            }

            if (SentPrice == 0d)
            {
                CostPerItem = Public_Variables.GetItemPrice(TypeID);
            }
            else
            {
                CostPerItem = SentPrice;
            }

            SetTotalCostVolume();

        }

        public Material(long SentTypeID, string SentTypeName, string SentGroupName, double SentQuantity, double SentVolume, double SentPrice, string SentItemME, string SentItemTE, bool isBuiltItem = false, int SentItemType = 0)
        {
            TypeID = SentTypeID;
            TypeName = SentTypeName;
            Quantity = -1;
            DQuantity = SentQuantity;
            Volume = SentVolume;
            _GroupName = SentGroupName;
            BuildItem = isBuiltItem;
            ItemType = SentItemType;

            if (!string.IsNullOrEmpty(Strings.Trim(SentItemME)))
            {
                ItemME = SentItemME;
            }
            else
            {
                ItemME = "-";
            }

            if (!string.IsNullOrEmpty(Strings.Trim(SentItemTE)))
            {
                ItemTE = SentItemTE;
            }
            else
            {
                ItemTE = "-";
            }

            if (SentPrice == 0d)
            {
                CostPerItem = Public_Variables.GetItemPrice(TypeID);
            }
            else
            {
                CostPerItem = SentPrice;
            }

            SetTotalCostVolume();
        }

        // For doing a deep copy of Materials
        public object Clone()
        {
            Material CopyofMe;
            if (DQuantity == -1)
            {
                CopyofMe = new Material(TypeID, TypeName, GroupName, Quantity, Volume, CostPerItem, ItemME, ItemTE, BuildItem, ItemType);
            }
            else
            {
                CopyofMe = new Material(TypeID, TypeName, GroupName, DQuantity, Volume, CostPerItem, ItemME, ItemTE, BuildItem, ItemType);
            }

            return CopyofMe;
        }

        private void SetTotalCostVolume()
        {
            if (DQuantity == -1)
            {
                TotalCost = CostPerItem * Quantity;
                TotalMatVolume = Volume * Quantity;
            }
            else
            {
                TotalCost = CostPerItem * DQuantity;
                TotalMatVolume = Volume * DQuantity;
            }
        }

        // Adds quantity to the material and upates the total cost and volume
        public void AddQuantity(long SentQuantity)
        {
            Quantity = Quantity + SentQuantity;
            // New quantity means new total price and volume
            SetTotalCostVolume();
        }

        // Sets the quantity of the material and sets the total cost and volume
        public void SetQuantity(long SentQuantity)
        {
            Quantity = SentQuantity;
            // New quantity means new total price and volume
            SetTotalCostVolume();
        }

        // Adds quantity to the material and upates the total cost and volume
        public void AddDQuantity(double SentQuantity)
        {
            DQuantity = DQuantity + SentQuantity;
            // New quantity means new total price and volume
            SetTotalCostVolume();
        }

        // Sets the quantity of the material and sets the total cost and volume
        public void SetDQuantity(double SentQuantity)
        {
            DQuantity = SentQuantity;
            // New quantity means new total price and volume
            SetTotalCostVolume();
        }

        // Sets the Total Cost of the material to the sent cost only if it's built
        public void SetBuildCostPerItem(double BuildCost)
        {
            if (BuildItem)
            {
                CostPerItem = BuildCost;
                SetTotalCostVolume();
            }
        }

        // Sets the name with the sent name
        public void SetName(string SentName)
        {
            TypeName = SentName;
        }

        // Sets the items ME
        public void SetItemME(string SentME)
        {
            ItemME = SentME;
        }

        // Sets the items TE
        public void SetItemTE(string SentTE)
        {
            ItemTE = SentTE;
        }

        // Sets the item as built
        public void SetBuildItem(bool BuildValue)
        {
            BuildItem = BuildValue;
        }

        // Allow setting total cost
        public void SetTotalCost(double SentTotalCost)
        {
            TotalCost = SentTotalCost;
        }

        public int GetItemType()
        {
            return ItemType;
        }

        public long GetMaterialTypeID()
        {
            return TypeID;
        }

        public string GetMaterialName()
        {
            return TypeName;
        }

        public long GetQuantity()
        {
            return Quantity;
        }

        public double GetDQuantity()
        {
            return DQuantity;
        }

        // Public Function GetMaterialGroup() As String
        // Return GroupName
        // End Function

        public string GroupName
        {
            get
            {
                return _GroupName;
            }
            set
            {
                _GroupName = value;
            }
        }

        public double GetVolume()
        {
            return Volume;
        }

        public double GetCostPerItem()
        {
            return CostPerItem;
        }

        public double GetTotalVolume()
        {
            return TotalMatVolume;
        }

        public double GetTotalCost()
        {
            return TotalCost;
        }

        public string GetItemME()
        {
            return ItemME;
        }

        public string GetItemTE()
        {
            return ItemTE;
        }

        public bool GetBuildItem()
        {
            return BuildItem;
        }

    }
}