namespace RavenStore.Core.ValueObjects;

public class OrderLine : ValueObject
{
    public OrderLine(string productId, int quantity, decimal price)
    {
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public string ProductId { get; }

    public int Quantity { get; }

    public decimal Price { get; }
    
    public decimal Total => Quantity * Price;
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ProductId;
        yield return Price;
    }
}