using UnityEngine;

public class TriggerDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {
            Destroy(other.gameObject);
        }
    }
}
