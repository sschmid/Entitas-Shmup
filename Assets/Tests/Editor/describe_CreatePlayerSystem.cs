using Entitas;
using NSpec;

class describe_CreatePlayerSystem : nspec {

    void when_initializing() {

        it["creates an entity with a resource"] = () => {

            // given
            var pool = new Pool(CoreComponentIds.TotalComponents);
            var system = (IInitializeSystem)pool.CreateSystem<CreatePlayerSystem>();

            // when
            system.Initialize();

            // then
            var entity = pool.GetEntities(CoreMatcher.Resource).SingleEntity();
            entity.should_not_be_null();
            entity.resource.name.should_not_be_null();
        };
    }
}
