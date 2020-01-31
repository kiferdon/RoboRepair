using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [System.Serializable]
    public struct Characteristics
    {
        public int Intelligence, Strength, Agility;
        const int MaxCharateristic = 10;

        public void Add(Characteristics characteristics)
        {
            Intelligence = Mathf.Clamp(Intelligence+characteristics.Intelligence,0,MaxCharateristic);
            Strength = Mathf.Clamp(Strength+characteristics.Strength,0,MaxCharateristic);
            Agility = Mathf.Clamp(Agility+characteristics.Agility,0,MaxCharateristic);
        }

        public void Subtract(Characteristics characteristics)
        {
            Intelligence = Mathf.Clamp(Intelligence-characteristics.Intelligence,0,MaxCharateristic);
            Strength = Mathf.Clamp(Strength-characteristics.Strength,0,MaxCharateristic);
            Agility = Mathf.Clamp(Agility-characteristics.Agility,0,MaxCharateristic);
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
        _textMeshProUgui.text = _characteristics.Intelligence.ToString()+" "
                                                                        +_characteristics.Strength.ToString()+" "
                                                                        +_characteristics.Agility.ToString()+" ";
    }
}
