using System.Collections;
using UnityEngine;

public class ProjectilesThrower : Attack
{
    [Header("Thrower properties")]
    [SerializeField] private GameObject projectiles;
    [SerializeField] private Transform throwPosition;
    [SerializeField] private float waitingTime;

    [Header("Projectile property")]
    [SerializeField] private ProjectileData projectileData;

    public override void Launch(Character launcher, Transform target, Animator animator)
    {
        base.Launch(launcher, target, animator);
        projectileData.launcherTeamNumber = launcher.teamNumber;

        StartCoroutine(LaunchProjectile());
    }

    IEnumerator LaunchProjectile()
    {
        yield return new WaitForSeconds(waitingTime);

        Projectile[] projectilesArray = projectiles.GetComponentsInChildren<Projectile>(); 

        foreach (Projectile projectile in projectilesArray)
        {
            Projectile throwed = Instantiate(projectile, throwPosition.position + projectile.transform.position, 
                throwPosition.rotation * projectile.transform.rotation);
            throwed.Init(projectileData);
        }
    }
}