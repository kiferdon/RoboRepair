using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class ItemImageSource : Singleton<ItemImageSource>
{
    [SerializeField] private List<Sprite> heads,arms,legs;
    [SerializeField] private List<Sprite> shadowHeads,shadowArms,shadowLegs;
    private Queue<int> _numbersOfRealSprites;

    protected override void Awake()
    {
        base.Awake();
        _numbersOfRealSprites = new Queue<int>();
    }

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

    public static Sprite GetShadowArm()
    {
        var randomNumber = Random.Range(0, Instance.shadowArms.Count);
        Instance._numbersOfRealSprites.Enqueue(randomNumber);
        return Instance.shadowArms[randomNumber];
    }

    public static Sprite GetShadowLeg()
    {
        var randomNumber = Random.Range(0, Instance.shadowLegs.Count);
        Instance._numbersOfRealSprites.Enqueue(randomNumber);
        return Instance.shadowLegs[randomNumber];    }

    public static Sprite GetShadowHead()
    {
        var randomNumber = Random.Range(0, Instance.shadowHeads.Count);
        Instance._numbersOfRealSprites.Enqueue(randomNumber);
        return Instance.shadowHeads[randomNumber];    }
}
