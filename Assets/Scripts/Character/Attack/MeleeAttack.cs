using UnityEngine;

public class MeleeAttack : Attack
{
    public override void Launch(Transform target, Animator animator)
    {
        base.Launch(target, animator);

        Debug.Log("Test Attack");
    }
}
