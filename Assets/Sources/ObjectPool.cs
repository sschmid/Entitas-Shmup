using System;
using System.Collections.Generic;

public class ObjectPool<T> where T : class {

    readonly Func<T> _factoryMethod;
    readonly Stack<T> _stack;

    public ObjectPool(Func<T> factoryMethod) {
        _factoryMethod = factoryMethod;
        _stack = new Stack<T>();
    }

    public T Get() {
        return _stack.Count == 0 ? _factoryMethod() : _stack.Pop();
    }

    public void Push(T obj) {
        _stack.Push(obj);
    }
}
