using Entitas;
using UnityEngine;

[Bullets]
public class GameObjectObjectPoolComponent : IComponent {
    public ObjectPool<GameObject> pool;
}

