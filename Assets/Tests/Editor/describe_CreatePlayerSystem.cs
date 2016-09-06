using Entitas;
using NSpec;

class describe_CreatePlayerSystem : nspec {

    void when_initializing() {

        it["creates an entity with a resource and position"] = () => {

            // given
            var pool = TestHelper.CreateCorePool();
            var system = (IInitializeSystem)pool.CreateSystem(new CreatePlayerSystem());

            // when
            system.Initialize();

            // then
            var entity = pool.GetEntities(CoreMatcher.Asset).SingleEntity();
            entity.GetComponents().Length.should_be(3);
            entity.should_not_be_null();
            entity.hasPlayer.should_be_true();
            entity.hasPosition.should_be_true();
            entity.asset.name.should_not_be_null();
        };
    }
}
