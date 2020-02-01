using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.GetType() == _robotType)
        var robot = other.GetComponent<Robot>();
        if(robot)
        {
            //print("Trigger");
            ObjectFactory.Instance.ReturnObject(robot);
            //EventOnCheckPoint?.Invoke(other.GetComponent<Robot>());
        }
    }
}
