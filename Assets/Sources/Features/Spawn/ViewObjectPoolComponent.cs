using Entitas;
using UnityEngine;

[Core, Bullets]
public class ViewObjectPoolComponent : IComponent {
    public ObjectPool<GameObject> pool;
}

