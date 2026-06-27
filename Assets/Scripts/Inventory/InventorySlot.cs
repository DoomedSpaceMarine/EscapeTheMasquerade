using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public bool slotIsFull;
    public Image slotImage;
    public ClothItemSO slotItem;

    public void SetImage(Sprite sprite) 
    { 
        slotImage.sprite = sprite;
    }
}
