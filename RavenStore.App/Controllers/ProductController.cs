using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using RavenStore.Core.Entities;

namespace RavenStore.App.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IDocumentStore _store;

    public ProductController(IDocumentStore store)
    {
        _store = store;
    }

    [HttpPost]
    public string Post(string name, decimal price)
    {
        Product product = new Product(name, price);

        using IDocumentSession session = _store.OpenSession();
        session.Store(product);
        session.SaveChanges();

        return product.Id;
    }
}
