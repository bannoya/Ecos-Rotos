using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float jumpForce = 7f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private Animator animator;
    private PlayerControls controls;

    private Vector2 moveInput;
    private bool isGrounded;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        Debug.Log("Animator encontrado en: " + animator.gameObject.name);
    }

    private void Update()
    {
        moveInput = controls.Player.Move.ReadValue<Vector2>();

        isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
        Debug.Log("Grounded: " + isGrounded);

        // Animaciones
        animator.SetFloat("Speed", Mathf.Abs(moveInput.x));
        animator.SetBool("IsJumping", !isGrounded);

        // Girar personaje
        if (moveInput.x > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (moveInput.x < -0.1f)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        // Salto
        if (controls.Player.Jump.WasPressedThisFrame() && isGrounded)
        {
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                0f,
                rb.linearVelocity.z
            );

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        Debug.Log("MoveInput: " + moveInput.x);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(
            moveInput.x * speed,
            rb.linearVelocity.y,
            0f
        );
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(
                groundCheck.position,
                groundCheckRadius
            );
        }
    }
}