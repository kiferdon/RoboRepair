using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotChooser : MonoBehaviour
{
    [SerializeField] private List<Slot> slots;

    public void ChooseSlot(BodyPart itemForSlot)
    {
        Vector3 position = itemForSlot.transform.position;
        int chosenSlotNumber=-1;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].CheckEntry(position))
            {
                chosenSlotNumber = i;
                print("slot chosen");
                break;
            }
        }

        if (chosenSlotNumber == -1) return;
        slots[chosenSlotNumber].Add(itemForSlot);
        itemForSlot.Slot = slots[chosenSlotNumber];
        itemForSlot.Move(slots[chosenSlotNumber].transform.position);
    }
}
