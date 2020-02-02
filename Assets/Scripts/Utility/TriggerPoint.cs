using UnityEngine;
using UnityEngine.Events;

namespace Utility {
    public class TriggerPoint : MonoBehaviour {
        public UnityEvent triggerEvent;

        private void OnTriggerEnter2D(Collider2D other) {
            triggerEvent?.Invoke();
        }
    }
}