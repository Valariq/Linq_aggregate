using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class OrderAnalytics
{
    public static void ShowOnlineAggregates(List<OrderItem> onlineOrders)
    {
        int totalOrders = onlineOrders.Count();
        int expensiveOrders = onlineOrders.Count(x => x.Price * x.Quantity > 1000m);

        decimal totalRevenue = onlineOrders.Sum(x => x.Price * x.Quantity);

        decimal averagePositionPrice = onlineOrders.Average(x => x.Price);

        decimal minPrice = onlineOrders.Min(x => x.Price);
        decimal maxPrice = onlineOrders.Max(x => x.Price);

        string categoriesSummary = onlineOrders
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x)
            .Aggregate(
                new StringBuilder("Категории: "),
                (builder, category) =>
                {
                    if (builder.Length > 12)
                        builder.Append(", ");

                    builder.Append(category);
                    return builder;
                })
            .ToString();

        Console.WriteLine($"Всего онлайн-заказов: {totalOrders}");
        Console.WriteLine($"Заказы с суммой > 1000: {expensiveOrders}");
        Console.WriteLine($"Общая выручка: {totalRevenue:C}");
        Console.WriteLine($"Средняя цена позиции: {averagePositionPrice:C}");
        Console.WriteLine($"Минимальная цена: {minPrice:C}");
        Console.WriteLine($"Максимальная цена: {maxPrice:C}");
        Console.WriteLine(categoriesSummary);
    }
}