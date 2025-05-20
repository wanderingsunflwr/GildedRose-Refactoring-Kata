﻿using System;
using System.Collections.Generic;
using GildedRoseKata.Implementations;
using GildedRoseKata.Models;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        IList<Item> items = new List<Item>
        {
            new() {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new() {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new() {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },
            new()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49
            },
            new()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            },
            // this conjured item does not work properly yet
            new() {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };

        var app = new GildedRose(items);

        int days = 2;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }
    }
}