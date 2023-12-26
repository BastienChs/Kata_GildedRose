using GildedRoseKata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests.ItemsTests
{
    internal class LegendaryItemsTests
    {
        [Test]
        public void UpdateQuality_WhenCalledWithSulfurasItem_ShouldNotChangeQualityOrSellIn()
        {
            // Arrange
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn=10, Quality = 80 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(80, item.Quality);
            Assert.AreEqual(10, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithSulfurasItemAndNegativeSellIn_ShouldNotChangeQualityOrSellIn()
        {
            // Arrange
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -10, Quality = 80 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(80, item.Quality);
            Assert.AreEqual(-10, item.SellIn);
        }

    }
}
