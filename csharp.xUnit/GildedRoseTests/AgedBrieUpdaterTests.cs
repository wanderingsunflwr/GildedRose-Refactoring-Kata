using System;
using GildedRoseKata.Implementations;
using GildedRoseKata.Models;
using Xunit;

namespace GildedRoseTests;

public class AgedBrieUpdaterTests
{
    private const string AgedBrieName = "Aged Brie";
    
    [Fact]
    public void Update_ShouldIncreaseQuality_WhenSellInIsPositive()
    {
        // Arrange
        var item = new Item { Name = AgedBrieName, SellIn = 2, Quality = 0 };
        var updater = new AgedBrieUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(1, item.Quality);  
        Assert.Equal(1, item.SellIn);
    }

    [Fact]
    public void Update_ShouldIncreaseQualityTwice_WhenSellInIsNegative()
    {
        // Arrange
        var item = new Item { Name = AgedBrieName, SellIn = 0, Quality = 1 };
        var updater = new AgedBrieUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(3, item.Quality);  
        Assert.Equal(-1, item.SellIn);  
    }

    [Fact]
    public void Update_ShouldNotExceedMaxQuality()
    {
        // Arrange
        var item = new Item { Name = AgedBrieName, SellIn = 2, Quality = 50 };
        var updater = new AgedBrieUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(50, item.Quality);  
        Assert.Equal(1, item.SellIn);    
    }

    [Fact]
    public void Update_ShouldIncreaseQuality_WhenQualityIsLowAndSellInIsPositive()
    {
        // Arrange
        var item = new Item { Name = AgedBrieName, SellIn = 2, Quality = 0 };
        var updater = new AgedBrieUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(1, item.Quality);  
        Assert.Equal(1, item.SellIn);  
    }

    [Fact]
    public void Update_ShouldThrowArgumentNullException_WhenItemIsNull()
    {
        // Arrange
        Item item = null;
        var updater = new AgedBrieUpdater();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => updater.Update(item));
    }
}