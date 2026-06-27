using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerClothes : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ClothItemSO currentlyDraggedItem;

    public GameObject currentGameobject;

    public bool cursorIsOnTop;

    //Player equipped slots
    [SerializeField] private Image headImage;
    [SerializeField] private Image torsoImage;
    [SerializeField] private Image legsImage;
    [SerializeField] private Image feetImage;

    //Naked sprite
    [SerializeField] private Sprite emptySprite;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
      cursorIsOnTop = true;
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        cursorIsOnTop = false;
    }

}
