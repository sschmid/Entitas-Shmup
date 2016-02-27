using Entitas;

namespace Entitas {
    public partial class Entity {
        public CollisionComponent collision { get { return (CollisionComponent)GetComponent(InputComponentIds.Collision); } }

        public bool hasCollision { get { return HasComponent(InputComponentIds.Collision); } }

        public Entity AddCollision(Entitas.Entity newBullet, Entitas.Entity newTarget) {
            var componentPool = GetComponentPool(InputComponentIds.Collision);
            var component = (CollisionComponent)(componentPool.Count > 0 ? componentPool.Pop() : new CollisionComponent());
            component.bullet = newBullet;
            component.target = newTarget;
            return AddComponent(InputComponentIds.Collision, component);
        }

        public Entity ReplaceCollision(Entitas.Entity newBullet, Entitas.Entity newTarget) {
            var componentPool = GetComponentPool(InputComponentIds.Collision);
            var component = (CollisionComponent)(componentPool.Count > 0 ? componentPool.Pop() : new CollisionComponent());
            component.bullet = newBullet;
            component.target = newTarget;
            ReplaceComponent(InputComponentIds.Collision, component);
            return this;
        }

        public Entity RemoveCollision() {
            return RemoveComponent(InputComponentIds.Collision);;
        }
    }
}

    public partial class InputMatcher {
        static IMatcher _matcherCollision;

        public static IMatcher Collision {
            get {
                if (_matcherCollision == null) {
                    var matcher = (Matcher)Matcher.AllOf(InputComponentIds.Collision);
                    matcher.componentNames = InputComponentIds.componentNames;
                    _matcherCollision = matcher;
                }

                return _matcherCollision;
            }
        }
    }
