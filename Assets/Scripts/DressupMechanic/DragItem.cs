using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private PlayerClothes playerClothes;
    private InventorySlot thisSlot;

    public Vector2 itemOriginalPosition;

    [SerializeField] private Image itemImage;

    private void Start()
    {
        itemOriginalPosition = transform.position;

        thisSlot= GetComponent<InventorySlot>();    

        playerClothes = FindFirstObjectByType<PlayerClothes>();
    }

    public void OnBeginDrag(PointerEventData data)
    {
        if (thisSlot.slotIsFull)
        {
            itemImage.raycastTarget = false;
            itemImage.maskable = false;
            playerClothes.currentGameobject = data.pointerDrag;
            playerClothes.currentlyDraggedItem = playerClothes.currentGameobject.GetComponent<InventorySlot>().slotItem;
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (thisSlot.slotIsFull)
        {
            transform.position = data.position;
        }
        
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (playerClothes.cursorIsOnTop)
        {
            playerClothes.NewItemIsDropped();
        }
        transform.position = itemOriginalPosition;
        itemImage.raycastTarget = true;
        itemImage.maskable = true;
    }
}
