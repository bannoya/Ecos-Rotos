using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    [Header("Ascensor")]
    [SerializeField] private Transform plataforma;
    [SerializeField] private float distanciaBajada = 5f;
    [SerializeField] private float velocidad = 2f;

    [Header("Jugador")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Rigidbody playerRb;

    [Header("Animación")]
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private string parametroMovimiento = "Speed";

    private Vector3 posicionInicial;
    private Vector3 posicionFinal;

    private bool autorizadoPorBoton = false;
    private bool bajando = false;
    private bool activado = false;

    private void Start()
    {
        if (plataforma != null)
        {
            posicionInicial = plataforma.position;
            posicionFinal = posicionInicial + Vector3.down * distanciaBajada;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!autorizadoPorBoton) return;
        if (activado) return;

        if (other.CompareTag("Player"))
        {
            activado = true;
            bajando = true;

            if (playerRb != null)
            {
                playerRb.linearVelocity = Vector3.zero;
                playerRb.angularVelocity = Vector3.zero;
            }

            if (playerAnimator != null)
            {
                playerAnimator.SetFloat(parametroMovimiento, 0f);
            }

            if (playerController != null)
            {
                playerController.enabled = false;
            }

            Debug.Log("Ascensor bajando.");
        }
    }

    private void Update()
    {
        if (!bajando || plataforma == null) return;

        plataforma.position = Vector3.MoveTowards(
            plataforma.position,
            posicionFinal,
            velocidad * Time.deltaTime
        );

        if (plataforma.position == posicionFinal)
        {
            bajando = false;

            if (playerRb != null)
            {
                playerRb.linearVelocity = Vector3.zero;
                playerRb.angularVelocity = Vector3.zero;
            }

            if (playerController != null)
            {
                playerController.enabled = true;
            }

            Debug.Log("Ascensor llegó al final.");
        }
    }

    public void AutorizarAscensor()
    {
        autorizadoPorBoton = true;
        Debug.Log("Ascensor autorizado por botón.");
    }
}