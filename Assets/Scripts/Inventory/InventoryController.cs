using System;
using System.Collections.Generic;
using Items;
using UnityEngine;
using Utility;

namespace Inventory {
    public class InventoryController : Singleton<InventoryController> {
        public TabController[] tabs;

        private readonly Dictionary<Type, TabController> _tabsByType = new Dictionary<Type, TabController>();
        
        private void Awake() {
            foreach (var t in tabs) {
                _tabsByType.Add(t.Type, t);
            }
        }

        public void AddItem(Item item) {
            _tabsByType[item.GetType()].AddItem(item);
            item.DisableShadowSprite();
        }

        public void RemoveItem(Item item)
        {
            _tabsByType[item.GetType()].RemoveItem(item);
        }
    }
}