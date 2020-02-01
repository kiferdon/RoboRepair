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

    public override void Init()
    {
        _requiredStats = RoboFactory.Instance.CreateRequiredStats();
        for (int i = 0; i < slots.Count; i++)
        {
            RoboFactory.Instance.GetItemForSlot(slots[i]);
        }
        UpdatePoints?.Invoke(_characteristics, _requiredStats);
    }

    protected virtual void OnUpdatePoints()
    {
        UpdatePoints?.Invoke(_characteristics, _requiredStats);
    }
}
