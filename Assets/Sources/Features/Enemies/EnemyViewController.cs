using UnityEngine;

public interface IEnemyController : IViewController {
    void InitWithWave(int wave);
}

public class EnemyViewController : ViewController, IEnemyController {

    [SerializeField]
    Animator _animator;

    [SerializeField]
    EffectPlayer _despawnEffects;

    int _wave;

    public void InitWithWave(int wave) {
        _wave = wave;
    }

    // Has to be in Start to work
    void Start() {
        _animator.SetInteger("Wave", _wave);
    }

    public override void Hide(bool animated) {
        if(animated) {
            _despawnEffects.Play(transform.position);
        }

        Reset();
        Assets.Destroy(gameObject);
    }
}
