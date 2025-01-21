using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Attack basics")]
    [SerializeField] private bool isSpell;
    [SerializeField] private AnimationClip animationClip;
    [SerializeField] private float cooldown;
    [SerializeField] public float range;

    public virtual void Launch(Character launcher, Transform target, Animator animator)
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

    public float GetAnimationClipTime()
    {
        return animationClip.length;
    }
}