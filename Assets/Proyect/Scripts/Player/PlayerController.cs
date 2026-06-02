using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float jumpForce = 7f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Salto")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Header("Inventario")]
    private Inventory inventory;
    private ItemPickup currentItem;
    [SerializeField] private GameObject inventoryPanel;

    private bool inventoryOpen;

    private Rigidbody rb;
    private Animator animator;
    private PlayerInput controls;

    private Vector2 moveInput;
    private bool isGrounded;

    private void Awake()
    {
        controls = new PlayerInput();
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
        inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        moveInput = controls.Player.Move.ReadValue<Vector2>();

        isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        // Animaciones
        animator.SetFloat("Speed", Mathf.Abs(moveInput.x));
        animator.SetBool("IsJumping", !isGrounded);

        // Girar personaje como lo tenías antes
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

        //Inventario
        if (controls.Player.interact.WasPressedThisFrame())
        {
            if (currentItem != null)
            {
                currentItem.PickUp(inventory);
                currentItem = null;
            }
        }
        if (controls.Player.Inventory.WasPressedThisFrame())
        {
            inventoryOpen = !inventoryOpen;

            inventoryPanel.SetActive(inventoryOpen);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(
            moveInput.x * speed,
            rb.linearVelocity.y,
            0f
        );

        AplicarGravedadMejorada();
    }

    private void AplicarGravedadMejorada()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.AddForce(Vector3.down * fallMultiplier, ForceMode.Acceleration);
        }

        if (rb.linearVelocity.y > 0 && !controls.Player.Jump.IsPressed())
        {
            rb.AddForce(Vector3.down * lowJumpMultiplier, ForceMode.Acceleration);
        }
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
    private void OnTriggerEnter(Collider other)
    {
        ItemPickup item = other.GetComponent<ItemPickup>();

        if (item != null)
        {
            currentItem = item;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ItemPickup item = other.GetComponent<ItemPickup>();

        if (item != null && currentItem == item)
        {
            currentItem = null;
        }
    }
}