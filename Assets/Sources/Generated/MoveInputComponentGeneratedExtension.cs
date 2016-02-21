using Entitas;

namespace Entitas {
    public partial class Entity {
        public MoveInputComponent moveInput { get { return (MoveInputComponent)GetComponent(InputComponentIds.MoveInput); } }

        public bool hasMoveInput { get { return HasComponent(InputComponentIds.MoveInput); } }

        public Entity AddMoveInput(UnityEngine.Vector3 newDirection) {
            var componentPool = GetComponentPool(InputComponentIds.MoveInput);
            var component = (MoveInputComponent)(componentPool.Count > 0 ? componentPool.Pop() : new MoveInputComponent());
            component.direction = newDirection;
            return AddComponent(InputComponentIds.MoveInput, component);
        }

        public Entity ReplaceMoveInput(UnityEngine.Vector3 newDirection) {
            var componentPool = GetComponentPool(InputComponentIds.MoveInput);
            var component = (MoveInputComponent)(componentPool.Count > 0 ? componentPool.Pop() : new MoveInputComponent());
            component.direction = newDirection;
            ReplaceComponent(InputComponentIds.MoveInput, component);
            return this;
        }

        public Entity RemoveMoveInput() {
            return RemoveComponent(InputComponentIds.MoveInput);;
        }
    }
}

    public partial class InputMatcher {
        static IMatcher _matcherMoveInput;

        public static IMatcher MoveInput {
            get {
                if (_matcherMoveInput == null) {
                    var matcher = (Matcher)Matcher.AllOf(InputComponentIds.MoveInput);
                    matcher.componentNames = InputComponentIds.componentNames;
                    _matcherMoveInput = matcher;
                }

                return _matcherMoveInput;
            }
        }
    }
