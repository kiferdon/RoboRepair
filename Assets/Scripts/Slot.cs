using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public event Action<Robot.Characteristics> ItemAddEvent, ItemRemoveEvent;
    [SerializeField] private SpriteRenderer slotArea;
    
    
    public void Add(BodyPart bodyPart)
    {
        OnItemAdd(bodyPart.characteristics);
    }

    public void Remove(BodyPart bodyPart)
    {
        OnItemRemove(bodyPart.characteristics);
    }

    protected virtual void OnItemAdd(Robot.Characteristics characteristics)
    {
        ItemAddEvent?.Invoke(characteristics);
    }

    protected virtual void OnItemRemove(Robot.Characteristics characteristics)
    {
        ItemRemoveEvent?.Invoke(characteristics);
    }

    public bool CheckEntry(Vector3 position)
    {
        if (slotArea.bounds.Contains(position))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
