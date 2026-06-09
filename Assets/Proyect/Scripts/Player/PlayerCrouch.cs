using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    [Header("Referencias")]
    public PlayerController playerController;
    public CapsuleCollider playerCollider;
    public Animator animator;

    [Header("Agacharse")]
    [Range(0.2f, 1f)]
    public float porcentajeAlturaAgachado = 0.5f;

    public float velocidadAgachado = 2.5f;

    [Header("Chequeo de techo")]
    public Transform ceilingCheck;
    public float ceilingCheckRadius = 0.3f;
    public LayerMask ceilingLayer;

    private PlayerInput controls;

    private bool isCrouching;

    private float alturaNormal;
    private float alturaAgachado;

    private Vector3 centroNormal;
    private Vector3 centroAgachado;

    private float velocidadNormal;

    private void Awake()
    {
        controls = new PlayerInput();
    }

    private void Start()
    {
        alturaNormal = playerCollider.height;
        centroNormal = playerCollider.center;

        velocidadNormal = playerController.speed;

        alturaAgachado = alturaNormal * porcentajeAlturaAgachado;

        float diferenciaAltura = alturaNormal - alturaAgachado;

        centroAgachado = centroNormal;
        centroAgachado.y -= diferenciaAltura / 2f;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        if (controls.Player.Crouch.IsPressed())
        {
            Agacharse();
        }
        else
        {
            if (!HayTechoArriba())
            {
                Levantarse();
            }
        }
        if (controls.Player.Crouch.IsPressed())
        {
            Agacharse();
        }
    }

    private void Agacharse()
    {

        if (isCrouching) return;

        isCrouching = true;


        playerCollider.height = alturaAgachado;
        playerCollider.center = centroAgachado;

        playerController.speed = velocidadAgachado;

        if (animator != null)
        {
            animator.SetBool("IsCrouching", true);
        }
    }

    private void Levantarse()
    {
        if (!isCrouching) return;

        isCrouching = false;

        playerCollider.height = alturaNormal;
        playerCollider.center = centroNormal;

        playerController.speed = velocidadNormal;

        if (animator != null)
        {
            animator.SetBool("IsCrouching", false);
        }
    }

    private bool HayTechoArriba()
    {
        return Physics.CheckSphere(
            ceilingCheck.position,
            ceilingCheckRadius,
            ceilingLayer
        );
    }

    private void OnDrawGizmosSelected()
    {
        if (ceilingCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(ceilingCheck.position, ceilingCheckRadius);
        }
    }
}