using System.Collections;
using UnityEngine;

public class ProjectileThrower : Attack
{
    [Header("Thrower properties")]
    [SerializeField] private Projectile projectile;
    [SerializeField] private Transform throwPosition;
    [SerializeField] private float waitingTime;

    public override void Launch(Character launcher, Transform target, Animator animator)
    {
        base.Launch(launcher, target, animator);

        StartCoroutine(LaunchProjectile());
        launcher.AddMana(1);
    }

    IEnumerator LaunchProjectile()
    {
        yield return new WaitForSeconds(waitingTime);
        Instantiate(projectile, throwPosition.position, throwPosition.rotation);
    }
}