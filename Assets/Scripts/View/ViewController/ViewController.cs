using Entitas;
using UnityEngine;

public class ViewController : MonoBehaviour, IViewController {

    public virtual Vector3 position {
        get { return transform.localPosition; }
        set { transform.localPosition = value; }
    }

    public virtual void Link(Entity entity, Pool pool) {
        gameObject.Link(entity, pool);
    }

    public virtual void Show(bool animated) {
        gameObject.SetActive(true);
    }

    public virtual void Hide(bool animated) {
        gameObject.SetActive(false);
    }

    public virtual void Reset() {
        gameObject.Unlink();
    }
}
