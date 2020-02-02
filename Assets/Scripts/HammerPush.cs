using UnityEngine;
using Utility;

public class HammerPush : MonoBehaviour {
    public Animator animation;
    private static readonly int push = Animator.StringToHash("Push");

    public void Play() {
        GameManager.Instance.PlayHammer();
        animation.SetTrigger(push);
    }
}