using UnityEngine;
using System.Collections;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private EventManager _eventManager;

    [SerializeField] private PlayerClothes player;

    [SerializeField] private string winDraculaNode;
    [SerializeField] private string loseDraculaNode;

    [SerializeField] private GameObject badEnding;
    [SerializeField] private GameObject goodEnding;

    //Player equipped items
    public ClothItemSO headItem;
    public ClothItemSO torsoItem;
    public ClothItemSO legsItem;
    public ClothItemSO feetItem;

    private DialogueRunner _dialogueRunner;

    private int shadowMilkCounter;
    private int guardCounter;

    [SerializeField] private GameObject shadowMilkNeutral;
    [SerializeField] private GameObject shadowMilkAngry;
    [SerializeField] private GameObject hint1;


    private void Start()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
        _dialogueRunner = FindFirstObjectByType<DialogueRunner>();

        _dialogueRunner.AddCommandHandler("dracula_test", DraculaTest);
        _dialogueRunner.AddCommandHandler("dracuul_bad", ShowBadEnding);
        _dialogueRunner.AddCommandHandler("dracuul_good", ShowGoodEnding);
        _dialogueRunner.AddCommandHandler("shadow_milk", ShadowMilkTest);
        _dialogueRunner.AddCommandHandler("guard_test", GuardTest);
        _dialogueRunner.AddCommandHandler("title_screen", TransitionTitleScreen);
        _dialogueRunner.AddCommandHandler("unlock_hint", UnlockHint);

        badEnding.SetActive(false);
        goodEnding.SetActive(false);
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

    private void ShadowMilkTest()
    {
        StartCoroutine(ShadowMilkDelay());
    }

    private void GuardTest()
    {
        StartCoroutine(GuardDelay());
    }

    private void ShowBadEnding()
    {
        badEnding.SetActive(true);
    }

    private void ShowGoodEnding()
    {
        goodEnding.SetActive(true);
    }

    private void UnlockHint()
    {
        hint1.SetActive(true);
    }

    private void TransitionTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
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

    private IEnumerator ShadowMilkDelay()
    {
        yield return new WaitForSeconds(0.2f);

        _eventManager.ChangeRoom("Study");

        if (headItem != null && headItem.clothTag == ClothTag.Servant)
        {
            shadowMilkCounter++;
        }
        if (torsoItem != null && torsoItem.clothTag == ClothTag.Servant)
        {
            shadowMilkCounter++;
        }
        if (legsItem != null && legsItem.clothTag == ClothTag.Servant)
        {
            shadowMilkCounter++;
        }
        if (feetItem != null && feetItem.clothTag == ClothTag.Servant)
        {
            shadowMilkCounter++;
        }

        if (shadowMilkCounter < 2)
        {
            shadowMilkNeutral.SetActive(false);
            shadowMilkAngry.SetActive(true);
            _eventManager.StartDialogue("ShadowMilkKick");
        }

    }

    private IEnumerator GuardDelay()
    {
        yield return new WaitForSeconds(0.2f);
        if (headItem != null && headItem.clothTag == ClothTag.Lady)
        {
            guardCounter++;
        }
        if (torsoItem != null && torsoItem.clothTag == ClothTag.Lady)
        {
            guardCounter++;
        }
        if (legsItem != null && legsItem.clothTag == ClothTag.Lady)
        {
            guardCounter++;
        }
        if (feetItem != null && feetItem.clothTag == ClothTag.Lady)
        {
            guardCounter++;
        }

        if (guardCounter < 3)
        {
            _eventManager.StartDialogue("Staked");
        }
        else
        {
            _eventManager.StartDialogue("Lady");
        }
    }
    }
