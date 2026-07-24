using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;

    private void Awake()
    {
        playerInventory = GetComponent<PlayerInventory>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemPickup itemPickup = collision.GetComponent<ItemPickup>();
        if (itemPickup == null) return;
        Collect(itemPickup);
    }

    private void Collect(ItemPickup itemPickup)
    {
        playerInventory.AddItem(itemPickup.ItemData, itemPickup.Amount);
        Destroy(itemPickup.gameObject);
    }
}
