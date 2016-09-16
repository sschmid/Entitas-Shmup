using Entitas;
using Entitas.CodeGenerator;

[Input, SingleEntity]
public sealed class TickComponent : IComponent {

    public ulong value;
}
