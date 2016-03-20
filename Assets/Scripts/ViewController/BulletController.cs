using UnityEngine;

public interface IBulletController : IPooledViewController {
}

public class BulletController : ViewController, IBulletController {

    [SerializeField] Vector3 _minRotation;
    [SerializeField] Vector3 _baseRotation;
    [SerializeField] float _randomRotationFactor;

    [SerializeField] ParticleSystem _despawnPfx;

    Vector3 _rotation;

    void OnEnable() {
        // TODO USe custom random
        _rotation = _minRotation + (_baseRotation * _randomRotationFactor * Random.value);
    }

    public override void Despawn() {

        var pfx = Assets.Clone<ParticleSystem>(_despawnPfx);
        pfx.transform.position = transform.position;
        var totalDuration = pfx.startDelay + pfx.startLifetime + pfx.duration;
        Assets.Destroy(pfx.gameObject, totalDuration);

        Deactivate();
    }

    public void Deactivate() {
        var link = gameObject.GetEntityLink();
        link.entity.gameObjectObjectPool.pool.Push(gameObject);
        gameObject.Unlink();
        gameObject.SetActive(false);
    }

    void Update() {
        transform.Rotate(_rotation);
    }
}
