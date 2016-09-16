using Entitas;
using UnityEngine;

[Core, Bullets]
public sealed class PositionComponent : IComponent {
    public Vector3 value;
}
