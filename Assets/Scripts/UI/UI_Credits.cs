using UnityEngine;
using UnityEngine.UI;

public class UI_Credits : MonoBehaviour
{
    [SerializeField] private Button creditsButton;

    private void Start()
    {
        creditsButton.onClick.AddListener(()
            => DisableCredits());
    }

    private void DisableCredits()
    {
        this.gameObject.SetActive(false);   
    }
}
