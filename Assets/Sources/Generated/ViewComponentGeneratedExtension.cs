using Entitas;

namespace Entitas {
    public partial class Entity {
        public ViewComponent view { get { return (ViewComponent)GetComponent(BulletsComponentIds.View); } }

        public bool hasView { get { return HasComponent(BulletsComponentIds.View); } }

        public Entity AddView(UnityEngine.GameObject newGameObject) {
            var componentPool = GetComponentPool(BulletsComponentIds.View);
            var component = (ViewComponent)(componentPool.Count > 0 ? componentPool.Pop() : new ViewComponent());
            component.gameObject = newGameObject;
            return AddComponent(BulletsComponentIds.View, component);
        }

        public Entity ReplaceView(UnityEngine.GameObject newGameObject) {
            var componentPool = GetComponentPool(BulletsComponentIds.View);
            var component = (ViewComponent)(componentPool.Count > 0 ? componentPool.Pop() : new ViewComponent());
            component.gameObject = newGameObject;
            ReplaceComponent(BulletsComponentIds.View, component);
            return this;
        }

        public Entity RemoveView() {
            return RemoveComponent(BulletsComponentIds.View);;
        }
    }
}

    public partial class BulletsMatcher {
        static IMatcher _matcherView;

        public static IMatcher View {
            get {
                if (_matcherView == null) {
                    var matcher = (Matcher)Matcher.AllOf(BulletsComponentIds.View);
                    matcher.componentNames = BulletsComponentIds.componentNames;
                    _matcherView = matcher;
                }

                return _matcherView;
            }
        }
    }

    public partial class CoreMatcher {
        static IMatcher _matcherView;

        public static IMatcher View {
            get {
                if (_matcherView == null) {
                    var matcher = (Matcher)Matcher.AllOf(BulletsComponentIds.View);
                    matcher.componentNames = BulletsComponentIds.componentNames;
                    _matcherView = matcher;
                }

                return _matcherView;
            }
        }
    }
