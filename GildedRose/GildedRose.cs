using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    // Constants for item names to avoid typos and make it easier to add new items
    public static class ItemNames
    {
        public const string AgedBrie = "Aged Brie";
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string ConjuredManaCake = "Conjured Mana Cake";
    }

    // Lists of different types of items for easy checking of item type
    private readonly IList<string> _specialItems = new List<string>() { ItemNames.AgedBrie, ItemNames.BackstagePasses };
    private readonly IList<string> _legendaryItems = new List<string>() { ItemNames.Sulfuras };
    private readonly IList<string> _conjuredItems = new List<string>() { ItemNames.ConjuredManaCake };

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    // Main method to update quality of all items
    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            // Legendary items do not change
            if (_legendaryItems.Contains(item.Name))
            {
                continue;
            }

            // Special items have unique update rules
            if (_specialItems.Contains(item.Name))
            {
                UpdateSpecialItem(item);
                continue;
            }

            // Conjured items degrade in Quality twice as fast as normal items
            if (_conjuredItems.Contains(item.Name))
            {
                UpdateConjuredItem(item);
                continue;
            }

            // All other items are considered normal and have standard update rules
            UpdateNormalItem(item);
        }
    }

    // Update rules for normal items
    private void UpdateNormalItem(Item item)
    {
        // Decrease SellIn value by 1
        item.SellIn--;

        // If Quality is already 0, no further updates are needed
        if (item.Quality == 0)
        {
            return;
        }

        // Decrease Quality by 1
        item.Quality--;

        // Once the sell by date has passed, Quality degrades twice as fast
        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality--;
        }
    }

    // Update rules for special items
    private void UpdateSpecialItem(Item item)
    {
        // Decrease SellIn value by 1
        item.SellIn--;

        // Increase Quality by 1, as long as it's not already at the maximum
        if (item.Quality < 50)
            item.Quality++;

        // Additional update rules for Backstage Passes
        if (item.Name == ItemNames.BackstagePasses)
        {
            UpdateBackstagePasses(item);
        }

        // Additional update rules for Aged Brie
        if (item.Name == ItemNames.AgedBrie)
        {
            UpdateAgedBrie(item);
        }
    }

    // Additional update rules for Backstage Passes
    private void UpdateBackstagePasses(Item item)
    {

        // Increase Quality by an additional 1 when there are 10 days or less
        if (item.SellIn < 10 && item.Quality < 50)
        {
            item.Quality++;
        }

        // Increase Quality by an additional 1 when there are 5 days or less
        if (item.SellIn < 5 && item.Quality < 50)
        {
            item.Quality++;
        }

        // Quality drops to 0 after the concert
        if (item.SellIn < 0)
        {
            item.Quality = 0;
        }
    }

    // Additional update rules for Aged Brie
    private void UpdateAgedBrie(Item item)
    {
        // Quality increases by an additional 1 after the sell by date
        if (item.SellIn < 0 && item.Quality < 50)
        {
            item.Quality++;
        }
    }

    // Update rules for Conjured items
    private void UpdateConjuredItem(Item item)
    {
        // Decrease SellIn value by 1
        item.SellIn--;

        // If Quality is already 0, no further updates are needed
        if (item.Quality == 0)
        {
            return;
        }

        // Decrease Quality by 2, or to 0 if decreasing by 2 would make it negative
        item.Quality = item.Quality - 2 < 0 ? 0 : item.Quality - 2;

        // Once the sell by date has passed, Quality degrades twice as fast
        if (item.SellIn < 0)
        {
            item.Quality = item.Quality - 2 < 0 ? 0 : item.Quality - 2;
        }
    }
}