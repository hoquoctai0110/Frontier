using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;

    private float MoveX => playerMovement.FacingDirection.x;
    private float MoveY => playerMovement.FacingDirection.y;
    private bool IsMoving => playerMovement.IsMoving;

    private static readonly int MoveXHash = Animator.StringToHash("MoveX");
    private static readonly int MoveYHash = Animator.StringToHash("MoveY");
    private static readonly int IsMovingHash = Animator.StringToHash("IsMoving");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void UpdateAnimation()
    {
        Debug.Log(
        $"MoveX: {MoveX}, MoveY: {MoveY}, IsMoving: {IsMoving}"
    );
        animator.SetFloat(MoveXHash, MoveX);
        animator.SetFloat(MoveYHash, MoveY);
        animator.SetBool(IsMovingHash, IsMoving);
    }
    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
    }
}
