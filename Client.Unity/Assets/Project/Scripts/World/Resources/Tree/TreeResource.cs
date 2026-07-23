using UnityEngine;

public class TreeResource : MonoBehaviour, IInteractable
{
    [SerializeField, Min(1)] private int maxHealth = 3;
    [SerializeField] private TreeAnimator treeAnimator;
    [SerializeField] private Collider2D treeCollider;
    private int currentHealth;
    private bool isDead;

    [Header("Drop Settings")]
    [SerializeField] private WoodPickup woodPickupPrefab;
    [SerializeField, Min(1)] private int woodDropAmount = 3;
    [SerializeField] private Transform dropPoint;
    [SerializeField, Min(0f)] private float dropRadius = 0.5f;


    private void Awake()
    {
        currentHealth = maxHealth;
        treeAnimator = GetComponentInChildren<TreeAnimator>();
    }

    private void OnEnable()
    {
        treeAnimator.DeathAnimationFinished += HandleDeathAnimationFinished;
    }

    private void OnDisable()
    {
        treeAnimator.DeathAnimationFinished -= HandleDeathAnimationFinished;
    }
    public void Interact(PlayerInteraction interactor)
    {
        if (isDead) return;
        TakeHit(1);
    }

    private void TakeHit(int damage)
    {
        if(damage <= 0) return;
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        Debug.Log($"Tree HP: {currentHealth}/{maxHealth}");
        if (currentHealth <= 0)
        {
            Die();
            return;
        }
        treeAnimator.PlayHit();
    }

    private void Die()
    {
        isDead = true;
        treeCollider.enabled = false;
        treeAnimator.PlayDeath();
    }

    private void HandleDeathAnimationFinished()
    {
        DropWood();
        Destroy(gameObject);
    }

    private void DropWood()
    {
        if (woodPickupPrefab == null || dropPoint == null) return;
        for (int i = 0; i < woodDropAmount; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle * dropRadius;
            Vector2 dropPosition = (Vector2)dropPoint.position + randomOffset;
            Instantiate(woodPickupPrefab, dropPosition, Quaternion.identity);
        }
    }
}
