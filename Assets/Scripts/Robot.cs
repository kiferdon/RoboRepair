using System;
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

    public Characteristics RequiredStats => _requiredStats;

    [SerializeField] private List<Slot> slots;
    public event Action<Characteristics,Characteristics> UpdatePoints;
    [SerializeField] private ChangeBody changeBody;
    [SerializeField] private Tablo tablo;
    
    
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

    public override void Init()
    {
        _requiredStats = RoboFactory.Instance.CreateRequiredStats();
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].Init();
            RoboFactory.Instance.GetItemForSlot(slots[i]);
        }
        UpdatePoints?.Invoke(_characteristics, _requiredStats);
        changeBody.ChangeBodyToShadow();
    }

    protected virtual void OnUpdatePoints()
    {
        UpdatePoints?.Invoke(_characteristics, _requiredStats);
    }

    public void Build()
    {
        changeBody.ChangeBodyToReal();
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].Build();
        }
    }

    public void HideTablo()
    {
        print("hide tablo");
        tablo.HideTablo();
    }
}
