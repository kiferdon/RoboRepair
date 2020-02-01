using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public event Action<Robot> EventOnCheckPoint;
    private Type _robotType;
    
    // Start is called before the first frame update
    void Start()
    {
        _robotType = typeof(Robot);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.GetType() == _robotType)
        if(other.GetComponent<Robot>())
        {
            print("Trigger");
            EventOnCheckPoint?.Invoke(other.GetComponent<Robot>());
        }
    }
}
