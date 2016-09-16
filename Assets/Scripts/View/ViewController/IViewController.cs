using Entitas;
using UnityEngine;

public interface IViewController {

    GameObject gameObject { get; }
    Vector3 position { get; set; }

    void Link(Entity entity, Pool pool);

    void Show(bool animated);
    void Hide(bool animated);

    void Reset();
}
