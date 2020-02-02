using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablo : MonoBehaviour {
    private Animator animator;
    private static readonly int push = Animator.StringToHash("Push");
    private static readonly int Entry = Animator.StringToHash("Entry");

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void HideTablo() {
        animator.ResetTrigger(Entry);

        animator.SetTrigger(push);
    }

    public void ShowTablo()
    {
        animator.ResetTrigger(push);
        animator.SetTrigger(Entry);
        //animator.ResetTrigger(push);
        //animator.Rebind();
        //animator.Play("New State");
        //animator.enabled = false;
        //animator.enabled = true;
    }
    
    
    private void OnDisable() {
        //animator.ResetTrigger(push);
    }
}