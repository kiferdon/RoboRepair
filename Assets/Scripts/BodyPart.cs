using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public Item item;
    private Characteristics characteristics;
    public Characteristics Characteristics
    {
        get
        {
            characteristics.agility = item.stats.Dexterity;
            characteristics.intelligence = item.stats.Intelligence;
            characteristics.strength = item.stats.Strength;
            return characteristics;
        }
    }
    [SerializeField] private float movementSpeed;
    private Slot _slot;
    private bool _movementFlag = false;
    
    public Slot Slot
    {
        get => _slot;
        set
        {
            _slot = value;
            if (value)
            {
                item.EnableShadowSprite(value.yRotation,value.connectPosition.position);
            }
            else
            {
                item.DisableShadowSprite();
            }
        }
    }

    public void Drag(Vector3 cursorPos,Vector3 offset)
    {
        transform.position = cursorPos-offset;
    }
}
