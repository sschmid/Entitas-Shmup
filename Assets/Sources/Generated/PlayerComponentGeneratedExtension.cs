using Entitas;

namespace Entitas {
    public partial class Entity {
        public PlayerComponent player { get { return (PlayerComponent)GetComponent(CoreComponentIds.Player); } }

        public bool hasPlayer { get { return HasComponent(CoreComponentIds.Player); } }

        public Entity AddPlayer(string newId) {
            var componentPool = GetComponentPool(CoreComponentIds.Player);
            var component = (PlayerComponent)(componentPool.Count > 0 ? componentPool.Pop() : new PlayerComponent());
            component.id = newId;
            return AddComponent(CoreComponentIds.Player, component);
        }

        public Entity ReplacePlayer(string newId) {
            var componentPool = GetComponentPool(CoreComponentIds.Player);
            var component = (PlayerComponent)(componentPool.Count > 0 ? componentPool.Pop() : new PlayerComponent());
            component.id = newId;
            ReplaceComponent(CoreComponentIds.Player, component);
            return this;
        }

        public Entity RemovePlayer() {
            return RemoveComponent(CoreComponentIds.Player);;
        }
    }
}

    public partial class CoreMatcher {
        static IMatcher _matcherPlayer;

        public static IMatcher Player {
            get {
                if (_matcherPlayer == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Player);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherPlayer = matcher;
                }

                return _matcherPlayer;
            }
        }
    }
