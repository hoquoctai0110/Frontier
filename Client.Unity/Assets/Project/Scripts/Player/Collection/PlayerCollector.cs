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
        WoodPickup woodPickup = collision.GetComponent<WoodPickup>();
        if (woodPickup == null) return;
        CollectWood(woodPickup);
    }

    private void CollectWood(WoodPickup woodPickup)
    {
        playerInventory.AddWood(woodPickup.WoodAmount);
        Destroy(woodPickup.gameObject);
    }
}
