using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioUI : MonoBehaviour
{
    [SerializeField] private AudioSource background;
    [SerializeField] private Slider backgroundVolume;
    [SerializeField] private Slider globalVolume;

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "MenuScene") {
            background.volume = (backgroundVolume.value/100)*(globalVolume.value/100);
        }
    }
}
