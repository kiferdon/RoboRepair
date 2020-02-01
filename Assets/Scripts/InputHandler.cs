using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour {
    RaycastHit2D[] results;
    bool objectSelected = false;
    Vector3 startPos, offset;
    Slot selectedObject;
    int[] curDirection;
    public UnityKeyCodeEvent keyCodeEvent;
    private int bodyPartLayer;
    public event Action MouseButtonDownEvent, MouseButtonUpEvent;

    public Vector3 MousePosition => Input.mousePosition;

    private void Awake() {
        bodyPartLayer = LayerMask.GetMask("BodyPart");
    }

    // Update is called once per frame
    void Update() {
        HandleInput();
    }

    private void HandleInput() {
        if (Input.GetMouseButtonDown(0)) {
            OnDragStartEvent();
        }

        if (Input.GetMouseButtonUp(0)) {
            OnDragEndEvent();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            keyCodeEvent?.Invoke(KeyCode.Alpha1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            keyCodeEvent?.Invoke(KeyCode.Alpha2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            keyCodeEvent?.Invoke(KeyCode.Alpha3);
        }
    }

    protected virtual void OnDragStartEvent() {
        MouseButtonDownEvent?.Invoke();
    }

    protected virtual void OnDragEndEvent() {
        MouseButtonUpEvent?.Invoke();
    }
}