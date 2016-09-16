//using NSpec;
//using Entitas;
//using UnityEngine;

//public class describe_ProcessMoveInputSystem : nspec {

//    void when_input_emmited() {

//        it["only changes the specified player position of an entity accroding to move input"] = () => {
//            // given
//            var inputPool = TestHelper.CreateInputPool();
//            var corePool = TestHelper.CreateCorePool();
//            var inputSystem = new ProcessMoveInputSystem(corePool);
//            var system = (IExecuteSystem)inputPool.CreateSystem(inputSystem);

//            var player1 = corePool.CreateEntity()
//                .AddPosition(Vector3.one)
//                .AddVelocity(new Vector3(2f, 2f, 2f))
//                .AddPlayer("Player1");

//            var player2 = corePool.CreateEntity()
//                .AddPosition(Vector3.one)
//                .AddVelocity(new Vector3(2f, 2f, 2f))
//                .AddPlayer("Player2");

//            var inputVelocity = new Vector3(3f, 4f, 5f);
//            inputPool.CreateEntity()
//                .AddMoveInput(inputVelocity)
//                .AddInputOwner("Player1");

//            // when
//            system.Execute();

//            // then
//            var expectedVelocity = inputVelocity.normalized * ProcessMoveInputSystem.SPEED;
//            player1.position.value.should_be(Vector3.one);
//            player1.velocity.value.should_be(expectedVelocity);

//            player2.position.value.should_be(Vector3.one);
//            player2.velocity.value.should_be(new Vector3(2f, 2f, 2f));

//            inputPool.GetEntities(InputMatcher.MoveInput).Length.should_be(0);
//        };
//    }
//}
