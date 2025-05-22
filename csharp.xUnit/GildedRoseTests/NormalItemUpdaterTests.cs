using System;
using GildedRoseKata;
using GildedRoseKata.Implementations;
using GildedRoseKata.Models;
using Xunit;

namespace GildedRoseTests;

public class NormalItemUpdaterTests
{
    [Fact]
    public void NormalItemUpdater_ShouldDecreaseQualityBy1_WhenSellInIsPositive()
    {
        // Arrange
        var item = new Item { Name = "Normal Item", SellIn = 5, Quality = 10 };
        var updater = new NormalItemUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(9, item.Quality);
        Assert.Equal(4, item.SellIn);  
    }

    [Fact]
    public void NormalItemUpdater_ShouldDecreaseQualityBy2_WhenSellInIsNegative()
    {
        // Arrange
        var item = new Item { Name = "Normal Item", SellIn = 0, Quality = 10 };
        var updater = new NormalItemUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(8, item.Quality);  
        Assert.Equal(-1, item.SellIn); 
    }

    [Fact]
    public void NormalItemUpdater_ShouldNotDecreaseQualityBelowZero()
    {
        // Arrange
        var item = new Item { Name = "Normal Item", SellIn = 3, Quality = 0 };
        var updater = new NormalItemUpdater();

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
        var updater = new NormalItemUpdater();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => updater.Update(item));
    }
}