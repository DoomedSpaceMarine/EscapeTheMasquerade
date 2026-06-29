using UnityEngine;

public class UpdateDialogueSM : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnDestroy()
    {
        _gameManager.UpdateShadowMilkDialogue();
    }
}
