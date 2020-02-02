using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Variables;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;

public class RobotAnalyser : MonoBehaviour {
    public static RobotAnalyser Instance;
    [SerializeField] private IntVariable winPoints;

    [FormerlySerializedAs("checkPointTrigger")] [SerializeField]
    private TurnPoint turnPointTrigger;

    [SerializeField] private int pointsOnStart;


    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        turnPointTrigger.EventOnCheckPoint += AnalyseRobot;
        winPoints.value = pointsOnStart;
    }

    public void AnalyseRobot(Robot robot)
    {
        if (robot.Characteristics.intelligence < robot.RequiredStats.intelligence)
        {
            winPoints.value -= (robot.RequiredStats.intelligence - robot.Characteristics.intelligence) * 2;
        }
        else
        {
            winPoints.value += (robot.Characteristics.intelligence - robot.RequiredStats.intelligence);

        }

        if (robot.Characteristics.agility < robot.RequiredStats.agility)
        {
            winPoints.value -= (robot.RequiredStats.agility - robot.Characteristics.agility) * 2;
        }
        else
        {
            winPoints.value += (robot.Characteristics.agility - robot.RequiredStats.agility);

        }

        if (robot.Characteristics.strength < robot.RequiredStats.strength)
        {
            winPoints.value -= (robot.RequiredStats.strength - robot.Characteristics.strength) * 2;
        }
        else
        {
            winPoints.value += (robot.Characteristics.strength - robot.RequiredStats.strength);

        }


         if (winPoints.value >= before) {
            GameManager.Instance.PlayGood();
        }
        else {
            GameManager.Instance.PlayBad();
        }
        if (winPoints.value <= 0)
        {
            GameManager.Instance.Lose();
        }
    }
}