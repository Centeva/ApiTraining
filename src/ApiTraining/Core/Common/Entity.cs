namespace ApiTraining.Core.Common;

public abstract class Entity
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
}
