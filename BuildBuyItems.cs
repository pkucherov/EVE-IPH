using System.Collections.Generic;

namespace EVE_Isk_per_Hour
{

    public class BuildBuyItems
    {
        private List<BBItem> BBItems;

        private int BBItemIDtoFind;
        private Public_Variables.BuildBuyItem BBItemtoFind = new Public_Variables.BuildBuyItem();

        public struct BBItem
        {
            public int BPID;
            public List<Public_Variables.BuildBuyItem> BBItems;
        }

        public BuildBuyItems()
        {
            BBItems = new List<BBItem>();
        }
    }
}