using UnityEngine;
using UnityEngine.EventSystems;

public class DisableHint : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.SetActive(false);
    }
}
