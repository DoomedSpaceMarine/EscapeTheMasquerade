using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private PlayerClothes playerClothes;

    public Vector2 itemOriginalPosition;

    [SerializeField] private Image itemImage;

    private void Start()
    {
        itemOriginalPosition = transform.position;

        playerClothes = FindFirstObjectByType<PlayerClothes>();
    }

    public void OnBeginDrag(PointerEventData data)
    {
        itemImage.raycastTarget = false;
        itemImage.maskable = false;
        playerClothes.currentGameobject = data.pointerDrag;
        playerClothes.currentlyDraggedItem = playerClothes.currentGameobject.GetComponent<InventorySlot>().slotItem;
    }

    public void OnDrag(PointerEventData data)
    {
        transform.position = data.position;
        
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (playerClothes.cursorIsOnTop)
        {
            Debug.Log("Item dropped on top of draggable");
        }
        transform.position = itemOriginalPosition;
        itemImage.raycastTarget = true;
        itemImage.maskable = true;
    }

    public void OnDrop(PointerEventData data)
    {
       

    }
}
