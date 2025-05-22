using System;
using System.Collections.Generic;
using GildedRoseKata.Contracts;
using GildedRoseKata.Models;

namespace GildedRoseKata.Implementations;

// Did not rename this class because it is the main class of the kata repo and was unsure if it would cause
// issues with the tests.
public class GildedRose(IList<Item> itemsList)
{
    private const string AgedBrie = "Aged Brie";
    private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
    private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
    private const string Conjured = "Conjured";

    public void UpdateQuality()
    {
        foreach (var item in itemsList)
        {
            GetUpdater(item).Update(item);
        }
    }
    private static IItemUpdater GetUpdater(Item item)
    {
        switch (item.Name)
        {
            case AgedBrie:
                return new AgedBrieUpdater();
            case BackstagePass:
                return new BackstagePassUpdater();
            case Sulfuras:
                return new SulfurasUpdater();
        }

        if (item.Name.StartsWith(Conjured, StringComparison.OrdinalIgnoreCase))
            return new ConjuredItemUpdater();
        return new NormalItemUpdater();
    }
}