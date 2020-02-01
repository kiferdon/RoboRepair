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
        GenerateRobots();
    }

    private void GenerateRobots()
    {
        var numberOfRobots = robotPrefab.GetInitialCount();
        for (int i = 0; i < numberOfRobots; i++)
        {
            ObjectFactory.Instance.GetObject<Robot>(robotPrefab);
        }
    }

    private BodyPart CreateHead()
    {
        if (Random.value > probabilityOfFillingSlot)
        {
            return null;
        }
        var randomItemNumber = Random.Range(0, heads.Count);
        return heads[randomItemNumber];
    }
    
    private BodyPart CreateArm()
    {
        if (Random.value > probabilityOfFillingSlot)
        {
            return null;
        }
        var randomItemNumber = Random.Range(0, arms.Count);
        arms[randomItemNumber].item.stats = StatGenerator.Stats;
        return arms[randomItemNumber];
    }
    
    private BodyPart CreateLeg()
    {
        if (Random.value > probabilityOfFillingSlot)
        {
            return null;
        }
        var randomItemNumber = Random.Range(0, legs.Count);
        return legs[randomItemNumber];
    }

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
}
