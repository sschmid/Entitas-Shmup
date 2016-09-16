using Entitas;

[Input]
public sealed class CollisionComponent : IComponent {

    public Entity self;
    public Entity other;
}
