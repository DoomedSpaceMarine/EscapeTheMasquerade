using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    private EventManager _eventManager;

    [SerializeField] private List<Room> rooms = new List<Room>();

    [SerializeField] private GameObject closetCanvas;

    [SerializeField] private Button closeClosetButton;

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();

        _eventManager.onToggleCloset += ToggleClosetCanvas;
    }

    private void OnDisable()
    {
        _eventManager.onToggleCloset -= ToggleClosetCanvas;
    }

    private void Awake()
    {
        closeClosetButton.onClick.AddListener(() 
            => ToggleClosetCanvas(false));  
        
        closetCanvas.SetActive(false);
    }

    private void ToggleClosetCanvas(bool enabled)
    {
        if (!enabled)
        {
            _eventManager.CloseInventory();
        }
        closetCanvas.SetActive(enabled);
    }
}
