using Entitas;

namespace Entitas {
    public partial class Entity {
        public ResourceComponent resource { get { return (ResourceComponent)GetComponent(BulletsComponentIds.Resource); } }

        public bool hasResource { get { return HasComponent(BulletsComponentIds.Resource); } }

        public Entity AddResource(string newName) {
            var componentPool = GetComponentPool(BulletsComponentIds.Resource);
            var component = (ResourceComponent)(componentPool.Count > 0 ? componentPool.Pop() : new ResourceComponent());
            component.name = newName;
            return AddComponent(BulletsComponentIds.Resource, component);
        }

        public Entity ReplaceResource(string newName) {
            var componentPool = GetComponentPool(BulletsComponentIds.Resource);
            var component = (ResourceComponent)(componentPool.Count > 0 ? componentPool.Pop() : new ResourceComponent());
            component.name = newName;
            ReplaceComponent(BulletsComponentIds.Resource, component);
            return this;
        }

        public Entity RemoveResource() {
            return RemoveComponent(BulletsComponentIds.Resource);;
        }
    }
}

    public partial class BulletsMatcher {
        static IMatcher _matcherResource;

        public static IMatcher Resource {
            get {
                if (_matcherResource == null) {
                    var matcher = (Matcher)Matcher.AllOf(BulletsComponentIds.Resource);
                    matcher.componentNames = BulletsComponentIds.componentNames;
                    _matcherResource = matcher;
                }

                return _matcherResource;
            }
        }
    }

    public partial class CoreMatcher {
        static IMatcher _matcherResource;

        public static IMatcher Resource {
            get {
                if (_matcherResource == null) {
                    var matcher = (Matcher)Matcher.AllOf(BulletsComponentIds.Resource);
                    matcher.componentNames = BulletsComponentIds.componentNames;
                    _matcherResource = matcher;
                }

                return _matcherResource;
            }
        }
    }
