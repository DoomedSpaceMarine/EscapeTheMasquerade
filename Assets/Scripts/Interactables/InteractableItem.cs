using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private EventManager _eventManager;

    [SerializeField] private GameObject interactIcon;
    [SerializeField] private ClothItemSO[] items;
    [SerializeField] private string dialogueNode;

   [SerializeField] private bool hasSfx;
    [SerializeField] private AudioSource itemSfx;

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
        if (hasSfx)
        {
            itemSfx.Play();
        }
        _eventManager.StartDialogue(dialogueNode);
        for(int i = 0; i < items.Length; i++)
        {
            _eventManager.AddItemToInventory(items[i]);
        }
        Destroy(this.gameObject);
    }
}
