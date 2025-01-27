using UnityEngine;

public class Boulet : MonoBehaviour
{
    [SerializeField] private float explosionSize;
    [SerializeField] private float explosionForce;
    [SerializeField] private float lifeTime;

    private Rigidbody rigi;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigi.linearVelocity = transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Récolter les colliders alentours
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionSize);
        for (int i = 0; i < colliders.Length; i++)
        {
            var col = colliders[i];
            //Filter en fonction de la présence d'un rb
            if(col.TryGetComponent(out Rigidbody rb))
            {
                //Leur appliquer une force
                rb.AddExplosionForce(explosionForce, transform.position, explosionSize);
            }
        }

        Destroy(gameObject);
    }
}
