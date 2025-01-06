using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton, quitButton, optionButton, backButton;
    [SerializeField] private GameObject menu, option;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        option.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void OnEnable()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        optionButton.onClick.AddListener(Options);
        backButton.onClick.AddListener(BackButton);
    }

    void OnDisable()
    {
        startButton.onClick.RemoveListener(StartGame);
        quitButton.onClick.RemoveListener(QuitGame);
        optionButton.onClick.RemoveListener(Options);
        backButton.onClick.RemoveListener(BackButton);
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void Options()
    {
        menu.gameObject.SetActive(false);
        option.gameObject.SetActive(true);
    }

    void BackButton()
    {
        menu.gameObject.SetActive(true);
        option.gameObject.SetActive(false);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
