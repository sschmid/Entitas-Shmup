using Entitas;

[Core, Bullets]
public sealed class HealthComponent : IComponent {

    public int value;

    public override string ToString() {
        return "Health(" + value + ")";
    }
}
