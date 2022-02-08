using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using RavenStore.Core.Entities;

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
}
