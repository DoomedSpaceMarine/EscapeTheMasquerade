using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerClothes : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private EventManager _eventManager;

    public ClothItemSO currentlyDraggedItem;

    public GameObject currentGameobject;

    public bool cursorIsOnTop;

    //Player equipped items
    [SerializeField] private ClothItemSO headItem;
    [SerializeField] private ClothItemSO torsoItem;
    [SerializeField] private ClothItemSO legsItem;
    [SerializeField] private ClothItemSO feetItem;

    //Player equipped image slots
    [SerializeField] private Image headImage;
    [SerializeField] private Image torsoImage;
    [SerializeField] private Image legsImage;
    [SerializeField] private Image feetImage;

    //Naked sprite
    [SerializeField] private Sprite emptySprite;

    private void Start()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
       cursorIsOnTop = true;
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        cursorIsOnTop = false;
    }

    public void NewItemIsDropped()
    {
        switch (currentlyDraggedItem.clothType)
        {
            case ClothType.Head:
                if(headItem != null)
                {
                    _eventManager.AddItemToInventory(headItem);
                }
                headItem = currentlyDraggedItem;
                headImage.sprite = currentlyDraggedItem.wornSprite;
                break;
            case ClothType.Torso:
                torsoItem = currentlyDraggedItem;
                torsoImage.sprite = currentlyDraggedItem.wornSprite;
                break;
            case ClothType.Legs:
                legsItem = currentlyDraggedItem;
                legsImage.sprite = currentlyDraggedItem.wornSprite;
                break;
            case ClothType.Feet:
                feetItem = currentlyDraggedItem;
                feetImage.sprite = currentlyDraggedItem.wornSprite;
                break;
        }

        currentGameobject.GetComponent<InventorySlot>().slotIsFull = false;
        currentGameobject.GetComponent<InventorySlot>().slotImage.sprite = null;
        _eventManager.RemoveItemFromInventory(currentlyDraggedItem);
        
        currentlyDraggedItem = null;
        currentGameobject = null;
    }

}
