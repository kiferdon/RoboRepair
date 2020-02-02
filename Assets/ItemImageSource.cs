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

    public static Sprite GetHead(int number)
    {
        return Instance.heads[number];
    }
    
    public static Sprite GetArm(int number)
    {
        return Instance.arms[number];
    }
    
    public static Sprite GetLeg(int number)
    {
        return Instance.legs[number];
    }

    public static Sprite GetShadowArm(out int randomNumber)
    {
        randomNumber = Random.Range(0, Instance.shadowArms.Count);
        Instance._numbersOfRealSprites.Enqueue(randomNumber);
        return Instance.shadowArms[randomNumber];
    }

    public static Sprite GetShadowLeg(out int randomNumber)
    {
        randomNumber = Random.Range(0, Instance.shadowLegs.Count);
        Instance._numbersOfRealSprites.Enqueue(randomNumber);
        return Instance.shadowLegs[randomNumber];    }

    public static Sprite GetShadowHead(out int randomNumber)
    {
        randomNumber = Random.Range(0, Instance.shadowHeads.Count);
        Instance._numbersOfRealSprites.Enqueue(randomNumber);
        return Instance.shadowHeads[randomNumber];    }
}
