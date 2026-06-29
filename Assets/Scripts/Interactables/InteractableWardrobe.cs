using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableWardrobe : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private EventManager _eventManager;

    [SerializeField] private GameObject interactIcon;
    [SerializeField] private ClothType clothType;
    [SerializeField] private AudioSource wardrobeSfx;

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
        wardrobeSfx.Play();
        _eventManager.ToggleCloset(true);
        _eventManager.OpenInventory(clothType);
    }
}
