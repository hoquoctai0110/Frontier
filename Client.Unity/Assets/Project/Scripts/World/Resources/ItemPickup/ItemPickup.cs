using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    [SerializeField, Min(1)]private int amount = 1;
    public int Amount => amount;
    public ItemData ItemData => itemData;
}
