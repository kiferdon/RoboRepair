using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility {
    public class ObjectFactory : Singleton<ObjectFactory> {
        private readonly Dictionary<Type, Stack<PoolObject>> _pool = new Dictionary<Type, Stack<PoolObject>>();

        protected override void Awake() {
            base.Awake();
            var poolObjects = Resources.LoadAll("Prefabs", typeof(PoolObject));
            foreach (var o in poolObjects) {
                var poolObject = (PoolObject) o;
                var stack = new Stack<PoolObject>();
                _pool.Add(o.GetType(), stack);
                for (var i = 0; i < poolObject.GetInitialCount(); i++) {
                    var instantiate = Instantiate(poolObject.gameObject, transform);
                    instantiate.SetActive(false);
                    stack.Push(instantiate.GetComponent<PoolObject>());
                }
            }
        }

        public T GetObject<T>(T poolObject, Transform parent = null) where T : PoolObject {
            var objectPool = _pool[poolObject.GetType()];
            if (objectPool.Count == 0) {
                Debug.LogWarning("Create additional pool object of type: " + typeof(T));
                var component = Instantiate(poolObject.gameObject, parent).GetComponent<PoolObject>();
                component.Init();
                return (T) component;
            }

            var result = objectPool.Pop();
            result.gameObject.SetActive(true);
            result.transform.SetParent(parent);
            result.Init();
            return (T) result;
        }

        public void ReturnObject(PoolObject returned) {
            returned.gameObject.SetActive(false);
            var returnedTransform = returned.transform;
            returnedTransform.SetParent(transform);
            returnedTransform.position = transform.position;
            var objectPool = _pool[returned.GetType()];
            objectPool.Push(returned);
        }
    }
}