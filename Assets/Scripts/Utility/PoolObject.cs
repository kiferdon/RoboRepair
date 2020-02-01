using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Utility {
    public abstract class PoolObject : MonoBehaviour {
        [SerializeField] protected int instanceCount;

        public int GetInitialCount() {
            return instanceCount;
        }

        public abstract void Init();

        public void ReturnToPool() {
            ObjectFactory.Instance.ReturnObject(this);
        }
    }
}