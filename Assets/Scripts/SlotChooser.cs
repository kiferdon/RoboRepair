using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;
using Utility;

public class SlotChooser : MonoBehaviour {
    [SerializeField] private List<Slot> slots;
    [SerializeField] private InventoryController inventoryController;


    public void ChooseSlot(BodyPart itemForSlot) {
        Vector3 position = itemForSlot.transform.position;
        int chosenSlotNumber = -1;
        for (int i = 0; i < slots.Count; i++) {
            if (slots[i].CheckEntry(itemForSlot)) {
                chosenSlotNumber = i;
                print("slot chosen");
                break;
            }
        }

        if (chosenSlotNumber != -1) {
            GameManager.Instance.PlayAttach();
            slots[chosenSlotNumber].Add(itemForSlot);
            itemForSlot.item.transform.parent = slots[chosenSlotNumber].transform;
            itemForSlot.Slot = slots[chosenSlotNumber];
            itemForSlot.Move(slots[chosenSlotNumber].transform.position);
        }
        else {
            GameManager.Instance.PlayWrong();
            inventoryController.AddItem(itemForSlot.item);
        }
    }
}