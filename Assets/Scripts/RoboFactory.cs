using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Conveyors;
using Items;
using UnityEngine;
using Utility;
using Random = UnityEngine.Random;

public class RoboFactory : MonoBehaviour
{
    [SerializeField] private Robot robotPrefab;
    public static RoboFactory Instance;
    [SerializeField] private BodyPart head,arm,leg;
    
    [SerializeField] private float probabilityOfFillingSlot;
    [SerializeField] private Vector2Int minMaxRequiredStats;
    [SerializeField] private ConveyorController conveyorController;
    [SerializeField] private SpawnNewRobot spawnTrigger;
    

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
        GenerateRobot();
        spawnTrigger.NewRobotEvent += GenerateRobot;
    }

    private void GenerateRobot()
    {
        var robot = ObjectFactory.Instance.GetObject<Robot>(robotPrefab);
        conveyorController.AddRobot(robot);
    }

    private BodyPart CreateHead()
    {
        if (Random.value > probabilityOfFillingSlot)
        {
            return null;
        }
        //var randomItemNumber = Random.Range(0, heads.Count);
        BodyPart bodyPart = Instantiate(head);
        //bodyPart.item.stats = StatGenerator.Stats;
        bodyPart.GetComponent<HeadItem>().Init();
        return bodyPart;    
    }
    
    private BodyPart CreateArm()
    {
        if (Random.value > probabilityOfFillingSlot)
        {
            return null;
        }
        //var randomItemNumber = Random.Range(0, arms.Count);
        BodyPart bodyPart = Instantiate(arm);
        //bodyPart.item.stats = StatGenerator.Stats;
        bodyPart.GetComponent<ArmItem>().Init();

        //print(bodyPart.item.stats.Dexterity+" "+bodyPart.item.stats.Strength+" "+bodyPart.item.stats.Intelligence);
        return bodyPart;
    }
    
    private BodyPart CreateLeg()
    {
        if (Random.value > probabilityOfFillingSlot)
        {
            return null;
        }
        //var randomItemNumber = Random.Range(0, legs.Count);
        BodyPart bodyPart = Instantiate(leg);
        bodyPart.GetComponent<LegItem>().Init();

        //bodyPart.item.stats = StatGenerator.Stats;
        return bodyPart;    }

    public void GetItemForSlot(Slot slot)
    {
        if (slot.RequiredItemType == typeof(HeadItem))
        {
            slot.Add(CreateHead());
        }
        else if (slot.RequiredItemType == typeof(ArmItem))
        {
            slot.Add(CreateArm());
        }
        else if (slot.RequiredItemType == typeof(LegItem))
        {
            slot.Add(CreateLeg());
        }
    }
    
    public Characteristics CreateRequiredStats()
    {
        var requiredStats = new Characteristics
        {
            agility = Random.Range(minMaxRequiredStats.x, minMaxRequiredStats.y),
            intelligence = Random.Range(minMaxRequiredStats.x, minMaxRequiredStats.y),
            strength = Random.Range(minMaxRequiredStats.x, minMaxRequiredStats.y)
        };
        return requiredStats;
    }
}
