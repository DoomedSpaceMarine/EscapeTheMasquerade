using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    private EventManager _eventManager;

    //Items
    [SerializeField] private List<ClothItemSO> headClothes = new List<ClothItemSO>();
    [SerializeField] private List<ClothItemSO> torsoClothes = new List<ClothItemSO>();
    [SerializeField] private List<ClothItemSO> legsClothes = new List<ClothItemSO>();
    [SerializeField] private List<ClothItemSO> feetClothes = new List<ClothItemSO>();

    //Slots
    [SerializeField] private List<InventorySlot> headSlots = new List<InventorySlot>();
    [SerializeField] private List<InventorySlot> torsoSlots = new List<InventorySlot>();
    [SerializeField] private List<InventorySlot> legsSlots = new List<InventorySlot>();
    [SerializeField] private List<InventorySlot> feetSlots = new List<InventorySlot>();

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();

        _eventManager.onAddItemToInventory += AddItemToInventory;
        _eventManager.onRemoveItemFromInventory += RemoveItemFromInventory;
    }

    private void OnDisable()
    {
        _eventManager.onAddItemToInventory -= AddItemToInventory;
        _eventManager.onRemoveItemFromInventory -= RemoveItemFromInventory;
    }

    private void AddItemToInventory(ClothItemSO item)
    {
        switch (item.clothType)
        {
            case ClothType.Head: 
                headClothes.Add(item); 
                break;
            case ClothType.Torso:
                torsoClothes.Add(item);
                break;
            case ClothType.Legs:
                legsClothes.Add(item);
                break;
            case ClothType.Feet:
                feetClothes.Add(item);
                break;
        }
    }

    private void RemoveItemFromInventory(ClothItemSO item)
    {
        switch (item.clothType)
        {
            case ClothType.Head:
                headClothes.Remove(item);
                break;
            case ClothType.Torso:
                torsoClothes.Remove(item);
                break;
            case ClothType.Legs:
                legsClothes.Remove(item);
                break;
            case ClothType.Feet:
                feetClothes.Remove(item);
                break;
        }
    }

    private void DrawInventory(ClothType type)
    {
        switch (type)
        {
           
        }
    }
}
