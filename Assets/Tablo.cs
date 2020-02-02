using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablo : MonoBehaviour
{
    private Animator animator;
    private static readonly int push = Animator.StringToHash("Push");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void HideTablo()
    {
        animator.SetTrigger(push);
        
    }

    private void OnDisable()
    {
        animator.ResetTrigger(push);
    }
}
