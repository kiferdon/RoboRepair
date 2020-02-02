using UnityEngine;

public class HammerPush : MonoBehaviour {
    public Animator animation;
    private static readonly int push = Animator.StringToHash("Push");

    public void Play() {
        animation.SetTrigger(push);
    }
}