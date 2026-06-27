using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_TitleScreen : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(() => PlayButton());
        quitButton.onClick.AddListener(() => QuitButton());
    }

    private void PlayButton()
    {
        SceneManager.LoadScene("Level");
    }

    private void QuitButton()
    {
        Application.Quit();
    }
}
