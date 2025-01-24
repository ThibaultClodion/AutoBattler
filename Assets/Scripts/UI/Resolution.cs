using UnityEngine;
using TMPro;

public class Resolution : MonoBehaviour
{
    [SerializeField] TMP_Dropdown resol;

    public void SetResolution(){
        switch(resol.value) {
            case 0:
                Screen.SetResolution(720, 480, true);
                break;
            case 1:
                Screen.SetResolution(1280, 720, true);
                break;
            case 2:
                Screen.SetResolution(1920, 1080, true);
                break;
        }
    }
}
