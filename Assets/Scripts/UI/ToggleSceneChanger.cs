using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSceneChanger : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private SceneAsset scene;

    void Start()
    {
        toggle.onValueChanged.AddListener(delegate { ChangeLoadScene(toggle);});
    }

    void ChangeLoadScene(Toggle change)
    {
        if(change.isOn)
        {
            sceneLoader.ChangeScene(scene);
        }
    }
}
