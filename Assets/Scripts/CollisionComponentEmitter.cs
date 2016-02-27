using UnityEngine;

public class CollisionComponentEmitter : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(Tags.Enemy)) {
            var bulletLink = GetComponent<EntityLink>();
            var targetLink = other.GetComponent<EntityLink>();
            Pools.input.CreateEntity()
                .AddCollision(bulletLink.entity, targetLink.entity);
        }
    }
}
