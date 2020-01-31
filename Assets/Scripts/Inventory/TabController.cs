using System;
using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Inventory {
    public class TabController : MonoBehaviour {
        public Vector2[] grid;
        private readonly Stack<Vector2> _cells = new Stack<Vector2>();

        private void Awake() {
            for (var i = grid.Length - 1; i >= 0; i--) {
                _cells.Push(grid[i]);
            }
        }

        public void AddItem(Item item) {
            item.transform.parent = transform;
            item.transform.position = _cells.Pop();
        }
    }
}