using UnityEngine;

namespace Utility {
    public class PoolObject : MonoBehaviour {
        [SerializeField] protected int instanceCount;

        public int GetInitialCount() {
            return instanceCount;
        }

        public void ReturnToPool() {
            ObjectFactory.Instance.ReturnObject(this);
        }
    }
}