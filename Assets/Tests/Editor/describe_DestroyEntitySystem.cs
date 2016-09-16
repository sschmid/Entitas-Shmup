//using NSpec;
//using Entitas;

//class describe_DestroyEntitySystem : nspec {

//    void when_executing() {

//        it["destroys flagged entities"] = () => {

//            // given
//            var pool = TestHelper.CreateCorePool();
//            var system = new ReactiveSystem(new DestroyEntitySystem(pool));
//            var entity = pool.CreateEntity();

//            // when
//            entity.flagDestroy = true;
//            system.Execute();

//            // then
//            pool.count.should_be(0);
//        };

//        it["destroys entities out of screen"] = () => {

//            // given
//            var pool = TestHelper.CreateCorePool();
//            var system = new ReactiveSystem(new DestroyEntitySystem(pool));
//            var entity = pool.CreateEntity();

//            // when
//            entity.isOutOfScreen = true;
//            system.Execute();

//            // then
//            pool.count.should_be(0);
//        };
//    }
//}

