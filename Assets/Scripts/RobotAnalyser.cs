using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Variables;
using UnityEngine;
using UnityEngine.Serialization;

public class RobotAnalyser : MonoBehaviour
{
    public static RobotAnalyser Instance;
    [SerializeField] private IntVariable winPoints;
    [FormerlySerializedAs("checkPointTrigger")] [SerializeField] private TurnPoint turnPointTrigger;
    
    
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
        turnPointTrigger.EventOnCheckPoint += AnalyseRobot;
    }

    public void AnalyseRobot(Robot robot)
    {
        winPoints.value += (robot.Characteristics.intelligence - robot.RequiredStats.intelligence);
        winPoints.value += (robot.Characteristics.agility - robot.RequiredStats.agility);
        winPoints.value += (robot.Characteristics.strength - robot.RequiredStats.strength);
    }
}
