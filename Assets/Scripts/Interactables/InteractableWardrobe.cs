using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableWardrobe : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private EventManager _eventManager;

    [SerializeField] private GameObject interactIcon;
    [SerializeField] private ClothType clothType;

    private void Start()
    {
        interactIcon.SetActive(false);
        _eventManager = FindFirstObjectByType<EventManager>();
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
        _eventManager.ToggleCloset(true);
        _eventManager.OpenInventory(clothType);
    }
}
