using System;
using Inventory;
using UnityEngine;
using UnityEngine.Rendering;

public class TabSelector : MonoBehaviour {
    public int backLayer;
    public int frontLayer;
    public TabController selected;

    private void Start() {
        if (selected) {
            selected.Select(frontLayer);
        }
    }

    public void Select(TabController tabController) {
        if (selected) selected.UnSelect(backLayer);
        selected = tabController;
        selected.Select(frontLayer);
    }
}