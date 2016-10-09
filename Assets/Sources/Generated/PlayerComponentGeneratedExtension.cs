//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

namespace Entitas {

    public partial class Entity {

        public PlayerComponent player { get { return (PlayerComponent)GetComponent(CoreComponentIds.Player); } }
        public bool hasPlayer { get { return HasComponent(CoreComponentIds.Player); } }

        public Entity AddPlayer(string newId) {
            var component = CreateComponent<PlayerComponent>(CoreComponentIds.Player);
            component.id = newId;
            return AddComponent(CoreComponentIds.Player, component);
        }

        public Entity ReplacePlayer(string newId) {
            var component = CreateComponent<PlayerComponent>(CoreComponentIds.Player);
            component.id = newId;
            ReplaceComponent(CoreComponentIds.Player, component);
            return this;
        }

        public Entity RemovePlayer() {
            return RemoveComponent(CoreComponentIds.Player);
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherPlayer;

        public static IMatcher Player {
            get {
                if(_matcherPlayer == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Player);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherPlayer = matcher;
                }

                return _matcherPlayer;
            }
        }
    }
