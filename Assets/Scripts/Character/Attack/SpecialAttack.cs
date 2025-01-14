using UnityEngine;

public class SpecialAttack : Attack
{
    public override void Launch(Transform target, Animator animator)
    {
        base.Launch(target, animator);

        Debug.Log("Test Special Attack");
    }
}
