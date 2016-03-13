using UnityEngine;

public class EnemyWaveEventHandler : MonoBehaviour {

    public void Destroy() {
        Assets.Destroy(gameObject);
    }
}
