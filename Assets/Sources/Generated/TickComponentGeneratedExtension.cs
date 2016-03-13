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
        public TickComponent tick { get { return (TickComponent)GetComponent(InputComponentIds.Tick); } }

        public bool hasTick { get { return HasComponent(InputComponentIds.Tick); } }

        public Entity AddTick(ulong newValue) {
            var component = CreateComponent<TickComponent>(InputComponentIds.Tick);
            component.value = newValue;
            return AddComponent(InputComponentIds.Tick, component);
        }

        public Entity ReplaceTick(ulong newValue) {
            var component = CreateComponent<TickComponent>(InputComponentIds.Tick);
            component.value = newValue;
            ReplaceComponent(InputComponentIds.Tick, component);
            return this;
        }

        public Entity RemoveTick() {
            return RemoveComponent(InputComponentIds.Tick);
        }
    }

    public partial class Pool {
        public Entity tickEntity { get { return GetGroup(InputMatcher.Tick).GetSingleEntity(); } }

        public TickComponent tick { get { return tickEntity.tick; } }

        public bool hasTick { get { return tickEntity != null; } }

        public Entity SetTick(ulong newValue) {
            if (hasTick) {
                throw new EntitasException("Could not set tick!\n" + this + " already has an entity with TickComponent!",
                    "You should check if the pool already has a tickEntity before setting it or use pool.ReplaceTick().");
            }
            var entity = CreateEntity();
            entity.AddTick(newValue);
            return entity;
        }

        public Entity ReplaceTick(ulong newValue) {
            var entity = tickEntity;
            if (entity == null) {
                entity = SetTick(newValue);
            } else {
                entity.ReplaceTick(newValue);
            }

            return entity;
        }

        public void RemoveTick() {
            DestroyEntity(tickEntity);
        }
    }
}

    public partial class InputMatcher {
        static IMatcher _matcherTick;

        public static IMatcher Tick {
            get {
                if (_matcherTick == null) {
                    var matcher = (Matcher)Matcher.AllOf(InputComponentIds.Tick);
                    matcher.componentNames = InputComponentIds.componentNames;
                    _matcherTick = matcher;
                }

                return _matcherTick;
            }
        }
    }
