using UnityEngine;

public class InventorySlot
{
    public ItemData ItemData { get; private set; }
    public int Quantity { get; private set; }

    public InventorySlot(ItemData itemData, int quantity)
    {
        ItemData = itemData;
        Quantity = quantity;
    }

    public void AddQuantity(int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("Attempted to add a non-positive quantity.");
            return;
        }
        Quantity += amount;
    }
}
