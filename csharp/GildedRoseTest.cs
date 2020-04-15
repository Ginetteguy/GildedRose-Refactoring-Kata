using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void StandardObject()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 2, Quality = 5 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(1, items[0].SellIn);
            Assert.AreEqual(4, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(0, items[0].SellIn);
            Assert.AreEqual(3, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(1, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(-2, items[0].SellIn);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void Sulfuras()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item() { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 });
            items.Add(new Item() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
            items.Add(new Item() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 });


            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(0, items[1].SellIn);
            Assert.AreEqual(1, items[2].SellIn);
            Assert.AreEqual(80, items[0].Quality);
            Assert.AreEqual(80, items[1].Quality);
            Assert.AreEqual(80, items[2].Quality);
        }

        [Test]
        public void AgedBrie()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item() { Name = "Aged Brie", SellIn = 1, Quality = 46 });

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            AssertSellInAndQuality(items[0], 0, 47);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], -1, 49);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], -2, 50);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], -3, 50);
        }

        [Test]
        public void Backstage()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 26 });

            GildedRose app = new GildedRose(items);
            
            app.UpdateQuality();
            AssertSellInAndQuality(items[0], 10, 27);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], 9, 29);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], 8, 31);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], 7, 33);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], 6, 35);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], 5, 37);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], 4, 40);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], 3, 43);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], 2, 46);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], 1, 49);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], 0, 50);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], -1, 0);

            app.UpdateQuality();
            AssertSellInAndQuality(items[0], -2, 0);
        }

        private void AssertSellInAndQuality(Item item, int expectedSellIn, int expectedQuality)
        {
            Assert.AreEqual(expectedSellIn, item.SellIn);
            Assert.AreEqual(expectedQuality, item.Quality);
        }
    }
}
