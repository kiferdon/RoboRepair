using System;
using UnityEngine;

namespace Utility {
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
        private static readonly Lazy<T> lazyInstance = new Lazy<T>(CreateSingleton);

        public static T Instance => lazyInstance.Value;

        protected virtual void Awake() {
            DontDestroyOnLoad(gameObject);
        }

        private static T CreateSingleton() {
            var instance = (T) FindObjectOfType(typeof(T));
            if (instance == null) {
                Debug.Log("Create new singleton instance of " + typeof(T).Name);
                var ownerObject = new GameObject($"{typeof(T).Name} (singleton)");
                instance = ownerObject.AddComponent<T>();
                DontDestroyOnLoad(ownerObject);
            }

            return instance;
        }
    }
}