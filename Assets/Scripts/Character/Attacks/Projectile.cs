using System.Collections;
using UnityEngine;

[System.Serializable]
public class ProjectileData
{
    public float speed;
    public float damage;
    public bool isAnExplosion;
    public float explosionRadius;
    public ParticleSystem particleOnHit;

    [HideInInspector] public Transform target;
    [HideInInspector] public int launcherTeamNumber;
}

public class Projectile : MonoBehaviour
{
    private ProjectileData data = new ProjectileData();

    public void Init(ProjectileData projectileData)
    {
        data.speed = projectileData.speed;
        data.damage = projectileData.damage;
        data.isAnExplosion = projectileData.isAnExplosion;
        data.explosionRadius = projectileData.explosionRadius;
        data.particleOnHit = projectileData.particleOnHit;

        data.target = projectileData.target;
        data.launcherTeamNumber = projectileData.launcherTeamNumber;

        StartCoroutine(SelfDestroy());
    }

    private void Update()
    {
        if (data.target != null)
        {
            transform.position += (data.target.position - transform.position).normalized * Time.deltaTime * data.speed;
        }
        else
        {
            transform.position += Vector3.forward * Time.deltaTime * data.speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!data.isAnExplosion)
        {
            bool isHitten = HitEnnemy(other);

            if (isHitten)
            {
                if (data.particleOnHit != null)
                {
                    Instantiate(data.particleOnHit, transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
            }
        }
        //Projectile can't explode on a ally
        if (data.isAnExplosion && !IsAnAlly(other))
        {
            if (data.particleOnHit != null)
            {
                Instantiate(data.particleOnHit, transform.position, Quaternion.identity);
            }

            Collider[] hitten = Physics.OverlapSphere(transform.position, data.explosionRadius);

            foreach (Collider collider in hitten)
            {
                HitEnnemy(collider);
            }

            Destroy(gameObject);
        }
    }

    private bool HitEnnemy(Collider other)
    {
        if (other.tag == "Character")
        {
            Character hitCharacter = other.GetComponent<Character>();

            if (hitCharacter.teamNumber != data.launcherTeamNumber)
            {
                hitCharacter.TakeDamage(data.damage);
                return true;
            }
        }

        return false;
    }

    private bool IsAnAlly(Collider other)
    {
        if(other.tag == "Character")
        {
            return other.GetComponent<Character>().teamNumber == data.launcherTeamNumber;
        }

        return false;
    }

    IEnumerator SelfDestroy()
    {
        //TODO : Add invisible triggers to delete projectiles
        //TODO : Add a pooling system
        yield return new WaitForSeconds(10f);

        Destroy(gameObject);
    }
}