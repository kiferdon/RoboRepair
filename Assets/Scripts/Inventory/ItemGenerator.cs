using Events;
using Items;
using UnityEngine;
using Utility;
using Random = UnityEngine.Random;

namespace Inventory {
    public class ItemGenerator : MonoBehaviour {
        public int minCount;
        public int maxCount;
        public Item[] types;
        public UnityItemEvent itemEvent;

        private void Start() {
            foreach (var item in types) {
                var count = Random.Range(minCount, maxCount + 1);
                for (var i = 0; i < count; i++) {
                    itemEvent.Invoke(ObjectFactory.Instance.GetObject<Item>(item));
                }
            }
        }
    }
}