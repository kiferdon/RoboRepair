using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Variables;
using UnityEngine;

public class RobotAnalyser : MonoBehaviour
{
    public static RobotAnalyser Instance;
    [SerializeField] private IntVariable winPoints;
    [SerializeField] private CheckPoint checkPointTrigger;
    
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        checkPointTrigger.EventOnCheckPoint += AnalyseRobot;
    }

    public void AnalyseRobot(Robot robot)
    {
        winPoints.value += (robot.Characteristics.intelligence - robot.RequiredStats.intelligence);
        winPoints.value += (robot.Characteristics.agility - robot.RequiredStats.agility);
        winPoints.value += (robot.Characteristics.strength - robot.RequiredStats.strength);
    }
}
