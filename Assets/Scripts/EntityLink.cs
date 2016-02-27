using UnityEngine;
using Entitas;
using System;

public class EntityLink : MonoBehaviour {
    
    public Entity entity { get { return _entity; } }
    public Pool pool { get { return _pool; } }

    Entity _entity;
    Pool _pool;

    public void Link(Entity entity, Pool pool) {
        if (_entity != null) {
            throw new Exception("EntityLink is already linked to " + _entity);
        }

        _entity = entity;
        _pool = pool;
        _entity.Retain(this);
    }

    public void Unlink() {
        _entity.Release(this);
        _entity = null;
        _pool = null;
    }
}

