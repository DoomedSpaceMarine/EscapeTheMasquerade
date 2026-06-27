using UnityEngine;
using System.Collections;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    private EventManager _eventManager;

    [SerializeField] private PlayerClothes player;

    [SerializeField] private string winDraculaNode;
    [SerializeField] private string loseDraculaNode;

    [SerializeField] private GameObject badEnding;

    //Player equipped items
    public ClothItemSO headItem;
    public ClothItemSO torsoItem;
    public ClothItemSO legsItem;
    public ClothItemSO feetItem;

    private DialogueRunner _dialogueRunner;

    private void Start()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
        _dialogueRunner = FindFirstObjectByType<DialogueRunner>();

        _dialogueRunner.AddCommandHandler("dracula_test", DraculaTest);
        _dialogueRunner.AddCommandHandler("dracuul_bad", ShowBadEnding);

        badEnding.SetActive(false);
    }
    public void DraculaTest()
    {
        Debug.Log("Is this running?");
        if (headItem != null && torsoItem != null && legsItem != null && feetItem != null)
        {
            if (headItem.clothTag == ClothTag.Dracula && torsoItem.clothTag == ClothTag.Dracula && legsItem.clothTag == ClothTag.Dracula && feetItem.clothTag == ClothTag.Dracula)
            {
                StartCoroutine(WinDelay());
            }
            else
            {
                StartCoroutine(LoseDelay());
            }
        }
        else
        {
            StartCoroutine(LoseDelay());
        }
    }

    private void ShowBadEnding()
    {
        badEnding.SetActive(true);
    }

    private  IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(0.2f);
        _eventManager.StartDialogue(winDraculaNode);
    }

    private IEnumerator LoseDelay()
    {
        yield return new WaitForSeconds(0.2f);
        _eventManager.StartDialogue(loseDraculaNode);
    }
}
