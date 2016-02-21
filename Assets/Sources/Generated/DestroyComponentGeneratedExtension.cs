using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly DestroyComponent destroyComponent = new DestroyComponent();

        public bool flagDestroy {
            get { return HasComponent(BulletsComponentIds.Destroy); }
            set {
                if (value != flagDestroy) {
                    if (value) {
                        AddComponent(BulletsComponentIds.Destroy, destroyComponent);
                    } else {
                        RemoveComponent(BulletsComponentIds.Destroy);
                    }
                }
            }
        }

        public Entity FlagDestroy(bool value) {
            flagDestroy = value;
            return this;
        }
    }
}

    public partial class BulletsMatcher {
        static IMatcher _matcherDestroy;

        public static IMatcher Destroy {
            get {
                if (_matcherDestroy == null) {
                    var matcher = (Matcher)Matcher.AllOf(BulletsComponentIds.Destroy);
                    matcher.componentNames = BulletsComponentIds.componentNames;
                    _matcherDestroy = matcher;
                }

                return _matcherDestroy;
            }
        }
    }

    public partial class CoreMatcher {
        static IMatcher _matcherDestroy;

        public static IMatcher Destroy {
            get {
                if (_matcherDestroy == null) {
                    var matcher = (Matcher)Matcher.AllOf(BulletsComponentIds.Destroy);
                    matcher.componentNames = BulletsComponentIds.componentNames;
                    _matcherDestroy = matcher;
                }

                return _matcherDestroy;
            }
        }
    }
