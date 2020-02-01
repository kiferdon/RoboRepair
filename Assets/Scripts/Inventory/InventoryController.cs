using System;
using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Inventory {
    public class InventoryController : MonoBehaviour {
        public TabController[] tabs;

        private readonly Dictionary<Type, TabController> _tabsByType = new Dictionary<Type, TabController>();

        private void Awake() {
            foreach (var t in tabs) {
                _tabsByType.Add(t.Type, t);
            }
        }

        public void AddItem(Item item) {
            _tabsByType[item.GetType()].AddItem(item);
        }

        public void RemoveItem(Item item)
        {
            _tabsByType[item.GetType()].RemoveItem(item);
        }
    }
}