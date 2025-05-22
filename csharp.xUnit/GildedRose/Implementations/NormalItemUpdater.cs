using System;
using GildedRoseKata.Contracts;
using GildedRoseKata.Models;

namespace GildedRoseKata.Implementations;

public class NormalItemUpdater : IItemUpdater
{
    public virtual void Update(Item item)
    {
        ArgumentNullException.ThrowIfNull(item);
        
        DecreaseQuality(item);
        item.SellIn--;
        if (item.SellIn < 0)
            DecreaseQuality(item);
    }

    private void DecreaseQuality(Item item)
    {
        if (item.Quality > 0)
            item.Quality--;
    }
}