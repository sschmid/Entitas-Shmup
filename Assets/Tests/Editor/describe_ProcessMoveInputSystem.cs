using NSpec;
using Entitas;
using UnityEngine;

public class describe_ProcessMoveInputSystem : nspec {

    void when_input_emmited() {

        it["changes the position of an entity accroding to move input"] = () => {

            // given
            var inputPool = new Pool(InputComponentIds.TotalComponents);
            var corePool = new Pool(CoreComponentIds.TotalComponents);
            var inputSystem = new ProcessMoveInputSystem(corePool);
            var system = (IExecuteSystem)inputPool.CreateSystem(inputSystem);

            corePool.CreateEntity().AddPosition(new Vector3(3, 4, 5));
            inputPool.CreateEntity().AddMoveInput(new Vector3(2, 3, 1));

            // when
            system.Execute();

            // then
            var entity = corePool.GetEntities(CoreMatcher.Position).SingleEntity();
            entity.should_not_be_null();
            entity.position.value.should_be(new Vector3(5, 7, 6));

            inputPool.GetEntities(InputMatcher.MoveInput).Length.should_be(0);
        };
    }
}
