using UnityEngine;

public class InputController : MonoBehaviour {

    void Update() {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        if (moveX != 0 || moveY != 0) {
            Pools.input.CreateEntity()
                .AddMoveInput(new Vector3(moveX, moveY));
        }
    }
}
