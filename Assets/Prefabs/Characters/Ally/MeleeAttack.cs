using UnityEngine;

public class MeleeAttack : Attack
{
    public override void Launch(Character Launcher, Transform target, Animator animator)
    {
        base.Launch(Launcher, target, animator);

        Launcher.AddMana(1);

        Debug.Log("Test Attack");
    }
}
