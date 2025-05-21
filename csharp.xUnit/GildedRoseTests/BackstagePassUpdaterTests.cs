using System;
using GildedRoseKata.Implementations;
using GildedRoseKata.Models;
using Xunit;

namespace GildedRoseTests;

public class BackstagePassUpdaterTests
{
    private const string BackstagePassName = "Backstage Pass";
    
    [Fact]
    public void Update_ShouldIncreaseQualityBy1_WhenSellInIsGreaterThan10()
    {
        // Arrange
        var item = new Item { Name = BackstagePassName, SellIn = 11, Quality = 10 };
        var updater = new BackstagePassUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(11, item.Quality);
        Assert.Equal(10, item.SellIn);  
    }

    [Fact]
    public void Update_ShouldIncreaseQualityBy2_WhenSellInIsBetween6And10()
    {
        // Arrange
        var item = new Item { Name = BackstagePassName, SellIn = 8, Quality = 10 };
        var updater = new BackstagePassUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(12, item.Quality);
        Assert.Equal(7, item.SellIn);   
    }

    [Fact]
    public void Update_ShouldIncreaseQualityBy3_WhenSellInIsBetween1And5()
    {
        // Arrange
        var item = new Item { Name = BackstagePassName, SellIn = 3, Quality = 10 };
        var updater = new BackstagePassUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(13, item.Quality); 
        Assert.Equal(2, item.SellIn);  
    }

    [Fact]
    public void Update_ShouldSetQualityTo0_WhenSellInIs0OrLess()
    {
        // Arrange
        var item = new Item { Name = BackstagePassName, SellIn = 0, Quality = 10 };
        var updater = new BackstagePassUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(0, item.Quality);
        Assert.Equal(-1, item.SellIn); 
    }

    [Fact]
    public void Update_ShouldNotExceedMaxQualityOf50()
    {
        // Arrange
        var item = new Item { Name = BackstagePassName, SellIn = 5, Quality = 48 };
        var updater = new BackstagePassUpdater();

        // Act
        updater.Update(item);

        // Assert
        Assert.Equal(50, item.Quality); 
        Assert.Equal(4, item.SellIn); 
    }

    [Fact]
    public void Update_ShouldThrowArgumentNullException_WhenItemIsNull()
    {
        // Arrange
        Item item = null;
        var updater = new BackstagePassUpdater();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => updater.Update(item));
    }
}