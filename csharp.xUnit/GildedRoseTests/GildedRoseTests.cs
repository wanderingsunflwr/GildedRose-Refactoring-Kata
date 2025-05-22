using System.Collections.Generic;
using GildedRoseKata.Contracts;
using GildedRoseKata.Implementations;
using GildedRoseKata.Models;
using Moq;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseTests
{
    private readonly Mock<IItemUpdater> _agedBrieUpdaterMock = new();
    private readonly Mock<IItemUpdater> _backstagePassUpdaterMock = new();
    private readonly Mock<IItemUpdater> _sulfurasUpdaterMock = new();
    private readonly Mock<IItemUpdater> _conjuredItemUpdaterMock = new();
    private readonly Mock<IItemUpdater> _normalItemUpdaterMock = new();

    [Fact]
    public void UpdateQuality_ShouldCallAgedBrieUpdater_WhenItemIsAgedBrie()
    {
        // Arrange
        var itemsList = new List<Item>
        {
            new() { Name = "Aged Brie", Quality = 10, SellIn = 5 }
        };

        var gildedRose = new GildedRose(itemsList);
            
        _agedBrieUpdaterMock.Setup(x => x.Update(It.IsAny<Item>())).Verifiable();

        // Act
        gildedRose.UpdateQuality();

        // Assert
        _agedBrieUpdaterMock.Verify(x => x.Update(It.IsAny<Item>()), Times.Once);
    }

    [Fact]
    public void UpdateQuality_ShouldCallBackstagePassUpdater_WhenItemIsBackstagePass()
    {
        // Arrange
        var itemsList = new List<Item>
        {
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 5 }
        };

        var gildedRose = new GildedRose(itemsList);
            
        _backstagePassUpdaterMock.Setup(x => x.Update(It.IsAny<Item>())).Verifiable();

        // Act
        gildedRose.UpdateQuality();

        // Assert
        _backstagePassUpdaterMock.Verify(x => x.Update(It.IsAny<Item>()), Times.Once);
    }

    [Fact]
    public void UpdateQuality_ShouldCallSulfurasUpdater_WhenItemIsSulfuras()
    {
        // Arrange
        var itemsList = new List<Item>
        {
            new() { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 0 }
        };

        var gildedRose = new GildedRose(itemsList);
            
        _sulfurasUpdaterMock.Setup(x => x.Update(It.IsAny<Item>())).Verifiable();

        // Act
        gildedRose.UpdateQuality();

        // Assert
        _sulfurasUpdaterMock.Verify(x => x.Update(It.IsAny<Item>()), Times.Once);
    }

    [Fact]
    public void UpdateQuality_ShouldCallConjuredItemUpdater_WhenItemIsConjured()
    {
        // Arrange
        var itemsList = new List<Item>
        {
            new() { Name = "Conjured Mana Cake", Quality = 10, SellIn = 5 }
        };

        var gildedRose = new GildedRose(itemsList);
            
        _conjuredItemUpdaterMock.Setup(x => x.Update(It.IsAny<Item>())).Verifiable();

        // Act
        gildedRose.UpdateQuality();

        // Assert
        _conjuredItemUpdaterMock.Verify(x => x.Update(It.IsAny<Item>()), Times.Once);
    }

    [Fact]
    public void UpdateQuality_ShouldCallNormalItemUpdater_WhenItemIsNormal()
    {
        // Arrange
        var itemsList = new List<Item>
        {
            new() { Name = "Normal Item", Quality = 10, SellIn = 5 }
        };

        var gildedRose = new GildedRose(itemsList);
            
        _normalItemUpdaterMock.Setup(x => x.Update(It.IsAny<Item>())).Verifiable();

        // Act
        gildedRose.UpdateQuality();

        // Assert
        _normalItemUpdaterMock.Verify(x => x.Update(It.IsAny<Item>()), Times.Once);
    }
}