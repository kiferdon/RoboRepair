using Events;
using Items;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Inventory {
    public class ItemGenerator : MonoBehaviour {
        public int minCount;
        public int maxCount;
        public Item[] types;
        public UnityItemEvent itemEvent;

        private void Start() {
            var type = types[Random.Range(0, types.Length)];
        }
    }
}