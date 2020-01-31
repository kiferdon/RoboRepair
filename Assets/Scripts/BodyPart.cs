using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    
    public Robot.Characteristics characteristics;
    private Vector3 targetPosition, normalPosition;
    [SerializeField] private float movementSpeed;
    private Slot _slot;

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
        if(normalPosition != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed);
            if (transform.position == targetPosition) normalPosition = targetPosition;
        }
    }
    
    public void Drag(Vector3 cursorPos,Vector3 offset)
    {
        //print("drag "+cursorPos+" "+offset);
        transform.position = cursorPos-offset;
    }

    public void Move(Vector3 position)
    {
        //print(targetPosition+" "+transform.position);
        normalPosition = transform.position;
        targetPosition = position;
    }
}
