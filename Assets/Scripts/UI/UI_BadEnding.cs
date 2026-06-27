using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_BadEnding : MonoBehaviour
{
    [SerializeField] private Button menuButton;

    private void Start()
    {
        menuButton.onClick.AddListener(()
            => MenuButton());
    }

    private void MenuButton()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
