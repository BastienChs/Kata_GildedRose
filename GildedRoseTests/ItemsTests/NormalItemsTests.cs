using GildedRoseKata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests.ItemsTests
{
    internal class NormalItemsTests
    {
        [Test]
        public void UpdateQuality_WhenCalledWithNormalItem_ShouldDecreaseQualityByOne()
        {
            // Arrange
            var item = new Item { Name = "Normal Item", SellIn = 10, Quality = 20 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(19, item.Quality);
            Assert.AreEqual(9, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithNormalItemAndPastSellIn_ShouldDecreaseQualityByTwo()
        {
            // Arrange
            var item = new Item { Name = "Normal Item", SellIn = 0, Quality = 20 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(18, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithNormalItemAndQualityIsZero_ShouldNotDecreaseQuality()
        {
            // Arrange
            var item = new Item { Name = "Normal Item", SellIn = 10, Quality = 0 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(9, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithNormalItemAndQualityIsOneAndSellInIsZero_ShouldSetQualityToZero()
        {
            // Arrange
            var item = new Item { Name = "Normal Item", SellIn = 0, Quality = 1 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithNormalItemAndQualityIsOneAndSellInIsOne_ShouldSetQualityToZero()
        {
            // Arrange
            var item = new Item { Name = "Normal Item", SellIn = 1, Quality = 1 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(0, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledMultipleTimes_ShouldCorrectlyDecreaseQualityOverTime()
        {
            // Arrange
            var item = new Item { Name = "Normal Item", SellIn = 5, Quality = 10 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            for (int i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(5, item.Quality);
            Assert.AreEqual(0, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledMultipleTimesWithANegativeSellInAndAQualityOf3_ShouldCorrectlySetQualityTo0()
        {
            // Arrange
            var item = new Item { Name = "Normal Item", SellIn = 2, Quality = 3 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            for (int i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-3, item.SellIn);
        }
    }
}
