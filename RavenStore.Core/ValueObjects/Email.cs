namespace RavenStore.Core.ValueObjects;

public class Email : ValueObject
{
    public Email(string address)
    {
        // validation
        if (String.IsNullOrWhiteSpace(address)) throw new Exception("invalid email address");
        if (!address.Contains('@')) throw new Exception("invalid email address");

        Address = address;
    }

    public string Address { get; }

    public override string ToString() => Address.ToLower();

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address.ToLower(); // case-insensitive comparison of email addresses
    }
}