using System;
using UnityEngine;
using UnityEngine.Rendering;

public class TabSelector : MonoBehaviour {
    public int backLayer;
    public int frontLayer;
    public SortingGroup selected;

    private void Start() {
        if (selected) {
            selected.sortingOrder = frontLayer;
        }
    }

    public void Select(SortingGroup sortingGroup) {
        if (selected) selected.sortingOrder = backLayer;
        selected = sortingGroup;
        selected.sortingOrder = frontLayer;
    }
}