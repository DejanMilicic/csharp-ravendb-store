using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using RavenStore.Core.Entities;

namespace RavenStore.App.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IDocumentStore _store;

    public CustomerController(IDocumentStore store)
    {
        _store = store;
    }

    [HttpPost]
    public void Post(Customer customer)
    {
        using IDocumentSession session = _store.OpenSession();

        session.Store(customer);
        session.SaveChanges();
    }
}

