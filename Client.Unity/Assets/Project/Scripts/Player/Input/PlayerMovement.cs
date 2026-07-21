using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    Rigidbody2D body;
    PlayerInputReader inputReader;

    public Vector2 MoveInput { get; private set; }
    public Vector2 Velocity { get; private set; }
    public bool IsMoving => MoveInput.sqrMagnitude > 0.01f;
    public Vector2 FacingDirection { get; private set; } = Vector2.down;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        inputReader = GetComponent<PlayerInputReader>();
    }

    private void ReadInput()
    {
        MoveInput = inputReader.MoveInput;
        if(MoveInput.sqrMagnitude > 1)
        {
            MoveInput.Normalize();
        }
        Velocity = MoveInput * moveSpeed;
    }

    private Vector2 ToCardinalDirection(Vector2 input)
    {
        if(Mathf.Abs(input.x) >= Mathf.Abs(input.y))
        {
            return input.x >= 0 ? Vector2.right : Vector2.left;
        }
        else 
        {
            return input.y >= 0 ? Vector2.up : Vector2.down;
        }
    }

    private void Move()
    {
        Vector2 newPosition = body.position + Velocity * Time.fixedDeltaTime;
        body.MovePosition(newPosition);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        UpdateFacingDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void UpdateFacingDirection()
    {
        if(!IsMoving)
        {
            return;    
        }
        FacingDirection = ToCardinalDirection(MoveInput);
    }
}
