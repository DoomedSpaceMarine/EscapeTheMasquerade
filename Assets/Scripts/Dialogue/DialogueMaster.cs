using UnityEngine;
using Yarn.Unity;

public class DialogueMaster : MonoBehaviour
{
    private EventManager _eventManager;
    [SerializeField] private DialogueRunner _dialogueRunner;
    [SerializeField] private GameObject dialogueCanvas;

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();

        _eventManager.onStartDialogue += StartDialogue;
    }

    private void OnDisable()
    {
        _eventManager.onStartDialogue -= StartDialogue;
    }

    private void Start()
    {
        dialogueCanvas.SetActive(false);
    }

    private void StartDialogue(string node)
    {
        dialogueCanvas.SetActive(true);
        _dialogueRunner.StartDialogue(node);
    }

    public void DisableCanvas()
    {
        dialogueCanvas.SetActive(false);
    }
}
