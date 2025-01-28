using UnityEngine;

public class BombeLauncher : MonoBehaviour
{
    [SerializeField] GameObject bombe;
    [SerializeField] Explosion explosion;
    [SerializeField] Transform spawnExplosion;
    [SerializeField] Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnMouseDown() {
        explosion.Launch(null, spawnExplosion, animator);
    }
}
