using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject canon;
    [SerializeField] private Boulet boulet;
    [SerializeField] private Transform spawnTransform;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnMouseDown() {
        var m = Instantiate(boulet);
        m.transform.position = spawnTransform.position;
        m.transform.forward = spawnTransform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
