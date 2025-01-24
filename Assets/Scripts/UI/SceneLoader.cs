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

    public void ChangeSceneToLoad(SceneAsset scene)
    {
        this.scene = scene;
    }
}
