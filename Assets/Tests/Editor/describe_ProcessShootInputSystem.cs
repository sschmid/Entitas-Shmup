//using NSpec;
//using Entitas;
//using UnityEngine;
//
//public class describe_ProcessShootInputSystem : nspec {
//
//    void when_input_emmited() {
//
//        it["creates a bullet at player's position"] = () => {
//
//            // given
//            var inputPool = TestHelper.CreateInputPool();
//            var corePool = TestHelper.CreateCorePool();
//            var bulletsPool = TestHelper.CreateBulletsPool();
//
//            var inputSystem = new ProcessShootInputSystem(corePool, bulletsPool);
//
//            var system = (IExecuteSystem)inputPool.CreateSystem(inputSystem);
//
//            var player1 = corePool.CreateEntity()
//                .AddPosition(new Vector3(1, 1, 1))
//                .AddPlayer("Player1");
//
//            corePool.CreateEntity()
//                .AddPosition(new Vector3(2, 2, 2))
//                .AddPlayer("Player2");
//
//            inputPool.CreateEntity()
//                .IsShootInput(true)
//                .AddInputOwner("Player1");
//
//            // when
//            system.Execute();
//
//            // then
//            var bullet = bulletsPool.GetEntities(BulletsMatcher.Bullet).SingleEntity();
//            bullet.should_not_be_null();
//            bullet.position.value.should_be(player1.position.value);
//            bullet.hasVelocity.should_be_true();
//            bullet.viewObjectPool.pool.should_not_be_null();
//
//            inputPool.GetEntities(InputMatcher.ShootInput).Length.should_be(0);
//        };
//    }
//}
