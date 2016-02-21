using UnityEngine;

public class InputController : MonoBehaviour {

    const string PLAYER1_ID = "Player1";

    void Update() {
        var inputPool = Pools.input;

        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        inputPool.CreateEntity()
            .AddMoveInput(new Vector3(moveX, moveY))
            .AddInputOwner(PLAYER1_ID);

        var fire = Input.GetAxisRaw("Fire1");

        if (fire != 0) {
            inputPool.CreateEntity()
                .IsShootInput(true)
                .AddInputOwner(PLAYER1_ID);
        }
    }
}
