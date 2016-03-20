using UnityEngine;

public class PathEventHandler : MonoBehaviour {

    [SerializeField] ViewController _controller;

    public void Destroy() {
        _controller.gameObject.GetEntityLink().entity.isOutOfScreen = true;
        _controller.gameObject.GetEntityLink().entity.flagDestroy = true;
    }
}
