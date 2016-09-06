using NSpec;
using Entitas;

class describe_CheckHealthSystem : nspec {

    void when_executing() {

        Pool pool = null;
        Entity entity = null;
        IExecuteSystem system = null;

        before = () => {
            pool = TestHelper.CreateCorePool();
            entity = pool.CreateEntity().AddHealth(1);
            system = (IExecuteSystem)pool.CreateSystem(new CheckHealthSystem());
        };

        it["flags entities destroy when health 0 or less"] = () => {

            // when
            entity.ReplaceHealth(0);
            system.Execute();

            // then
            entity.flagDestroy.should_be_true();
        };

        it["doesn't flag entities destroy when health greater 0"] = () => {

            // when
            entity.ReplaceHealth(2);
            system.Execute();

            // then
            entity.flagDestroy.should_be_false();
        };
    }
}

