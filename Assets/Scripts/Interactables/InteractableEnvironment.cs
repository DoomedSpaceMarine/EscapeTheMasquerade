using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableEnvironment : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private EventManager _eventManager;

    [SerializeField] private GameObject interactIcon;

    [SerializeField] private GameObject currentRoom;
    [SerializeField] private GameObject nextRoom;

    [SerializeField] private bool isDialogue;
    [SerializeField] private string dialogueNode;
    private void Start()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
        interactIcon.SetActive(false);
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
        if (isDialogue)
        {
            _eventManager.StartDialogue(dialogueNode);
        }
        else
        {
            currentRoom.SetActive(false);
            nextRoom.SetActive(true);
        }
    }
}
