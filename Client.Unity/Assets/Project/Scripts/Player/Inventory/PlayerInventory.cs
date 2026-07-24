using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public event Action OnItemAmountChanged;

    private int woodAmount;
    public int WoodAmount => woodAmount;

    private List<InventorySlot> inventorySlots = new();

    public void AddItem(ItemData itemData, int quantity)
    {
        if (itemData == null)
        {
            Debug.LogWarning("Attempted to add a null item.");
            return;
        }
        if (quantity <= 0)
        {
            Debug.LogWarning("Attempted to add a non-positive quantity of items.");
            return;
        }
        if(inventorySlots.Count == 0)
        {
            inventorySlots.Add(new InventorySlot(itemData, quantity));
            RefreshInventory();
            return;
        }
        for (int i = 0; i< inventorySlots.Count; i++)
        {
            if(inventorySlots[i] == null)
            {
                inventorySlots[i] = new InventorySlot(itemData, quantity);
                RefreshInventory();;
                return;
            }
            if (inventorySlots[i].ItemData != itemData)
            {
                if(i == inventorySlots.Count - 1)
                {
                    inventorySlots.Add(new InventorySlot(itemData, quantity));
                    RefreshInventory();
                    return;
                }
                continue;
            }
            if(inventorySlots[i].Quantity + quantity > itemData.MaxStackSize)
            {
                inventorySlots[i].AddQuantity(itemData.MaxStackSize - inventorySlots[i].Quantity);
                int remainQuantity = itemData.MaxStackSize - inventorySlots[i].Quantity;
                inventorySlots.AddRange(new InventorySlot[] { new InventorySlot(itemData, remainQuantity) });
            } else
            {
                inventorySlots[i].AddQuantity(quantity);
            }
            RefreshInventory();
            return;
        }
    }

    private void RefreshInventory()
    {
        CalculateItemQuantity();
        Debug.Log($"Inventory refreshed. Current wood amount: {woodAmount}");
        OnItemAmountChanged?.Invoke();
    }

    private void CalculateItemQuantity()
    {
        woodAmount = 0;
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.ItemData == null)
            {
                continue;
            }
            switch(MatchItemType(slot))
            {
                case 1:
                    woodAmount += slot.Quantity;
                    break;
                default:
                    break;
            }
        }
    }

    private int MatchItemType(InventorySlot slot)
    {
        string itemName = slot.ItemData.ItemName;
        if (itemName.Equals(ItemType.Wood.ToString()))
        {
            return 1;
        }
        return 0;
    }
}

public enum ItemType
{
    Wood,
    Stone,
    Iron,
    Gold
}
