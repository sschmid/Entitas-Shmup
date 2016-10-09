using Entitas;

[Core]
public sealed class PlayerComponent : IComponent {

    public string id;

    public override string ToString() {
        return "Player(" + id + ")";
    }
}
