/* -------------------------------------------------------------------------------------------------
   Restricted. Copyright (C) Siemens Healthineers AG, 2025. All rights reserved.
   ------------------------------------------------------------------------------------------------- */

namespace hamaraBasket.Tests
{
    public class Domain
    {

        public List<Item> PrepareItemList(string name, int sellin, int quality)
        {
            return new List<Item>
            {
                new Item { Name = name, SellIn = sellin, Quality = quality },
            };
        }
        public void UpdateQualityHelper(List<Item> Items)

        {

            HamaraBasket app = new HamaraBasket(Items);

            app.UpdateQuality();

        }
    }
}
