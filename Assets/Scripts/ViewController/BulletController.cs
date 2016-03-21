using UnityEngine;

public interface IBulletController : IViewController {
}

public class BulletController : ViewController, IBulletController {

    [SerializeField] Vector3 _minRotation;
    [SerializeField] Vector3 _baseRotation;
    [SerializeField] float _randomRotationFactor;

    Vector3 _rotation;

    void OnEnable() {
        // TODO Use custom random
        _rotation = _minRotation + (_baseRotation * _randomRotationFactor * Random.value);
    }

    void Update() {
        transform.Rotate(_rotation);
    }
}
