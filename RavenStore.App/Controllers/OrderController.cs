using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using RavenStore.Core.Entities;
using RavenStore.Core.ValueObjects;

namespace RavenStore.App.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IDocumentStore _store;

    public OrderController(IDocumentStore store)
    {
        _store = store;
    }

    [HttpPost]
    public string Post(string customerId)
    {
        using IDocumentSession session = _store.OpenSession();

        Customer customer = session.Load<Customer>(customerId);
        if (customer == null) throw new Exception("Invalid customer id");
        
        Order order = new Order(customer.Id);
        session.Store(order);
        session.SaveChanges();

        return order.Id;
    }

    [HttpPost("/AddProduct")]
    public void AddProduct(string orderId, string productId, int quantity)
    {
        using IDocumentSession session = _store.OpenSession();

        Order order = session.Load<Order>(orderId);
        if (order == null) throw new Exception("Invalid order id");

        Product product = session.Load<Product>(productId);
        if (product == null) throw new Exception("Invalid product id");

        OrderLine line = new OrderLine(product.Id, quantity, product.Price);
        order.Add(line);
        
        session.SaveChanges();
    }
}
