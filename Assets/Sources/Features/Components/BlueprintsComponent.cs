using Entitas;
using Entitas.CodeGenerator;
using Entitas.Unity.Serialization.Blueprints;

[Blueprints, SingleEntity]
public sealed class BlueprintsComponent : IComponent {

    public Blueprints instance;
}
