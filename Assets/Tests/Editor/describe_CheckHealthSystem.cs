using NSpec;
using Entitas;

class describe_CheckHealthSystem : nspec {

    void when_executing() {

        it["flags entities destroy when health 0 or less"] = () => {

            // given
            var pool = new Pool(CoreComponentIds.TotalComponents);
            var entity = pool.CreateEntity().AddHealth(1);
            var system = (IExecuteSystem)pool.CreateSystem<CheckHealthSystem>();

            // when
            entity.ReplaceHealth(0);
            system.Execute();

            // then
            entity.flagDestroy.should_be_true();
        };

        it["doesn't flag entities destroy when health greater "] = () => {

            // given
            var pool = new Pool(CoreComponentIds.TotalComponents);
            var entity = pool.CreateEntity().AddHealth(1);
            var system = (IExecuteSystem)pool.CreateSystem<CheckHealthSystem>();

            // when
            entity.ReplaceHealth(2);
            system.Execute();

            // then
            entity.flagDestroy.should_be_false();
        };
    }
}

