using UnityEngine;

public class PathCompleteEventHandler : MonoBehaviour {

    [SerializeField]
    ViewController _controller;

    public void HandlePathComplete() {
        var entity = _controller.gameObject.GetEntityLink().entity;
        entity.isOutOfScreen = true;
    }
}
