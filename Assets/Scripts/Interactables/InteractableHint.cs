using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableHint : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameObject interactIcon;

    [SerializeField] private GameObject hintObject;

    [SerializeField] private bool hasUnlockableHint;

    [SerializeField] private GameObject[] unlockedHint;
    [SerializeField] private GameObject shadow;

    private void Start()
    {
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
        shadow.SetActive(true);
      hintObject.SetActive(true);
        if(hasUnlockableHint)
        {
            for (int i = 0; i < unlockedHint.Length; i++)
            {
                unlockedHint[i].SetActive(true);
            }
        } 
    }
}
