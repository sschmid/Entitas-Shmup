using UnityEngine;

public interface IEnemyController : IViewController {
    void InitWithWave(int wave);
}

public class EnemyViewController : AnimatorViewController, IEnemyController {

    [SerializeField]
    EffectPlayer _despawnEffects;

    int _wave;
    CameraShake _camerShake;

    public void InitWithWave(int wave) {
        _wave = wave;
        _camerShake = Camera.main.GetComponent<CameraShake>();
    }

    // Has to be in Start to work
    void Start() {
        _animator.SetInteger("Wave", _wave);
    }

    public override void Hide(bool animated) {
        if(animated) {
            _despawnEffects.Play(transform.position);
            _camerShake.Shake();
        }

        Reset();
        Assets.Destroy(gameObject);
    }
}
