using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTabloTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        var robot = other.GetComponent<Robot>();
        if (robot) {
            robot.HideTablo();
        }
    }
}
