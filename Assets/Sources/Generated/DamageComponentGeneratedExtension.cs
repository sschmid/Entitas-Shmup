using Entitas;

namespace Entitas {
    public partial class Entity {
        public DamageComponent damage { get { return (DamageComponent)GetComponent(BulletsComponentIds.Damage); } }

        public bool hasDamage { get { return HasComponent(BulletsComponentIds.Damage); } }

        public Entity AddDamage(int newValue) {
            var componentPool = GetComponentPool(BulletsComponentIds.Damage);
            var component = (DamageComponent)(componentPool.Count > 0 ? componentPool.Pop() : new DamageComponent());
            component.value = newValue;
            return AddComponent(BulletsComponentIds.Damage, component);
        }

        public Entity ReplaceDamage(int newValue) {
            var componentPool = GetComponentPool(BulletsComponentIds.Damage);
            var component = (DamageComponent)(componentPool.Count > 0 ? componentPool.Pop() : new DamageComponent());
            component.value = newValue;
            ReplaceComponent(BulletsComponentIds.Damage, component);
            return this;
        }

        public Entity RemoveDamage() {
            return RemoveComponent(BulletsComponentIds.Damage);;
        }
    }
}

    public partial class BulletsMatcher {
        static IMatcher _matcherDamage;

        public static IMatcher Damage {
            get {
                if (_matcherDamage == null) {
                    var matcher = (Matcher)Matcher.AllOf(BulletsComponentIds.Damage);
                    matcher.componentNames = BulletsComponentIds.componentNames;
                    _matcherDamage = matcher;
                }

                return _matcherDamage;
            }
        }
    }
