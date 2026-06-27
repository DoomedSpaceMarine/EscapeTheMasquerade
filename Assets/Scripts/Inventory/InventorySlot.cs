using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public bool slotIsFull;
    public bool slotImage;
    public ClothItemSO slotItem;

    public void SetImage(Sprite sprite) 
    { 
        slotImage = sprite; 
    }
}
