using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //EXAMPLE:
    //public event Action onPlayerCameraDisable;
    //public void PlayerCameraDisable() => onPlayerCameraDisable?.Invoke();

    //Toggle Closet view
    public event Action<bool> onToggleCloset;
    public void ToggleCloset(bool enabled) => onToggleCloset?.Invoke(enabled);
}
