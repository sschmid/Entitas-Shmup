using Entitas;
using UnityEngine;

[Core, Bullets]
public class GameObjectObjectPoolComponent : IComponent {
    public ObjectPool<GameObject> pool;
}

