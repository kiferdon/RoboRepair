using System;
using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.Rendering;

namespace Inventory {
    [RequireComponent(typeof(SortingGroup))]
    public abstract class TabController : MonoBehaviour {
        public abstract Type Type { get; }
        public float sizeChangeStep;
        public float intervalKoef = 1.5f;
        public GameObject items;
        public SpriteRenderer panel;
        private readonly Stack<Vector2> _cells = new Stack<Vector2>();
        private readonly List<Item> _items = new List<Item>();
        private float _currentScale = 1;
        private SortingGroup _sortingGroup;

        private void Awake() {
            _sortingGroup = GetComponent<SortingGroup>();
        }

        private void CalculateGrid(Item item) {
            int xCount, yCount, totalCount;
            var spriteRendererBounds = panel.bounds;
            //Get inventory size without pin offset
            var inventorySize = new Vector2(spriteRendererBounds.size.x, spriteRendererBounds.size.y);
            var cellSize = item.backRenderer.bounds.size;
            do {
                xCount = (int) ((inventorySize.x - cellSize.x * intervalKoef / 2) / (cellSize.x * intervalKoef));
                yCount = (int) ((inventorySize.y - cellSize.y * intervalKoef / 2) / (cellSize.y * intervalKoef));
                totalCount = xCount * yCount;
                if (totalCount < _items.Count) {
                    cellSize = new Vector2(cellSize.x - sizeChangeStep, cellSize.y - sizeChangeStep);
                }
            } while (totalCount < _items.Count);

            var boundsMin = spriteRendererBounds.min;
            var boundsMax = spriteRendererBounds.max;
            var xStart = boundsMax.x - cellSize.x * intervalKoef -
                         (inventorySize.x - cellSize.x * intervalKoef / 2 - cellSize.x * xCount * intervalKoef) / 2;
            var yStart = boundsMin.y + cellSize.y * intervalKoef +
                         (inventorySize.y - cellSize.y * intervalKoef / 2 - cellSize.y * yCount * intervalKoef) / 2;
            var startPosition = new Vector2(xStart, yStart);

            for (var i = 0; i < yCount; i++) {
                for (var i1 = 0; i1 < xCount; i1++) {
                    _cells.Push(startPosition);
                    startPosition = new Vector2(startPosition.x - cellSize.x * intervalKoef, startPosition.y);
                }

                startPosition = new Vector2(xStart, startPosition.y + cellSize.y * intervalKoef);
            }

            _currentScale = cellSize.x / item.backRenderer.bounds.size.x;
        }

        private void ResetGrid() {
            _items.Sort();
            foreach (var item in _items) {
                var itemTransform = item.transform;
                itemTransform.localScale = new Vector3(_currentScale, _currentScale);
                itemTransform.position = _cells.Pop();
            }
        }

        public void AddItem(Item item) {
            _items.Add(item);
            var itemTransform = item.transform;
            itemTransform.parent = items.transform;
            itemTransform.localScale = new Vector3(_currentScale, _currentScale);
            CalculateGrid(item);
            ResetGrid();
        }

        public void RemoveItem(Item item) {
            _items.Remove(item);
            var itemTransform = item.transform;
            itemTransform.localScale = new Vector3(1, 1, 1);
            _cells.Push(itemTransform.position);
        }

        public void Select(int order) {
            _sortingGroup.sortingOrder = order;
            items.SetActive(true);
            panel.enabled = true;
        }

        public void UnSelect(int order) {
            _sortingGroup.sortingOrder = order;
            items.SetActive(false);
            panel.enabled = false;
        }
    }
}