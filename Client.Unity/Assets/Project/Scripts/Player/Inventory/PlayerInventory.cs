using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int WoodAmount { get; private set; }

    public void AddWood(int amount)
    {
        if(amount <= 0)
        {
            Debug.LogWarning("Attempted to add a non-positive amount of wood.");
            return;
        }
        WoodAmount += amount;
        Debug.Log($"Added {amount} wood. Total wood: {WoodAmount}");
    }
}
