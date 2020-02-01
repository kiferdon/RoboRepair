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

    private Vector3 targetPosition, normalPosition;
    [SerializeField] private float movementSpeed;
    private Slot _slot;
    private bool _movementFlag = false;

    public Slot Slot
    {
        get => _slot;
        set => _slot = value;
    }

    // Start is called before the first frame update
    void Awake()
    {
        normalPosition = transform.position;
        targetPosition = normalPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(normalPosition != targetPosition && _movementFlag)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed);
            if (transform.position == targetPosition)
            {
                _movementFlag = false;
                normalPosition = targetPosition;
            }
        }
    }
    
    public void Drag(Vector3 cursorPos,Vector3 offset)
    {
        //print("drag "+cursorPos+" "+offset);
        transform.position = cursorPos-offset;
    }

    public void Move(Vector3 position)
    {
        _movementFlag = true;
        normalPosition = transform.position;
        targetPosition = position;
    }
}
