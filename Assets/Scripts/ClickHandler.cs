using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public class ClickHandler : MonoBehaviour {
    public UnityEventRenderer clickEvent;
    private SpriteRenderer _renderer;

    private void Awake() {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown() {
        clickEvent.Invoke(_renderer);
    }
}