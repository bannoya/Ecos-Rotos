using UnityEngine;

public class WallGrab : MonoBehaviour
{
    [Header("Referencias")]
    public Transform wallCheck;
    public LayerMask wallLayer;

    [Header("Detección de pared")]
    public float wallCheckRadius = 0.3f;

    [Header("Agarre")]
    public float slideSpeed = 1f;

    [Header("Trepar pared")]
    public float wallClimbSpeed = 8f;
    public float climbTime = 0.18f;
    public float climbCooldown = 0.08f;

    private Rigidbody rb;
    private PlayerController player;

    private bool isTouchingWall;
    private bool isGrabbing;

    private float climbTimer;
    private float climbCooldownCounter;

    public bool IsGrabbing => isGrabbing;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (climbTimer > 0)
        {
            climbTimer -= Time.deltaTime;
        }

        if (climbCooldownCounter > 0)
        {
            climbCooldownCounter -= Time.deltaTime;
        }

        DetectWall();
        HandleWallGrab();
        HandleWallClimb();
    }

    private void DetectWall()
    {
        isTouchingWall = Physics.CheckSphere(
            wallCheck.position,
            wallCheckRadius,
            wallLayer
        );
    }

    private void HandleWallGrab()
    {
        if (player == null)
        {
            return;
        }

        bool isInAir = !player.IsGrounded;

        if (isInAir && isTouchingWall)
        {
            StartGrab();
        }
        else
        {
            StopGrab();
        }
    }

    private void HandleWallClimb()
    {
        if (!isGrabbing)
        {
            return;
        }

        if (climbCooldownCounter > 0)
        {
            return;
        }

        if (!player.JumpPressed)
        {
            return;
        }

        climbTimer = climbTime;
        climbCooldownCounter = climbCooldown;
    }

    private void FixedUpdate()
    {
        if (!isGrabbing)
        {
            return;
        }

        rb.useGravity = false;

        if (climbTimer > 0)
        {
            rb.linearVelocity = new Vector3(
                0f,
                wallClimbSpeed,
                0f
            );
        }
        else
        {
            rb.linearVelocity = new Vector3(
                0f,
                -slideSpeed,
                0f
            );
        }
    }

    private void StartGrab()
    {
        isGrabbing = true;
        rb.useGravity = false;
    }

    private void StopGrab()
    {
        if (!isGrabbing)
        {
            return;
        }

        isGrabbing = false;
        climbTimer = 0f;
        rb.useGravity = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (wallCheck != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(wallCheck.position, wallCheckRadius);
        }
    }
}