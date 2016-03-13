using NUnit.Framework;
using UnityEngine;
using Entitas;
using System;

public class EntityLinkTests {

    Pool _pool;
    Entity _entity;
    GameObject _gameObject;
    EntityLink _link;

    [SetUp]
    public void BeforeEach() {
        _pool = new Pool(1);
        _entity = _pool.CreateEntity();
        _gameObject = new GameObject();
        _link = _gameObject.AddComponent<EntityLink>();
    }

    [Test]
    public void LinksEntityAndPoolAndRetainsEntity() {

        // given
        var retainCount = _entity.retainCount;

        // when
        _link.Link(_entity, _pool);

        // then
        Assert.AreSame(_entity, _link.entity);
        Assert.AreSame(_pool, _link.pool);
        Assert.AreEqual(retainCount + 1, _entity.retainCount);

        #if !ENTITAS_FAST_AND_UNSAFE
        Assert.IsTrue(_entity.owners.Contains(_link));
        #endif
    }

    [Test, ExpectedException(typeof(Exception))]
    public void ThrowsWhenAlreadyLinked() {

        // when
        _link.Link(_entity, _pool);
        _link.Link(_entity, _pool);
    }

    [Test]
    public void UnlinksEntityReleasesEntity() {

        // given
        _link.Link(_entity, _pool);
        var retainCount = _entity.retainCount;

        // when
        _link.Unlink();

        Assert.AreEqual(retainCount - 1, _entity.retainCount);
        Assert.IsNull(_link.entity);
        Assert.IsNull(_link.pool);

        #if !ENTITAS_FAST_AND_UNSAFE
        Assert.IsFalse(_entity.owners.Contains(_link));
        #endif
    }

    [Test, ExpectedException(typeof(Exception))]
    public void ThrowsWhenAlreadyUnlinked() {

        // when
        _link.Unlink();
    }

    [Test]
    public void GetEntityLink() {
        Assert.AreSame(_link, _gameObject.GetEntityLink());
    }

    [Test]
    public void AddsEntityLinkAndLinks() {

        // given
        var gameObject = new GameObject();
        var retainCount = _entity.retainCount;

        // when
        var link = gameObject.Link(_entity, _pool);

        // then
        Assert.AreSame(link, gameObject.GetEntityLink());
        Assert.AreSame(_entity, link.entity);
        Assert.AreSame(_pool, link.pool);
        Assert.AreEqual(retainCount + 1, _entity.retainCount);
    }

    [Test]
    public void Unlinks() {

        // given
        var gameObject = new GameObject();
        var link = gameObject.Link(_entity, _pool);
        var retainCount = _entity.retainCount;

        // when
        gameObject.Unlink();

        // then
        Assert.AreSame(link, gameObject.GetEntityLink());
        Assert.AreEqual(retainCount - 1, _entity.retainCount);
        Assert.IsNull(link.entity);
        Assert.IsNull(link.pool);
    }

    [Test]
    public void ReusesLink() {

        // given
        var gameObject = new GameObject();
        var link1 = gameObject.Link(_pool.CreateEntity(), new Pool(1));
        gameObject.Unlink();

        // when
        var link2 = gameObject.Link(_entity, _pool);

        // then
        Assert.AreEqual(1, gameObject.GetComponents<EntityLink>().Length);
        Assert.AreSame(link1, link2);
        Assert.AreSame(_entity, link2.entity);
        Assert.AreSame(_pool, link2.pool);
    }
}
