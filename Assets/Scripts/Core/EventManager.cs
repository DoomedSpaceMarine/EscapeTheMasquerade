using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //EXAMPLE:
    //public event Action onPlayerCameraDisable;
    //public void PlayerCameraDisable() => onPlayerCameraDisable?.Invoke();

    //--UI--
    //Toggle Closet view
    public event Action<bool> onToggleCloset;
    public void ToggleCloset(bool enabled) => onToggleCloset?.Invoke(enabled);

    //--Inventory--
    //Add item to inventory
    public event Action<ClothItemSO> onAddItemToInventory;
    public void AddItemToInventory(ClothItemSO item) => onAddItemToInventory?.Invoke(item);
    //Remove item from inventory
    public event Action<ClothItemSO> onRemoveItemFromInventory;
    public void RemoveItemFromInventory(ClothItemSO item) => onRemoveItemFromInventory?.Invoke(item);
    //Open Inventory
    public event Action<ClothType> onOpenInventory;
    public void OpenInventory(ClothType clothType) => onOpenInventory?.Invoke(clothType);
    //Close Inventory
    public event Action onCloseInventory;
    public void CloseInventory() => onCloseInventory?.Invoke();

}
