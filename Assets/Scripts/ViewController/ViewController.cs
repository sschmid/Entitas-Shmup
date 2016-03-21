using UnityEngine;

public interface IViewController {

    GameObject gameObject { get; }
    Vector3 position { get; set; }

    void OutOfScreen();
    void Despawn();
}

public class ViewController : MonoBehaviour, IViewController {

    [SerializeField] protected EffectPlayer _despawnEffects;

    public Vector3 position {
        get { return transform.localPosition; }
        set { transform.localPosition = value; }
    }

    public virtual void OutOfScreen() {
        destroy();
    }
    
    public virtual void Despawn() {
        _despawnEffects.Play(transform.position);
        destroy();
    }

    void destroy() {
        var link = gameObject.GetEntityLink();
        if (link.entity.hasViewObjectPool) {
            link.entity.viewObjectPool.pool.Push(gameObject);
            link.Unlink();
            gameObject.SetActive(false);
        } else {
            link.Unlink();
            Assets.Destroy(gameObject);
        }
    }
}

