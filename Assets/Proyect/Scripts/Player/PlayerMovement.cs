using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private PlayerControls controls;

    private Vector2 moveInput;
    private float airMove;
    private bool isGrounded = true;

    void Awake()
    {
        controls = new PlayerControls();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInput = controls.Player.Move.ReadValue<Vector2>();

        // Guardar dirección al saltar
        if (controls.Player.Jump.triggered && isGrounded)
        {
            airMove = moveInput.x;

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        float move;

        if (isGrounded)
        {
            // En suelo usa input normal
            move = moveInput.x;
        }
        else
        {
            // En aire mantiene dirección
            move = airMove;
        }

        rb.linearVelocity = new Vector3(
            move * speed,
            rb.linearVelocity.y,
            0f
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}