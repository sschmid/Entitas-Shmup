using NSpec;
using Entitas;

class describe_DestroySystem : nspec {

    void when_executing() {

        it["destroys flagged entities"] = () => {

            // given
            var pool = TestHelper.CreateCorePool();
            var system = new ReactiveSystem(new DestroySystem(pool));
            var entity = pool.CreateEntity();

            // when
            entity.flagDestroy = true;
            system.Execute();

            // then
            pool.count.should_be(0);
        };
    }
}

