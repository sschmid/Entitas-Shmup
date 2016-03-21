using UnityEngine;

public class PathEventHandler : MonoBehaviour {

    [SerializeField] ViewController _controller;

    public void HandlePathComplete() {
        var entity = _controller.gameObject.GetEntityLink().entity;
        entity.isOutOfScreen = true;
    }
}
