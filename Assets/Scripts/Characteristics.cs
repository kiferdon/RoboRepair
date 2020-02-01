using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
