using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Objects/Attack")]
public class AttackOld : ScriptableObject
{
    [SerializeField] public AnimationClip animationClip;
    [SerializeField] private float cooldown;
    [SerializeField] public float range;

    public float GetCooldownDuration()
    {
        return animationClip.length + cooldown;
    }
}
