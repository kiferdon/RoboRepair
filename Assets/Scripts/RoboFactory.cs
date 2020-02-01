using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Items;
using UnityEngine;
using Utility;
using Random = UnityEngine.Random;

public class RoboFactory : MonoBehaviour
{
    [SerializeField] private Robot robotPrefab;
    public static RoboFactory Instance;
    [SerializeField] private List<BodyPart> heads;
    [SerializeField] private List<BodyPart> arms;
    [SerializeField] private List<BodyPart> legs;
    [SerializeField] private float probabilityOfFillingSlot;
    [SerializeField] private Vector2Int minMaxRequiredStats;
    
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
        // for (int i = 0; i < heads.Count; i++)
        // {
        //     heads[i] = Instantiate(heads[i]);
        // }
        // for (int i = 0; i < arms.Count; i++)
        // {
        //     arms[i] = Instantiate(arms[i]);
        // }
        // for (int i = 0; i < legs.Count; i++)
        // {
        //     legs[i] = Instantiate(legs[i]);
        // }
        GenerateRobots();
    }

    private void GenerateRobots()
    {
        var numberOfRobots = robotPrefab.GetInitialCount();
        for (int i = 0; i < numberOfRobots; i++)
        {
            ObjectFactory.Instance.GetObject<Robot>(robotPrefab).name="Robot "+i;
        }
    }

    private BodyPart CreateHead()
    {
        if (Random.value > probabilityOfFillingSlot)
        {
            return null;
        }
        var randomItemNumber = Random.Range(0, heads.Count);
        BodyPart bodyPart = Instantiate(heads[randomItemNumber]);
        bodyPart.item.stats = StatGenerator.Stats;
        return bodyPart;    }
    
    private BodyPart CreateArm()
    {
        if (Random.value > probabilityOfFillingSlot)
        {
            return null;
        }
        var randomItemNumber = Random.Range(0, arms.Count);
        BodyPart bodyPart = Instantiate(arms[randomItemNumber]);
        bodyPart.item.stats = StatGenerator.Stats;
        //print(bodyPart.item.stats.Dexterity+" "+bodyPart.item.stats.Strength+" "+bodyPart.item.stats.Intelligence);
        return bodyPart;
    }
    
    private BodyPart CreateLeg()
    {
        if (Random.value > probabilityOfFillingSlot)
        {
            return null;
        }
        var randomItemNumber = Random.Range(0, legs.Count);
        BodyPart bodyPart = Instantiate(legs[randomItemNumber]);
        bodyPart.item.stats = StatGenerator.Stats;
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
