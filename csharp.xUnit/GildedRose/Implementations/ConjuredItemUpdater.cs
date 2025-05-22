using System;
using GildedRoseKata.Models;

namespace GildedRoseKata.Implementations;

public sealed class ConjuredItemUpdater : NormalItemUpdater
{
    public override void Update(Item item)
    {
        ArgumentNullException.ThrowIfNull(item);
        
        DecreaseQuality(item);
        DecreaseQuality(item);
        item.SellIn--;
        if (item.SellIn < 0)
        {
            DecreaseQuality(item);
            DecreaseQuality(item);
        }
    }
    private static void DecreaseQuality(Item item)
    {
        if (item.Quality > 0)
            item.Quality--;
    }
}