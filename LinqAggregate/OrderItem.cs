using System;

public record OrderItem(
    int Id,
    string CustomerName,
    string ProductName,
    string Category,
    decimal Price,
    int Quantity)
{
    public virtual bool Equals(OrderItem? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return string.Equals(ProductName, other.ProductName, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return StringComparer.OrdinalIgnoreCase.GetHashCode(ProductName ?? string.Empty);
    }
}