using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    RaycastHit2D[] results;
    bool objectSelected = false;
    Vector3 startPos,offset;
    Slot selectedObject;
    int[] curDirection;
    private int bodyPartLayer;
    public event Action MouseButtonDownEvent,MouseButtonUpEvent;

    public Vector3 MousePosition
    {
        get
        {
            return Input.mousePosition;
        }
    }

    private void Awake()
    {
        bodyPartLayer = LayerMask.GetMask("BodyPart");
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnDragStartEvent();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnDragEndEvent();
        }
    }

    protected virtual void OnDragStartEvent()
    {
        MouseButtonDownEvent?.Invoke();
    }

    protected virtual void OnDragEndEvent()
    {
        MouseButtonUpEvent?.Invoke();
    }
}
