using Entitas;
using UnityEngine;

public sealed class InputSystem : ISetPools, IExecuteSystem, ICleanupSystem {

    const string PLAYER1_ID = "Player1";

    Pools _pools;
    Group _moveInputs;
    Group _shootInputs;

    public void SetPools(Pools pools) {
        _pools = pools;
        _moveInputs = pools.input.GetGroup(InputMatcher.MoveInput);
        _shootInputs = pools.input.GetGroup(InputMatcher.ShootInput);
    }

    public void Execute() {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        _pools.input.CreateEntity()
                 .AddMoveInput(new Vector3(moveX, moveY))
                 .AddInputOwner(PLAYER1_ID);

        var fire = Input.GetAxisRaw("Fire1");

        if(fire != 0) {
            _pools.input.CreateEntity()
                     .IsShootInput(true)
                     .AddInputOwner(PLAYER1_ID);
        }
    }

    public void Cleanup() {
        foreach(var e in _moveInputs.GetEntities()) {
            _pools.input.DestroyEntity(e);
        }

        foreach(var e in _shootInputs.GetEntities()) {
            _pools.input.DestroyEntity(e);
        }
    }
}
