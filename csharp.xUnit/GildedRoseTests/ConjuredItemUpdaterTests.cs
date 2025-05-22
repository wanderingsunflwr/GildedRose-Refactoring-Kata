using System;
using GildedRoseKata.Implementations;
using GildedRoseKata.Models;
using Xunit;

namespace GildedRoseTests;

public class ConjuredItemUpdaterTests
{
    [Fact]
    public void ConjuredItemUpdater_ShouldDecreaseQualityBy2_WhenSellInIsPositive()
    {
        // Arrange
        var item = new Item { Name = "Conjured Item", SellIn = 5, Quality = 10 };
        var updater = new ConjuredItemUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(8, item.Quality);  
        Assert.Equal(4, item.SellIn);  
    }

    [Fact]
    public void ConjuredItemUpdater_ShouldDecreaseQualityBy4_WhenSellInIsNegative()
    {
        // Arrange
        var item = new Item { Name = "Conjured Item", SellIn = 0, Quality = 10 };
        var updater = new ConjuredItemUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(6, item.Quality); 
        Assert.Equal(-1, item.SellIn);  
    }

    [Fact]
    public void ConjuredItemUpdater_ShouldNotDecreaseQualityBelowZero()
    {
        // Arrange
        var item = new Item { Name = "Conjured Item", SellIn = 3, Quality = 0 };
        var updater = new ConjuredItemUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(0, item.Quality);  
        Assert.Equal(2, item.SellIn);   
    }

    [Fact]
    public void Update_ShouldThrowArgumentNullException_WhenItemIsNull()
    {
        // Arrange
        Item item = null;
        var normalUpdater = new NormalItemUpdater();
        var conjuredUpdater = new ConjuredItemUpdater();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => normalUpdater.Update(item));
        Assert.Throws<ArgumentNullException>(() => conjuredUpdater.Update(item));
    }
}
