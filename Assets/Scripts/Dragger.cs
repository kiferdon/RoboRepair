using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;
using Utility;

public class Dragger : MonoBehaviour {
    [SerializeField] private InputHandler inputHandler;
    RaycastHit2D[] results;
    bool objectIsSelected = false;
    Vector3 startPos, offset;
    BodyPart selectedObject;
    int[] curDirection;
    private int _bodyPartLayer;
    [SerializeField] private Camera camera;
    [SerializeField] private float raycastDistance;
    [SerializeField] private SlotChooser slotChooser;
    public UnityItemEvent itemEvent;

    // Start is called before the first frame update
    void Awake() {
        inputHandler.MouseButtonDownEvent += StartDrag;
        inputHandler.MouseButtonUpEvent += EndDrag;
        results = new RaycastHit2D[1];
        _bodyPartLayer = LayerMask.GetMask("BodyPart");
    }

    private void StartDrag() {
        Vector3 mousePosition = inputHandler.MousePosition;
        if (Physics2D.GetRayIntersectionNonAlloc(camera.ScreenPointToRay(mousePosition)
                , results, Mathf.Infinity, _bodyPartLayer) != 0) {
            BodyPart bodyPart;
            for (int i = 0; i < results.Length; ++i) {
                bodyPart = results[i].transform.gameObject.GetComponent<BodyPart>();
                if (bodyPart.Slot == null) {
                    itemEvent?.Invoke(bodyPart.item);
                }
                else {
                    GameManager.Instance.PlayDetach();
                    bodyPart.Slot.Remove(bodyPart);
                    bodyPart.Slot = null;
                }

                objectIsSelected = true;
                startPos = camera.ScreenToWorldPoint(mousePosition);
                offset = camera.ScreenToWorldPoint(mousePosition) - results[i].transform.position;
                selectedObject = bodyPart;
                break;
            }
        }
    }

    private void Drag() {
        //print("drag");
        // Vector3
        selectedObject.Drag(camera.ScreenToWorldPoint(inputHandler.MousePosition), offset);
    }

    private void EndDrag() {
        if (objectIsSelected) {
            objectIsSelected = false;
            slotChooser.ChooseSlot(selectedObject);
            selectedObject = null;
        }
    }


    // Update is called once per frame
    void Update() {
        if (objectIsSelected) {
            Drag();
        }
    }
}