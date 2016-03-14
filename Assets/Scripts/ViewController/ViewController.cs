using UnityEngine;

public interface IViewController {

    GameObject gameObject { get; }
    Vector3 position { get; set; }

    void Despawn();
}

public class ViewController : MonoBehaviour, IViewController {

    public Vector3 position {
        get { return transform.localPosition; }
        set { transform.localPosition = value; }
    }

    public virtual void Despawn() {
        gameObject.Unlink();
        Assets.Destroy(gameObject);
    }
}

