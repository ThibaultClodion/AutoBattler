using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneAsset scene;

    public void LoadScene()
    {
        if(scene != null)
        {
            SceneManager.LoadScene(scene.name);
        }
    }

    public void ChangeScene(SceneAsset scene)
    {
        this.scene = scene;
    }
}
