namespace RavenStore.Core.Entities;

public abstract class Entity
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
}