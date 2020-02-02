using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChangeBody : MonoBehaviour
{
    [SerializeField] private Sprite realSprite,shadowSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    
    public void ChangeBodyToReal()
    {
        spriteRenderer.sprite = realSprite;
    }
    
    public void ChangeBodyToShadow()
    {
        spriteRenderer.sprite = shadowSprite;
    }
}
