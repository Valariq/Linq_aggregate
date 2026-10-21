using System.Collections.Generic;
using System.Linq;

public static class ObjectSetDemo
{
    public static List<OrderItem> GetOnlineOnlyObjects(List<OrderItem> onlineOrders, List<OrderItem> storeOrders)
    {
        return onlineOrders
            .Except(storeOrders)
            .Distinct()
            .OrderBy(x => x.ProductName)
            .ToList();
    }

    public static List<OrderItem> GetIntersectionObjects(List<OrderItem> onlineOrders, List<OrderItem> storeOrders)
    {
        return onlineOrders
            .Intersect(storeOrders)
            .Distinct()
            .OrderBy(x => x.ProductName)
            .ToList();
    }
}