using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEditor;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public event Action<Characteristics> ItemAddEvent, ItemRemoveEvent;
    [SerializeField] private SpriteRenderer slotArea;
    [SerializeField] private Item requiredItemPrefab;
    private Type _requiredItemType;
    public float yRotation;

    public Type RequiredItemType => _requiredItemType;

    //public Item RequiredItemPrefab => requiredItemPrefab;

    private bool _isFree;

    private void Awake()
    {
        _requiredItemType = requiredItemPrefab.GetType();
        _isFree = true;
    }

    public void Add(BodyPart bodyPart)
    {
        if (bodyPart == null)
        {
            return;
        }
        _isFree = false;
        bodyPart.transform.parent = transform;
        bodyPart.transform.localPosition=Vector3.zero;
        bodyPart.Slot = this;
        //bodyPart.Move(transform.position);
        OnItemAdd(bodyPart.Characteristics);
    }

    public void Remove(BodyPart bodyPart)
    {
        if (bodyPart == null)
        {
            return;
        }
        _isFree = true;
        OnItemRemove(bodyPart.Characteristics);
    }

    protected virtual void OnItemAdd(Characteristics characteristics)
    {
        ItemAddEvent?.Invoke(characteristics);
    }

    protected virtual void OnItemRemove(Characteristics characteristics)
    {
        ItemRemoveEvent?.Invoke(characteristics);
    }

    public bool CheckEntry(BodyPart bodyPart)
    {
        Vector3 position = bodyPart.transform.position;
        if (_isFree)
        {

            if (bodyPart.item.GetType() == _requiredItemType)
            {

                return true;
            }
        }

        return false;
    }
}
