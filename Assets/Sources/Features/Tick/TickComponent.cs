using Entitas;
using Entitas.CodeGenerator;

[Input, SingleEntity]
public class TickComponent : IComponent {
    public ulong value;
}

