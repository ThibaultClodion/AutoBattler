using UnityEngine;

public class BombeLauncher : MonoBehaviour
{
    [SerializeField] private GameObject bombe;
    [SerializeField] private Explosion explosion;
    [SerializeField] private Transform spawnExplosion;
    [SerializeField] private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnMouseDown() {
        explosion.Launch(null, spawnExplosion, animator);
        Destroy(this.gameObject);
    }
}
