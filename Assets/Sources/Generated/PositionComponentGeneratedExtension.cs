using Entitas;

namespace Entitas {
    public partial class Entity {
        public PositionComponent position { get { return (PositionComponent)GetComponent(BulletsComponentIds.Position); } }

        public bool hasPosition { get { return HasComponent(BulletsComponentIds.Position); } }

        public Entity AddPosition(UnityEngine.Vector3 newValue) {
            var componentPool = GetComponentPool(BulletsComponentIds.Position);
            var component = (PositionComponent)(componentPool.Count > 0 ? componentPool.Pop() : new PositionComponent());
            component.value = newValue;
            return AddComponent(BulletsComponentIds.Position, component);
        }

        public Entity ReplacePosition(UnityEngine.Vector3 newValue) {
            var componentPool = GetComponentPool(BulletsComponentIds.Position);
            var component = (PositionComponent)(componentPool.Count > 0 ? componentPool.Pop() : new PositionComponent());
            component.value = newValue;
            ReplaceComponent(BulletsComponentIds.Position, component);
            return this;
        }

        public Entity RemovePosition() {
            return RemoveComponent(BulletsComponentIds.Position);;
        }
    }
}

    public partial class BulletsMatcher {
        static IMatcher _matcherPosition;

        public static IMatcher Position {
            get {
                if (_matcherPosition == null) {
                    var matcher = (Matcher)Matcher.AllOf(BulletsComponentIds.Position);
                    matcher.componentNames = BulletsComponentIds.componentNames;
                    _matcherPosition = matcher;
                }

                return _matcherPosition;
            }
        }
    }

    public partial class CoreMatcher {
        static IMatcher _matcherPosition;

        public static IMatcher Position {
            get {
                if (_matcherPosition == null) {
                    var matcher = (Matcher)Matcher.AllOf(BulletsComponentIds.Position);
                    matcher.componentNames = BulletsComponentIds.componentNames;
                    _matcherPosition = matcher;
                }

                return _matcherPosition;
            }
        }
    }
