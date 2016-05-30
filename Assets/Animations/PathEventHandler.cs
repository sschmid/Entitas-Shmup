using UnityEngine;

public class PathEventHandler : MonoBehaviour {

    [SerializeField] ViewController _controller;

    public void HandlePathComplete() {
        _controller.gameObject.GetEntityLink().entity.isOutOfScreen = true;
    }
}
