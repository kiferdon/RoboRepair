using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

[RequireComponent(typeof(Collider2D), typeof(SortingGroup))]
public class ClickHandler : MonoBehaviour {
    public UnitySortingEvent clickSortingEvent;
    private SortingGroup _sortingGroup;

    private void Awake() {
        _sortingGroup = GetComponent<SortingGroup>();
    }

    private void OnMouseDown() {
        clickSortingEvent.Invoke(_sortingGroup);
    }
}