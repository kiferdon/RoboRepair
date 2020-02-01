using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using Utility;

public class Robot : PoolObject
{
    [System.Serializable]
    public struct Characteristics
    {
        public int intelligence, strength, agility;
        const int MaxCharateristic = 10;

        public void Add(Characteristics characteristics)
        {
            intelligence = Mathf.Clamp(intelligence+characteristics.intelligence,0,MaxCharateristic);
            strength = Mathf.Clamp(strength+characteristics.strength,0,MaxCharateristic);
            agility = Mathf.Clamp(agility+characteristics.agility,0,MaxCharateristic);
        }

        public void Subtract(Characteristics characteristics)
        {
            intelligence = Mathf.Clamp(intelligence-characteristics.intelligence,0,MaxCharateristic);
            strength = Mathf.Clamp(strength-characteristics.strength,0,MaxCharateristic);
            agility = Mathf.Clamp(agility-characteristics.agility,0,MaxCharateristic);
        }
    }

    private Characteristics _characteristics;
    [SerializeField] private List<Slot> slots;
    [SerializeField] private TextMeshProUGUI _textMeshProUgui;
    
    
    // Start is called before the first frame update
    void Start()
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
    }

    private void OnDisconnect(Characteristics characteristics)
    {
        _characteristics.Subtract(characteristics);
    }

    private void Update()
    {
        // _textMeshProUgui.text = _characteristics.intelligence.ToString()+" "
        //                                                                 +_characteristics.strength.ToString()+" "
        //                                                                 +_characteristics.agility.ToString()+" ";
    }

    public override void Init()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            RoboFactory.Instance.GetItemForSlot(slots[i]);
        }
    }
}
