using Entitas;
using UnityEngine;

[Core, Bullets]
public sealed class ViewObjectPoolComponent : IComponent {

    public ObjectPool<GameObject> pool;
}
