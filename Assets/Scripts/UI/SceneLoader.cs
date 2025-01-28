using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void LoadScene()
    {
        if(sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void ChangeSceneToLoad(string scene)
    {
        this.sceneName = scene;
    }
}
