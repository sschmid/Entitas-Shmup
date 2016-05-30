using UnityEngine;

public interface IEnemyController : IViewController {
    void Init(int wave);
}

public class EnemyController : ViewController, IEnemyController {

    [SerializeField] Animator _animator;

    [SerializeField] EffectPlayer _despawnEffects;

    int _wave;

    public void Init(int wave) {
        _wave = wave;
    }

    // Has to be in Start to work
    void Start() {
        _animator.SetInteger("Wave", _wave);
    }

    public override void Despawn() {
        _despawnEffects.Play(transform.position);
        base.Despawn();
    }
}

