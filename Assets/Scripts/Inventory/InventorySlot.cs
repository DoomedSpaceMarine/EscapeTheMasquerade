using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public bool slotIsFull;
    public Image slotImage;
    public ClothItemSO slotItem;
    public Sprite emptySprite;

    private void Update()
    {
        if (!slotIsFull)
        {
            slotImage.sprite = emptySprite;
        }
    }

    public void SetImage(Sprite sprite) 
    { 
        slotImage.sprite = sprite;
    }
}
