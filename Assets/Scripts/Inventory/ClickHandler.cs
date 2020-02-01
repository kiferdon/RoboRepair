using System;
using Inventory;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

[RequireComponent(typeof(Collider2D), typeof(SortingGroup))]
public class ClickHandler : MonoBehaviour {
    public UnityTabEvent clickTabEvent;
    private TabController _tabController;

    private void Awake() {
        _tabController = GetComponent<TabController>();
    }

    private void OnMouseDown() {
        clickTabEvent.Invoke(_tabController);
    }
}