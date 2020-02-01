using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewRobot : MonoBehaviour
{
    public event Action NewRobotEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var robot = other.GetComponent<Robot>();
        if(robot)
        {
            //print("Trigger");
            NewRobotEvent?.Invoke();
        }
    }
}
