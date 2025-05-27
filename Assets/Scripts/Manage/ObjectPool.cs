using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manage
{
    public abstract class ObjectPool<T> where T:class
    {
        private Queue<T> pool = new Queue<T>();
        public T GetObject()
        {
            if (pool.Count == 0)
            {
                return Activator.CreateInstance<T>();
            }

            return pool.Dequeue();
        }

        public void ReturnObject(T t)
        {
            InitObject(t);
            pool.Enqueue(t);
        }

        public abstract void InitObject(T t);
    }
}