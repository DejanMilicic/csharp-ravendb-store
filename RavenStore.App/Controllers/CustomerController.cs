using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using RavenStore.Core.Entities;
using RavenStore.Core.ValueObjects;

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
    public string Post(string firstName, string lastName, string emailAddress)
    {
        Name name = new Name(firstName, lastName);
        Email email = new Email(emailAddress);

        Customer customer = new Customer(name, email);
        
        using IDocumentSession session = _store.OpenSession();
        session.Store(customer);
        session.SaveChanges();

        return customer.Id;
    }
}
