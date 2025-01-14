using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private bool isSpell;
    [SerializeField] private AnimationClip animationClip;
    [SerializeField] private float cooldown;
    [SerializeField] public float range;

    public virtual void Launch(Character Launcher, Transform target, Animator animator)
    {
        if(isSpell)
        {
            animator.Play("Spell");
        }
        else
        {
            animator.Play("Attack");
        }
    }

    public float GetCooldown()
    {
        return animationClip.length + cooldown;
    }
}