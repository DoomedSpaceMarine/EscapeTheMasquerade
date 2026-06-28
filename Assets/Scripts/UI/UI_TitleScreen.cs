using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_TitleScreen : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private GameObject creditsCanvas;

    private void Awake()
    {
        playButton.onClick.AddListener(() => PlayButton());
        creditsButton.onClick.AddListener(() => CreditsButton());
        quitButton.onClick.AddListener(() => QuitButton());
    }

    private void PlayButton()
    {
        SceneManager.LoadScene("Introduction");
    }

    private void CreditsButton()
    {
        creditsCanvas.SetActive(true);
    }

    private void QuitButton()
    {
        Application.Quit();
    }
}
