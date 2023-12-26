using GildedRoseKata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests.ItemsTests
{
    internal class ConjuredItemsTests
    {
        [Test]
        public void UpdateQuality_WhenCalledWithConjuredItem_ShouldDecreaseQualityByTwo()
        {
            // Arrange
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 15, Quality = 30 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(28, item.Quality);
            Assert.AreEqual(14, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithConjuredItemAndSellInLesserThanZero_ShouldDecreaseQualityByFour()
        {
            // Arrange
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 30 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(26, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithConjuredItemAndSellInLesserThanZeroAndQualityLesserThanFour_ShouldDecreaseQualityToZero()
        {
            // Arrange
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 3 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithConjuredItemAndSellInGreaterThanZeroAndQualityLesserThanTwo_ShouldDecreaseQualityToZero()
        {
            // Arrange
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 1, Quality = 1 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(0, item.SellIn);
        }
    }
}
