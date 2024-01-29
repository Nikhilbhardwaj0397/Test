using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // shopping basket
        List<string> shoppingBasket = new List<string> { "Apple", "Apple", "Banana", "Melon", "Melon", "Lime", "Lime", "Lime" };

        // calculate total cost
        decimal totalCost = CalculateTotalCost(shoppingBasket);

        Console.WriteLine($"Total Cost: {totalCost}");
    }

    static decimal CalculateTotalCost(List<string> shoppingBasket)
    {
        decimal applePrice = 0.35m;
        decimal bananaPrice = 0.20m;
        decimal melonPrice = 0.50m;
        decimal limePrice = 0.15m;

        var itemCounts = shoppingBasket.GroupBy(item => item)
                                       .ToDictionary(group => group.Key, group => group.Count());

        decimal totalCost = 0;

        if (itemCounts.ContainsKey("Apple"))
        {
            totalCost += applePrice * itemCounts["Apple"];
        }

        if (itemCounts.ContainsKey("Banana"))
        {
            totalCost += bananaPrice * itemCounts["Banana"];
        }

        if (itemCounts.ContainsKey("Melon"))
        {
            totalCost += (itemCounts["Melon"] / 2) * melonPrice;
        }

        if (itemCounts.ContainsKey("Lime"))
        {
            totalCost += (itemCounts["Lime"] / 3) * (2 * limePrice);
        }

        return totalCost;
    }
}
