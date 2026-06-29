using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableTalk : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
     private EventManager _eventManager;

    [SerializeField] private GameObject interactIcon;
    [SerializeField] private string dialogueNode;

    private void Start()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
        interactIcon.SetActive(false);
    }

    public void SetDialogueNode(string node)
    {
        dialogueNode = node;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        interactIcon.SetActive(true);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        interactIcon.SetActive(false);
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        _eventManager.StartDialogue(dialogueNode);
    }
}
