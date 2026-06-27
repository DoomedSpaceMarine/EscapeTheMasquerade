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

    //Slot parents
    [SerializeField] private GameObject headSlotParent;
    [SerializeField] private GameObject torsoSlotParent;
    [SerializeField] private GameObject legsSlotParent;
    [SerializeField] private GameObject feetSlotParent;

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
        _eventManager.onOpenInventory += OpenInventory;
    }

    private void OnDisable()
    {
        _eventManager.onAddItemToInventory -= AddItemToInventory;
        _eventManager.onRemoveItemFromInventory -= RemoveItemFromInventory;
        _eventManager.onOpenInventory -= OpenInventory;
    }

    private void Start()
    {
        headSlotParent.SetActive(false);
        torsoSlotParent.SetActive(false);
        legsSlotParent.SetActive(false);
        feetSlotParent.SetActive(false);
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

    private void OpenInventory(ClothType clothType)
    {
        switch (clothType)
        {
            case ClothType.Head:
                headSlotParent.SetActive(true);
                DrawInventory(clothType);
                break;

            case ClothType.Torso:
                torsoSlotParent.SetActive(true);
                DrawInventory(clothType);
                break;

            case ClothType.Legs:
                legsSlotParent.SetActive(true);
                DrawInventory(clothType);
                break;

            case ClothType.Feet:
                feetSlotParent.SetActive(true);
                DrawInventory(clothType);
                break;
        }
    }

    private void DrawInventory(ClothType type)
    {
        switch (type)
        {
            case ClothType.Head:
                headSlots.Clear();
                for(int i = 0; i < headClothes.Count; i++)
                {
                    if (!headSlots[i].slotIsFull)
                    {
                        headSlots[i].slotIsFull = true;
                        headSlots[i].slotItem = headClothes[i];
                        headSlots[i].SetImage(headClothes[i].wardrobeSprite);
                    }
                }
                break;

            case ClothType.Torso:
                torsoSlots.Clear();
                for (int i = 0; i < torsoClothes.Count; i++)
                {
                    if (!torsoSlots[i].slotIsFull)
                    {
                        torsoSlots[i].slotIsFull = true;
                        torsoSlots[i].slotItem = torsoClothes[i];
                        torsoSlots[i].SetImage(torsoClothes[i].wardrobeSprite);
                    }
                }
                break;

            case ClothType.Legs:
                legsSlots.Clear();
                for (int i = 0; i < legsClothes.Count; i++)
                {
                    if (!legsSlots[i].slotIsFull)
                    {
                        legsSlots[i].slotIsFull = true;
                        legsSlots[i].slotItem = legsClothes[i];
                        legsSlots[i].SetImage(legsClothes[i].wardrobeSprite);
                    }
                }
                break;

            case ClothType.Feet:
                feetSlots.Clear();
                for (int i = 0; i < feetClothes.Count; i++)
                {
                    if (!feetSlots[i].slotIsFull)
                    {
                        feetSlots[i].slotIsFull = true;
                        feetSlots[i].slotItem = feetClothes[i];
                        feetSlots[i].SetImage(feetClothes[i].wardrobeSprite);
                    }
                }
                break;
        }
    }
}
