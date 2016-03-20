using UnityEngine;

public interface IBulletController : IViewController {
}

public class BulletController : ViewController, IBulletController {

    [SerializeField] Vector3 _minRotation;
    [SerializeField] Vector3 _baseRotation;
    [SerializeField] float _randomRotationFactor;

    [SerializeField] EffectPlayer _despawnEffects;

    Vector3 _rotation;

    void OnEnable() {
        // TODO USe custom random
        _rotation = _minRotation + (_baseRotation * _randomRotationFactor * Random.value);
    }

    public override void Despawn() {
        _despawnEffects.Play(transform.position);
        Deactivate();
    }

    public override void Deactivate() {
        var link = gameObject.GetEntityLink();
        link.entity.gameObjectObjectPool.pool.Push(gameObject);
        gameObject.Unlink();
        gameObject.SetActive(false);
    }

    void Update() {
        transform.Rotate(_rotation);
    }
}
