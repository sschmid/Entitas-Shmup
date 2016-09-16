//using NSpec;
//using System;

//class describe_ObjectPool : nspec {
//    void when_object_pooling() {

//        ObjectPool<object> objectPool = null;
//        before = () => {
//            objectPool = new ObjectPool<object>(() => new object());
//        };

//        it["creates new object from empty pool"] = () => {
//            objectPool.Get().should_not_be_null();
//        };

//        it["pushes object to pool and gets it"] = () => {
//            var obj = new object();
//            objectPool.Push(obj);
//            objectPool.Get().should_be_same(obj);
//        };
//    }
//}

