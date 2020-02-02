using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Slot : MonoBehaviour
{
    public event Action<Characteristics> ItemAddEvent, ItemRemoveEvent;
    [SerializeField] private Item requiredItemPrefab;
    private Type _requiredItemType;
    public float yRotation;
    public Transform connectPosition;
    public Type RequiredItemType => _requiredItemType;

    //public Item RequiredItemPrefab => requiredItemPrefab;

    private BodyPart _bodyPart;
    private SpriteRenderer _itemPlacer;
    

    private void Awake()
    {
        _requiredItemType = requiredItemPrefab.GetType();
        _itemPlacer = GetComponent<SpriteRenderer>();
    }

    public void Init()
    {
        if (_bodyPart != null)
        {
            Destroy(_bodyPart.gameObject);
            _bodyPart = null;
        }

        if (_itemPlacer)
        {
            _itemPlacer.enabled = true;

        }
    }

    public void Add(BodyPart bodyPart)
    {
        if (bodyPart == null)
        {
            return;
        }

        if (_bodyPart != null)
        {
            Remove(_bodyPart);
        }
        _bodyPart = bodyPart;
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
        _bodyPart = null;
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
        if (bodyPart.item.GetType() == _requiredItemType)
        {

            return true;
        }
        // if (!_bodyPart)
        // {
        //
        //     
        // }
        return false;
    }

    public void Build()
    {
        _itemPlacer.enabled=false;
        if(!_bodyPart) return;
        _bodyPart.item.DisableShadowSprite();
        _bodyPart.item.EnableRealSprite(yRotation,connectPosition.position);
    }
}
