using UnityEngine;

[System.Serializable]
public class ProjectileData
{
    public float speed;
    public float damage;
    [HideInInspector] public int launcherTeamNumber;
}

public class Projectile : MonoBehaviour
{
    private ProjectileData data = new ProjectileData();

    public void Init(ProjectileData projectileData)
    {
        data.speed = projectileData.speed;
        data.damage = projectileData.damage;
        data.launcherTeamNumber = projectileData.launcherTeamNumber;
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * data.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {
            Character hitCharacter = other.GetComponent<Character>();

            if (hitCharacter.teamNumber != data.launcherTeamNumber)
            {
                hitCharacter.TakeDamage(data.damage);
                Destroy(gameObject);
            }
        }
    }
}