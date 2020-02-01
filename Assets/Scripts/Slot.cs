using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public event Action<Robot.Characteristics> ItemAddEvent, ItemRemoveEvent;
    [SerializeField] private SpriteRenderer slotArea;
    [SerializeField] private Item requiredItemPrefab;
    private Type _requiredItemType;
    private bool _isFree;

    private void Start()
    {
        _requiredItemType = requiredItemPrefab.GetType();
        _isFree = true;
    }

    public void Add(BodyPart bodyPart)
    {
        _isFree = false;
        OnItemAdd(bodyPart.characteristics);
    }

    public void Remove(BodyPart bodyPart)
    {
        _isFree = true;
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

    public bool CheckEntry(BodyPart bodyPart)
    {
        Vector3 position = bodyPart.transform.position;
        print("checkEntry "+_isFree);
        if (_isFree)
        {
            print("free");

            if (slotArea.bounds.Contains(position))
            {
                print("contains");

                if (bodyPart.item.GetType() == _requiredItemType)
                {
                    print("type match");

                    return true;
                }
            }
        }
        return false;
    }
}
