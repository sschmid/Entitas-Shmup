using UnityEngine;

public class CollisionEmitter : MonoBehaviour {

    public string targetTag;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag(targetTag)) {
            var link = GetComponent<EntityLink>();
            var targetLink = collision.gameObject.GetComponent<EntityLink>();
            Pools.input.CreateEntity().AddCollision(link.entity, targetLink.entity);
        }
    }
}
