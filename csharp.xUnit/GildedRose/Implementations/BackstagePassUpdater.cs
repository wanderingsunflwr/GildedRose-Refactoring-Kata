using System;
using GildedRoseKata.Contracts;
using GildedRoseKata.Models;

namespace GildedRoseKata.Implementations;

public class BackstagePassUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        ArgumentNullException.ThrowIfNull(item);
        
        switch (item.SellIn)
        {
            case > 10:
                IncreaseQuality(item);
                break;
            case > 5:
                IncreaseQuality(item, 2);
                break;
            case > 0:
                IncreaseQuality(item, 3);
                break;
            default:
                item.Quality = 0;
                break;
        }
        item.SellIn--;
    }
    
    private static void IncreaseQuality(Item item, int amount = 1)
    {
        item.Quality = Math.Min(50, item.Quality + amount);
    }
}