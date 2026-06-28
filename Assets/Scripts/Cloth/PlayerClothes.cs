using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerClothes : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private EventManager _eventManager;
    private GameManager _gameManager;

    public ClothItemSO currentlyDraggedItem;

    public GameObject currentGameobject;

    public bool cursorIsOnTop;

    //Player equipped image slots
    [SerializeField] private Image headImage;
    [SerializeField] private Image torsoImage;
    [SerializeField] private Image legsImage;
    [SerializeField] private Image feetImage;

    //Naked sprite
    [SerializeField] private Sprite emptySprite;

    [SerializeField] private AudioSource clothSFX;

    private void Start()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
        _gameManager= FindFirstObjectByType<GameManager>();
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
                if(_gameManager.headItem != null)
                {
                    _eventManager.AddItemToInventory(_gameManager.headItem);
                }
                _gameManager.headItem = currentlyDraggedItem;
                headImage.sprite = currentlyDraggedItem.wornSprite;
                break;
            case ClothType.Torso:
                if (_gameManager.torsoItem != null)
                {
                    _eventManager.AddItemToInventory(_gameManager.torsoItem);
                }
                _gameManager.torsoItem = currentlyDraggedItem;
                torsoImage.sprite = currentlyDraggedItem.wornSprite;
                break;
            case ClothType.Legs:
                if (_gameManager.legsItem != null)
                {
                    _eventManager.AddItemToInventory(_gameManager.legsItem);
                }
                _gameManager.legsItem = currentlyDraggedItem;
                legsImage.sprite = currentlyDraggedItem.wornSprite;
                break;
            case ClothType.Feet:
                if (_gameManager.feetItem != null)
                {
                    _eventManager.AddItemToInventory(_gameManager.feetItem);
                }
                _gameManager.feetItem = currentlyDraggedItem;
                feetImage.sprite = currentlyDraggedItem.wornSprite;
                break;
        }
        clothSFX.Play();
        currentGameobject.GetComponent<InventorySlot>().slotIsFull = false;
        currentGameobject.GetComponent<InventorySlot>().slotImage.sprite = null;
        _eventManager.RemoveItemFromInventory(currentlyDraggedItem);
        
        currentlyDraggedItem = null;
        currentGameobject = null;
    }

   

}
