using UnityEngine;

public class SpecialAttack : Attack
{
    public override void Launch(Character Launcher, Transform target, Animator animator)
    {
        base.Launch(Launcher, target, animator);

        Debug.Log("Test Special Attack");
    }
}
