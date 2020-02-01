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
        private int _itemCount;

        private void Awake() {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void CalculateGrid(Item item) {
            Vector2 cellSize;
            int xCount, yCount, totalCount;
            var spriteRendererBounds = _spriteRenderer.bounds;
            var inventorySize = spriteRendererBounds.size;
            do {
                cellSize = item.backRenderer.bounds.size;
                xCount = (int) (inventorySize.x / (cellSize.x * intervalKoef)) - 1;
                yCount = (int) (inventorySize.y / (cellSize.y * intervalKoef)) - 1;
                totalCount = xCount * yCount;
                if (totalCount > _itemCount) {
                    cellSize = new Vector2(cellSize.x - sizeChangeStep, cellSize.y - sizeChangeStep);
                }
            } while (totalCount < _itemCount);

            var boundsMin = spriteRendererBounds.min;
            var boundsMax = spriteRendererBounds.max;
            var startPosition = new Vector2(boundsMax.x - cellSize.x, boundsMin.y - cellSize.y);
            
            for (var i = 0; i < yCount; i++) {
                for (var i1 = 0; i1 < xCount; i1++) {
                    _cells.Push(startPosition);
                    startPosition = new Vector2(startPosition.x + cellSize.x * intervalKoef, startPosition.y);
                }

                startPosition = new Vector2(boundsMax.x - cellSize.x, startPosition.y + cellSize.y * intervalKoef);
            }
        }

        public void AddItem(Item item) {
            _itemCount++;
            if (_cells.Count == 0) {
                CalculateGrid(item);
            }

            item.transform.parent = transform;
            item.transform.position = _cells.Pop();
        }

        public void RemoveItem(Item item) {
            _itemCount--;
            _cells.Push(item.transform.position);
        }
    }
}