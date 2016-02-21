using Entitas;

namespace Entitas {
    public partial class Entity {
        public ResourceComponent resource { get { return (ResourceComponent)GetComponent(CoreComponentIds.Resource); } }

        public bool hasResource { get { return HasComponent(CoreComponentIds.Resource); } }

        public Entity AddResource(string newName) {
            var componentPool = GetComponentPool(CoreComponentIds.Resource);
            var component = (ResourceComponent)(componentPool.Count > 0 ? componentPool.Pop() : new ResourceComponent());
            component.name = newName;
            return AddComponent(CoreComponentIds.Resource, component);
        }

        public Entity ReplaceResource(string newName) {
            var componentPool = GetComponentPool(CoreComponentIds.Resource);
            var component = (ResourceComponent)(componentPool.Count > 0 ? componentPool.Pop() : new ResourceComponent());
            component.name = newName;
            ReplaceComponent(CoreComponentIds.Resource, component);
            return this;
        }

        public Entity RemoveResource() {
            return RemoveComponent(CoreComponentIds.Resource);;
        }
    }
}

    public partial class CoreMatcher {
        static IMatcher _matcherResource;

        public static IMatcher Resource {
            get {
                if (_matcherResource == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Resource);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherResource = matcher;
                }

                return _matcherResource;
            }
        }
    }
