using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class ItemImageSource : Singleton<ItemImageSource>
{
    [SerializeField] private List<Sprite> heads,arms,legs;

    public static Sprite GetHead()
    {
        return Instance.heads[Random.Range(0, Instance.heads.Count)];
    }
    
    public static Sprite GetArm()
    {
        return Instance.arms[Random.Range(0, Instance.arms.Count)];
    }
    
    public static Sprite GetLeg()
    {
        return Instance.legs[Random.Range(0, Instance.legs.Count)];
    }
}
