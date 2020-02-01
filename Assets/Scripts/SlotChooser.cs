using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;
using Utility;

public class SlotChooser : MonoBehaviour {
    //[SerializeField] private List<Slot> slots;
    [SerializeField] private InventoryController inventoryController;
    private int _slotLayerNumber;
    private Camera _camera;
    private RaycastHit2D[] _results;
    private void Awake()
    {
        _slotLayerNumber = LayerMask.GetMask("Slot");
        _camera=Camera.main;
        _results = new RaycastHit2D[1];
    }

    public void ChooseSlot(BodyPart itemForSlot) {
        if(Physics2D.GetRayIntersectionNonAlloc(_camera.ScreenPointToRay(Input.mousePosition)
               , _results, Mathf.Infinity, _slotLayerNumber) != 0)
            {
                for (int i = 0; i < _results.Length; i++)
                {
                    var slot = _results[i].transform.GetComponent<Slot>();
                    if (slot.CheckEntry(itemForSlot))
                    {
                        slot.Add(itemForSlot);
                        GameManager.Instance.PlayAttach();
                        return;
                    }
                }
            }
        GameManager.Instance.PlayWrong();
        inventoryController.AddItem(itemForSlot.item);
    }
}