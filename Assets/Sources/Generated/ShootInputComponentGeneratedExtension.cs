using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly ShootInputComponent shootInputComponent = new ShootInputComponent();

        public bool isShootInput {
            get { return HasComponent(InputComponentIds.ShootInput); }
            set {
                if (value != isShootInput) {
                    if (value) {
                        AddComponent(InputComponentIds.ShootInput, shootInputComponent);
                    } else {
                        RemoveComponent(InputComponentIds.ShootInput);
                    }
                }
            }
        }

        public Entity IsShootInput(bool value) {
            isShootInput = value;
            return this;
        }
    }
}

    public partial class InputMatcher {
        static IMatcher _matcherShootInput;

        public static IMatcher ShootInput {
            get {
                if (_matcherShootInput == null) {
                    var matcher = (Matcher)Matcher.AllOf(InputComponentIds.ShootInput);
                    matcher.componentNames = InputComponentIds.componentNames;
                    _matcherShootInput = matcher;
                }

                return _matcherShootInput;
            }
        }
    }
