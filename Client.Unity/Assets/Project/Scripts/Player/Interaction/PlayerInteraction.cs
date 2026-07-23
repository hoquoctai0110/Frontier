using Unity.Hierarchy;
using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerMovement))]
public sealed class PlayerInteraction : MonoBehaviour
{
    private PlayerInputReader inputReader;
    private PlayerMovement playerMovement;
    private IInteractable currentTarget;

    [Header("Interaction Settings")]
    [SerializeField] private Transform interactionPoint;
    [SerializeField, Min(0f)] private float interactionRadius = 0.5f;
    [SerializeField, Min(0f)] private float interactionOffset = 0.5f;
    [SerializeField] private LayerMask interactionLayer;


    //private bool isInteracting => inputReader.;
    private void Awake()
    {
        inputReader = GetComponent<PlayerInputReader>();
        playerMovement = GetComponent<PlayerMovement>();
        if(interactionPoint == null)
        {
            Debug.LogError("Interaction point is not assigned in the inspector.", this);
        }
    }

    private void OnEnable()
    {
        inputReader.InteractionPerformed += TryInteract;
    }

    private void OnDisable()
    {
        inputReader.InteractionPerformed -= TryInteract;
    }

    private void Update()
    {
        UpdateInteractionPoint();
        FindInteractionTarget();
    }

    private void UpdateInteractionPoint()
    {
        interactionPoint.localPosition = playerMovement.FacingDirection * interactionOffset;
    }

    private void FindInteractionTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            interactionPoint.position,
            interactionRadius,
            interactionLayer); 
        currentTarget = null;
        float nearestDistance = float.MaxValue;
        foreach (Collider2D hit in hits)
        {
            IInteractable interactable = hit.GetComponentInParent<IInteractable>();
            if(interactable == null)
            {
                continue;
            } 
            float distance = Vector2.Distance(interactionPoint.position, hit.ClosestPoint(interactionPoint.position));
            if(distance < nearestDistance)
            {
                nearestDistance = distance;
                currentTarget = interactable;
            }
        }
    }

    private void TryInteract() 
    { 
        if(currentTarget == null) return;
        currentTarget.Interact(this);
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(
            interactionPoint.position,
            interactionRadius
        );
    }
}
