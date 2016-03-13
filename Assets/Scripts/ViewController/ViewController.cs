using UnityEngine;
using Entitas;

public interface IViewController {

    string name { get; set; }
    EntityLink entityLink { get; }
    Vector3 position { get; set; }

    EntityLink Link(Entity entity, Pool pool);
    void Unlink();
    void Despawn();
}

public class ViewController : MonoBehaviour, IViewController {

    public EntityLink entityLink { get { return GetComponent<EntityLink>(); } }

    public Vector3 position {
        get { return transform.localPosition; }
        set { transform.localPosition = value; }
    }

    public EntityLink Link(Entity entity, Pool pool) {
        var link = gameObject.GetComponent<EntityLink>();
        if (link == null) {
            link = gameObject.AddComponent<EntityLink>();
        }

        link.Link(entity, pool);
        return link;
    }

    public void Unlink() {
        entityLink.Unlink();
    }

    public virtual void Despawn() {
        Assets.Destroy(gameObject);
    }
}

