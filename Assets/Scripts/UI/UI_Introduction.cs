using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Introduction : MonoBehaviour
{
    [SerializeField] private Button continueButton;

    private void Awake()
    {
        continueButton.onClick.AddListener(() => PlayButton());
    }

    private void PlayButton()
    {
        SceneManager.LoadScene("Level");
    }
}
