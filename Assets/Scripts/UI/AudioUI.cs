using UnityEngine;
using UnityEngine.UI;

public class AudioUI : MonoBehaviour
{
    [SerializeField] private AudioSource background;
    [SerializeField] private Slider backgroundVolume;
    [SerializeField] private Slider globalVolume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        background.volume = (backgroundVolume.value/100)*(globalVolume.value/100);
    }
}
