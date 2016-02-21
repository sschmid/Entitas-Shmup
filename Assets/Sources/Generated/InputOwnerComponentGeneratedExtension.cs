using Entitas;

namespace Entitas {
    public partial class Entity {
        public InputOwnerComponent inputOwner { get { return (InputOwnerComponent)GetComponent(InputComponentIds.InputOwner); } }

        public bool hasInputOwner { get { return HasComponent(InputComponentIds.InputOwner); } }

        public Entity AddInputOwner(string newPlayerId) {
            var componentPool = GetComponentPool(InputComponentIds.InputOwner);
            var component = (InputOwnerComponent)(componentPool.Count > 0 ? componentPool.Pop() : new InputOwnerComponent());
            component.playerId = newPlayerId;
            return AddComponent(InputComponentIds.InputOwner, component);
        }

        public Entity ReplaceInputOwner(string newPlayerId) {
            var componentPool = GetComponentPool(InputComponentIds.InputOwner);
            var component = (InputOwnerComponent)(componentPool.Count > 0 ? componentPool.Pop() : new InputOwnerComponent());
            component.playerId = newPlayerId;
            ReplaceComponent(InputComponentIds.InputOwner, component);
            return this;
        }

        public Entity RemoveInputOwner() {
            return RemoveComponent(InputComponentIds.InputOwner);;
        }
    }
}

    public partial class InputMatcher {
        static IMatcher _matcherInputOwner;

        public static IMatcher InputOwner {
            get {
                if (_matcherInputOwner == null) {
                    var matcher = (Matcher)Matcher.AllOf(InputComponentIds.InputOwner);
                    matcher.componentNames = InputComponentIds.componentNames;
                    _matcherInputOwner = matcher;
                }

                return _matcherInputOwner;
            }
        }
    }
