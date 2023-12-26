using GildedRoseKata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests.ItemsTests
{
    internal class SpecialItemsTests
    {
        #region Aged Brie
        [Test]
        public void UpdateQuality_WhenCalledWithAgedBrieAndQualityMaximum_ShouldNotIncreaseQuality()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(9, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithAgedBrieAndPositiveSellIn_ShouldIncreaseQualityByOne()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 20, Quality = 20 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(21, item.Quality);
            Assert.AreEqual(19, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithAgedBrieAnd0SellIn_ShouldIncreaseQualityByTwo()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(22, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithAgedBrieAndNegativeSellIn_ShouldIncreaseQualityByTwo()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = -10, Quality = 20 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(22, item.Quality);
            Assert.AreEqual(-11, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledMultipleTimesWithAgedBrie_ShouldCorrectlyIncreaseQualityOverTime()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            for (int i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(15, item.Quality);
            Assert.AreEqual(0, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledMultipleTimesWithAgedBrieAndQualityUpperLimitReached_ShouldCorrectlySet50()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 47 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            for (int i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(0, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledMultipleTimesWithAgedBrieWithNegativeSellInReached_ShouldCorrectlyIncreaseQualityOverTime()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 10 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            for (int i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(18, item.Quality);
            Assert.AreEqual(-3, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledMultipleTimesWithAgedBrieWithNegativeSellInReachedAndQualityUpperLimitReached_ShouldCorrectlySet50()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 48 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            for (int i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(-3, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithAgedBrieAndQualityMaximumAndNegativeSellIn_ShouldNotIncreaseQuality()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = -10, Quality = 50 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(-11, item.SellIn);
        }
        #endregion

        #region Backstage passes
        [Test]
        public void UpdateQuality_WhenCalledWithBackstagePassesAndSellInLesserThan0_ShouldSetQualityTo0()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithBackstagePassesAndSellInLesserThanTen_ShouldIncreaseQualityByTwo()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 20 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(22, item.Quality);
            Assert.AreEqual(8, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithBackstagePassesAndSellInLesserThanTenAndQualityIs49_ShouldSetQualityTo50()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 49 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(8, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithBackstagePassesAndSellInLesserThanFive_ShouldIncreaseQualityByThree()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 20 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(23, item.Quality);
            Assert.AreEqual(3, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledWithBackstagePassesAndSellInLesserThanFiveAndQualityIs48_ShouldSetQualityTo50()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 48 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(3, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledMultipleTimesWithBackstagePasses_ShouldCorrectlyIncreaseQualityOverTime()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            for (int i = 0; i < 12; i++)
            {
                app.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(31, item.Quality);
            Assert.AreEqual(3, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledMultipleTimesWithBackstagePassesAndQualityUpperLimitReached_ShouldCorrectlySet50()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 48 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            for (int i = 0; i < 12; i++)
            {
                app.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(3, item.SellIn);
        }

        [Test]
        public void UpdateQuality_WhenCalledMultipleTimesWithBackstagePassesAndSellInLesserThanZero_ShouldCorrectlySetQualityToZero()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 10 };
            var items = new List<Item> { item };
            var app = new GildedRose(items);

            // Act
            for (int i = 0; i < 12; i++)
            {
                app.UpdateQuality();
            }

            // Assert
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-4, item.SellIn);
        }

        #endregion
    }
}
