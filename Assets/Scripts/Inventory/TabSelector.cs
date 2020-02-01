using System;
using Inventory;
using UnityEngine;
using UnityEngine.Rendering;

public class TabSelector : MonoBehaviour {
    public int backLayer;
    public int frontLayer;
    public TabController selected;
    public TabController[] tabs;

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

    public void Select(KeyCode key) {
        switch (key) {
            case KeyCode.Alpha1:
                Select(tabs[0]);
                break;
            case KeyCode.Alpha2:
                Select(tabs[1]);
                break;
            case KeyCode.Alpha3:
                Select(tabs[2]);
                break;
        }
    }
}