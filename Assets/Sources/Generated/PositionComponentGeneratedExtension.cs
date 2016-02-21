using Entitas;

namespace Entitas {
    public partial class Entity {
        public PositionComponent position { get { return (PositionComponent)GetComponent(CoreComponentIds.Position); } }

        public bool hasPosition { get { return HasComponent(CoreComponentIds.Position); } }

        public Entity AddPosition(UnityEngine.Vector3 newValue) {
            var componentPool = GetComponentPool(CoreComponentIds.Position);
            var component = (PositionComponent)(componentPool.Count > 0 ? componentPool.Pop() : new PositionComponent());
            component.value = newValue;
            return AddComponent(CoreComponentIds.Position, component);
        }

        public Entity ReplacePosition(UnityEngine.Vector3 newValue) {
            var componentPool = GetComponentPool(CoreComponentIds.Position);
            var component = (PositionComponent)(componentPool.Count > 0 ? componentPool.Pop() : new PositionComponent());
            component.value = newValue;
            ReplaceComponent(CoreComponentIds.Position, component);
            return this;
        }

        public Entity RemovePosition() {
            return RemoveComponent(CoreComponentIds.Position);;
        }
    }
}

    public partial class CoreMatcher {
        static IMatcher _matcherPosition;

        public static IMatcher Position {
            get {
                if (_matcherPosition == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Position);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherPosition = matcher;
                }

                return _matcherPosition;
            }
        }
    }
