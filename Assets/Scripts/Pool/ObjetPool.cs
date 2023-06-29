using System;
using System.Collections.Generic;

namespace Pools
{
    public class ObjectPool<T>
    {
        private readonly Stack<T> _pool;
        private readonly Func<T> _createFunc;

        public ObjectPool(Func<T> createFunc, int initialSize, bool autoExpand)
        {
            _pool = new Stack<T>(initialSize);
            _createFunc = createFunc;

            if (autoExpand)
            {
                ExpandPool(initialSize);
            }
        }

        public T Get()
        {
            if (_pool.Count == 0)
            {
                ExpandPool(1);
            }

            return _pool.Pop();
        }

        public void Return(T obj)
        {
            _pool.Push(obj);
        }

        private void ExpandPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                T obj = _createFunc != null ? _createFunc() : default(T);
                _pool.Push(obj);
            }
        }
    }
}