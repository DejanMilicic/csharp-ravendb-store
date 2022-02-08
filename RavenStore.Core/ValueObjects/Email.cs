namespace RavenStore.Core.ValueObjects;

public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address.ToLower();
    }

    public string Address { get; }

    public override string ToString() => Address.ToLower();
}