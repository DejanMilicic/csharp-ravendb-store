namespace RavenStore.Core.Entities;

public abstract class Entity
{
    public string Id { get; } = Guid.NewGuid().ToString();
}