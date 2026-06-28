using UnityEngine;
using UnityEngine.EventSystems;

public class DisableHint : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject[] hints;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        for(int i = 0; i < hints.Length; i++)
        {
            hints[i].SetActive(false);
        }
    }
}
