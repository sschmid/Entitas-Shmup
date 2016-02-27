using Entitas;

namespace Entitas {
    public partial class Entity {
        public HealthComponent health { get { return (HealthComponent)GetComponent(CoreComponentIds.Health); } }

        public bool hasHealth { get { return HasComponent(CoreComponentIds.Health); } }

        public Entity AddHealth(int newValue) {
            var componentPool = GetComponentPool(CoreComponentIds.Health);
            var component = (HealthComponent)(componentPool.Count > 0 ? componentPool.Pop() : new HealthComponent());
            component.value = newValue;
            return AddComponent(CoreComponentIds.Health, component);
        }

        public Entity ReplaceHealth(int newValue) {
            var componentPool = GetComponentPool(CoreComponentIds.Health);
            var component = (HealthComponent)(componentPool.Count > 0 ? componentPool.Pop() : new HealthComponent());
            component.value = newValue;
            ReplaceComponent(CoreComponentIds.Health, component);
            return this;
        }

        public Entity RemoveHealth() {
            return RemoveComponent(CoreComponentIds.Health);;
        }
    }
}

    public partial class CoreMatcher {
        static IMatcher _matcherHealth;

        public static IMatcher Health {
            get {
                if (_matcherHealth == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Health);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherHealth = matcher;
                }

                return _matcherHealth;
            }
        }
    }
