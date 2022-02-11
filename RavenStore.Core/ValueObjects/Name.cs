namespace RavenStore.Core.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        // validation
        if (String.IsNullOrWhiteSpace(firstName)) throw new Exception("invalid firstName");
        if (String.IsNullOrWhiteSpace(lastName)) throw new Exception("invalid lastName");

        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }
    
    public string LastName { get; }

    public override string ToString() => $"{FirstName} {LastName}";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}