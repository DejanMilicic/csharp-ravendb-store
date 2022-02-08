namespace RavenStore.Core.ValueObjects;

public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address.ToLower();
    }

    public string Address { get; }

    public override string ToString() => Address.ToLower();

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address.ToLower(); // case-insensitive comparison of email addresses
    }
}