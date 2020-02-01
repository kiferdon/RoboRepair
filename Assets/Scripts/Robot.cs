﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using Utility;

public class Robot : PoolObject
{
    private Characteristics _characteristics;
    public Characteristics Characteristics => _characteristics;
    private Characteristics _requiredStats;
    [SerializeField] private List<Slot> slots;
    [SerializeField] private TextMeshProUGUI _textMeshProUgui;
    public event Action<Characteristics,Characteristics> UpdatePoints;
    
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].ItemAddEvent += OnConnect;
            slots[i].ItemRemoveEvent += OnDisconnect;
        }
    }

    private void OnConnect(Characteristics characteristics)
    {
        _characteristics.Add(characteristics);
        OnUpdatePoints();
    }

    private void OnDisconnect(Characteristics characteristics)
    {
        _characteristics.Subtract(characteristics);
        OnUpdatePoints();
    }

    private void Update()
    {
        // _textMeshProUgui.text = _characteristics.intelligence.ToString()+" "
        //                                                                 +_characteristics.strength.ToString()+" "
        //                                                                 +_characteristics.agility.ToString()+" ";
    }

    

    public override void Init()
    {
        _requiredStats = RoboFactory.Instance.CreateRequiredStats();
        for (int i = 0; i < slots.Count; i++)
        {
            RoboFactory.Instance.GetItemForSlot(slots[i]);
        }
    }

    protected virtual void OnUpdatePoints()
    {
        print(gameObject.name);
        print("current "+_characteristics.intelligence+_characteristics.strength+_characteristics.agility);
        print("required "+_requiredStats.intelligence+_requiredStats.strength+_requiredStats.agility);
        UpdatePoints?.Invoke(_characteristics, _requiredStats);
    }
}
