using Entitas;

[Input]
public class CollisionComponent : IComponent {
    public Entity self;
    public Entity other;
}
