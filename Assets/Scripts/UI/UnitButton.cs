using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    public Button button;
    [SerializeField] private Image characterImage;

    public void Init(Sprite characterSprite)
    {
        characterImage.sprite = characterSprite;
    }
}