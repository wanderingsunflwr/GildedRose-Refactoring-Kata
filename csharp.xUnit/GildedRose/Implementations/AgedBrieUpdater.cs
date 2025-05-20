using System;
using GildedRoseKata.Contracts;
using GildedRoseKata.Models;

namespace GildedRoseKata.Implementations;

public class AgedBrieUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        ArgumentNullException.ThrowIfNull(item);
        
        IncreaseQuality(item);
        item.SellIn--;
        if (item.SellIn < 0)
            IncreaseQuality(item);
    }
    private static void IncreaseQuality(Item item)
    {
        if (item.Quality < 50)
            item.Quality++;
    }
}