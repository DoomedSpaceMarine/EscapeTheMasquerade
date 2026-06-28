using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Yarn.Unity;

public class RoomManager : MonoBehaviour
{
    private EventManager _eventManager;

    [SerializeField] private List<Room> rooms = new List<Room>();

    [SerializeField] private GameObject closetCanvas;

    [SerializeField] private Button closeClosetButton;

   private DialogueRunner _dialogueRunner;

    [SerializeField] private GameObject shadowMilkNeutral;
    [SerializeField] private GameObject shadowMilkAngry;

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();

        _eventManager.onToggleCloset += ToggleClosetCanvas;
        _eventManager.onChangeRoom += ChangeRoom;
    }

    private void OnDisable()
    {
        _eventManager.onToggleCloset -= ToggleClosetCanvas;
        _eventManager.onChangeRoom -= ChangeRoom;
    }

    private void Awake()
    {
        closeClosetButton.onClick.AddListener(() 
            => ToggleClosetCanvas(false));  
        
        closetCanvas.SetActive(false);

        _dialogueRunner = FindFirstObjectByType<DialogueRunner>();

        _dialogueRunner.AddCommandHandler<string>("change_room", ChangeRoom);
    }

    private void ToggleClosetCanvas(bool enabled)
    {
        if (!enabled)
        {
            _eventManager.CloseInventory();
        }
        closetCanvas.SetActive(enabled);
    }

    private void ChangeRoom(string roomName)
    {
        if(roomName == "Ballroom")
        {
            for(int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].roomType == RoomType.Ballroom)
                {
                    rooms[i].gameObject.SetActive(true);
                }

                if (rooms[i].roomType == RoomType.Corridor)
                {
                    rooms[i].gameObject.SetActive(false);
                }
            }
        }

        if(roomName == "Study")
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].roomType == RoomType.Study)
                {
                    rooms[i].gameObject.SetActive(true);
                }

                if (rooms[i].roomType == RoomType.Corridor)
                {
                    rooms[i].gameObject.SetActive(false);
                }
            }
        }

        if (roomName == "Corridor")
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].roomType == RoomType.Corridor)
                {
                    rooms[i].gameObject.SetActive(true);
                }

                if (rooms[i].roomType == RoomType.Study)
                {
                    rooms[i].gameObject.SetActive(false);
                    shadowMilkNeutral.SetActive(true);
                    shadowMilkAngry.SetActive(false);
                }
            }
        }

        if (roomName == "Ladyroom")
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].roomType == RoomType.LadyRoom)
                {
                    rooms[i].gameObject.SetActive(true);
                }

                if (rooms[i].roomType == RoomType.Corridor)
                {
                    rooms[i].gameObject.SetActive(false);
                }
            }
        }
    }
    }

