using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour
{
    private EventManager _eventManager;

    [SerializeField] private List<Room> rooms = new List<Room>();

    [SerializeField] private GameObject closetCanvas;

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();

        _eventManager.onToggleCloset += ToggleClosetCanvas;
    }

    private void OnDisable()
    {
        _eventManager.onToggleCloset -= ToggleClosetCanvas;
    }

    private void ToggleClosetCanvas(bool enabled)
    {
        closetCanvas.SetActive(enabled);
    }
}
