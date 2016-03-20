using UnityEngine;

public class CollisionComponentEmitter : MonoBehaviour {

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag(Tags.Enemy)) {
            var bulletLink = GetComponent<EntityLink>();
            var targetLink = collision.gameObject.GetComponent<EntityLink>();
            Pools.input.CreateEntity()
                .AddCollision(bulletLink.entity, targetLink.entity);
        }
    }
}
