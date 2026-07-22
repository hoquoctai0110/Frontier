using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    private PlayerControls playerControls;

    public Vector2 MoveInput { get; private set; }
    public bool InteractPressed { get; private set; }

    public event Action InteractionPerformed;
    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Gameplay.Move.performed += OnMove;
        playerControls.Gameplay.Move.canceled += OnMove;
        playerControls.Gameplay.Interaction.performed += OnInteract;
        playerControls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        playerControls.Gameplay.Move.performed -= OnMove;
        playerControls.Gameplay.Move.canceled -= OnMove;    
        playerControls.Gameplay.Interaction.performed -= OnInteract;
        playerControls.Gameplay.Disable();
        MoveInput = Vector2.zero;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        InteractionPerformed?.Invoke();
    }
}
