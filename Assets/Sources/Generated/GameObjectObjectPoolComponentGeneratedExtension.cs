using Entitas;

namespace Entitas {
    public partial class Entity {
        public GameObjectObjectPoolComponent gameObjectObjectPool { get { return (GameObjectObjectPoolComponent)GetComponent(BulletsComponentIds.GameObjectObjectPool); } }

        public bool hasGameObjectObjectPool { get { return HasComponent(BulletsComponentIds.GameObjectObjectPool); } }

        public Entity AddGameObjectObjectPool(ObjectPool<UnityEngine.GameObject> newPool) {
            var componentPool = GetComponentPool(BulletsComponentIds.GameObjectObjectPool);
            var component = (GameObjectObjectPoolComponent)(componentPool.Count > 0 ? componentPool.Pop() : new GameObjectObjectPoolComponent());
            component.pool = newPool;
            return AddComponent(BulletsComponentIds.GameObjectObjectPool, component);
        }

        public Entity ReplaceGameObjectObjectPool(ObjectPool<UnityEngine.GameObject> newPool) {
            var componentPool = GetComponentPool(BulletsComponentIds.GameObjectObjectPool);
            var component = (GameObjectObjectPoolComponent)(componentPool.Count > 0 ? componentPool.Pop() : new GameObjectObjectPoolComponent());
            component.pool = newPool;
            ReplaceComponent(BulletsComponentIds.GameObjectObjectPool, component);
            return this;
        }

        public Entity RemoveGameObjectObjectPool() {
            return RemoveComponent(BulletsComponentIds.GameObjectObjectPool);;
        }
    }
}

    public partial class BulletsMatcher {
        static IMatcher _matcherGameObjectObjectPool;

        public static IMatcher GameObjectObjectPool {
            get {
                if (_matcherGameObjectObjectPool == null) {
                    var matcher = (Matcher)Matcher.AllOf(BulletsComponentIds.GameObjectObjectPool);
                    matcher.componentNames = BulletsComponentIds.componentNames;
                    _matcherGameObjectObjectPool = matcher;
                }

                return _matcherGameObjectObjectPool;
            }
        }
    }
