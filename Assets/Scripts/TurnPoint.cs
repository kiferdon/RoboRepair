using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnPoint : MonoBehaviour
{
    public event Action<Robot> EventOnCheckPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var robot = other.GetComponent<Robot>();
        if(robot)
        {
            //print("Trigger");
            EventOnCheckPoint?.Invoke(robot);
            robot.Build();
        }
    }
}
