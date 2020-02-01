using System;
using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Inventory {
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class TabController : MonoBehaviour {
        public abstract Type Type { get; }
        public float sizeChangeStep;
        public float intervalKoef = 1.5f;
        private readonly Stack<Vector2> _cells = new Stack<Vector2>();
        private SpriteRenderer _spriteRenderer;
        private readonly List<Item> _items = new List<Item>();
        private float _currentScale = 1;

        private void Awake() {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void CalculateGrid(Item item) {
            int xCount, yCount, totalCount;
            var spriteRendererBounds = _spriteRenderer.bounds;
            //Get inventory size without pin offset
            var inventorySize = new Vector2(spriteRendererBounds.size.x, spriteRendererBounds.size.y - 1.5f);
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
            foreach (var item in _items) {
                var itemTransform = item.transform;
                itemTransform.localScale = new Vector3(_currentScale, _currentScale);
                itemTransform.position = _cells.Pop();
            }
        }

        public void AddItem(Item item) {
            _items.Add(item);
            var itemTransform = item.transform;
            itemTransform.parent = transform;
            itemTransform.localScale = new Vector3(_currentScale, _currentScale);
            if (_cells.Count == 0) {
                CalculateGrid(item);
                ResetGrid();
            }
            else {
                itemTransform.position = _cells.Pop();
            }
        }

        public void RemoveItem(Item item) {
            _items.Remove(item);
            var itemTransform = item.transform;
            itemTransform.localScale = new Vector3(1, 1, 1);
            _cells.Push(itemTransform.position);
        }
    }
}