using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
    }
}
