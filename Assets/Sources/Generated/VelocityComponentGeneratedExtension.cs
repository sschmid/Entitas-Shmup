using Entitas;

namespace Entitas {
    public partial class Entity {
        public VelocityComponent velocity { get { return (VelocityComponent)GetComponent(BulletsComponentIds.Velocity); } }

        public bool hasVelocity { get { return HasComponent(BulletsComponentIds.Velocity); } }

        public Entity AddVelocity(UnityEngine.Vector3 newValue) {
            var componentPool = GetComponentPool(BulletsComponentIds.Velocity);
            var component = (VelocityComponent)(componentPool.Count > 0 ? componentPool.Pop() : new VelocityComponent());
            component.value = newValue;
            return AddComponent(BulletsComponentIds.Velocity, component);
        }

        public Entity ReplaceVelocity(UnityEngine.Vector3 newValue) {
            var componentPool = GetComponentPool(BulletsComponentIds.Velocity);
            var component = (VelocityComponent)(componentPool.Count > 0 ? componentPool.Pop() : new VelocityComponent());
            component.value = newValue;
            ReplaceComponent(BulletsComponentIds.Velocity, component);
            return this;
        }

        public Entity RemoveVelocity() {
            return RemoveComponent(BulletsComponentIds.Velocity);;
        }
    }
}

    public partial class BulletsMatcher {
        static IMatcher _matcherVelocity;

        public static IMatcher Velocity {
            get {
                if (_matcherVelocity == null) {
                    var matcher = (Matcher)Matcher.AllOf(BulletsComponentIds.Velocity);
                    matcher.componentNames = BulletsComponentIds.componentNames;
                    _matcherVelocity = matcher;
                }

                return _matcherVelocity;
            }
        }
    }

    public partial class CoreMatcher {
        static IMatcher _matcherVelocity;

        public static IMatcher Velocity {
            get {
                if (_matcherVelocity == null) {
                    var matcher = (Matcher)Matcher.AllOf(BulletsComponentIds.Velocity);
                    matcher.componentNames = BulletsComponentIds.componentNames;
                    _matcherVelocity = matcher;
                }

                return _matcherVelocity;
            }
        }
    }
