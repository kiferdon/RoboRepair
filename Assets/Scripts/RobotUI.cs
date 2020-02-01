using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotUI : MonoBehaviour
{
    [SerializeField]
    private Color requiredColor, extraColor, currentColor,emptyColor;
    [SerializeField] private Robot robot;
    [SerializeField] private List<Transform> bars;
    private List<SpriteRenderer[]> _barSprites;
    private void Awake()
    {
        robot.UpdatePoints += UpdateRobotUI;
        _barSprites=new List<SpriteRenderer[]>();
        for (int i = 0; i < bars.Count; i++)
        {    
            SpriteRenderer[] sprites = new SpriteRenderer[bars[i].childCount];
            for (int j = 0; j < sprites.Length; j++)
            {
                sprites[j] = bars[i].GetChild(j).GetComponent<SpriteRenderer>();
            }
            _barSprites.Add(sprites);
        }
    }

    private void UpdateRobotUI(Characteristics characteristics,Characteristics required)
    { 
        DisplayBar(characteristics.intelligence,required.intelligence,0);
        DisplayBar(characteristics.strength,required.strength,1);
        DisplayBar(characteristics.agility,required.agility,2);

    }

    private void DisplayBar(int current,int required,int barNumber)
    {
        if (current <= required)
        {
            for (int i = 0; i < current; ++i)
            {
                _barSprites[barNumber][i].color = currentColor;
            }
            for (int i = current; i < required; ++i)
            {
                _barSprites[barNumber][i].color = requiredColor;
            }
            for (int i = required; i < _barSprites[barNumber].Length; ++i)
            {
                _barSprites[barNumber][i].color = emptyColor;
            }
        }
        else
        {
            for (int i = 0; i < required; ++i)
            {
                _barSprites[barNumber][i].color = currentColor;
            }
            for (int i = required; i < current; ++i)
            {
                _barSprites[barNumber][i].color = extraColor;
            }
            for (int i = current; i < _barSprites[barNumber].Length; ++i)
            {
                _barSprites[barNumber][i].color = emptyColor;
            }
        }
    }
}
