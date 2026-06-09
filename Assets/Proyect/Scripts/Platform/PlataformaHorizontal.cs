using UnityEngine;

public class PlataformaHorizontal : MonoBehaviour
{
    public float distancia = 5f;
    public float velocidad = 2f;
    public bool empiezaDerecha = true;

    private Rigidbody rb;

    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    private Vector3 objetivo;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        posicionInicial = rb.position;

        if (empiezaDerecha)
        {
            posicionFinal = posicionInicial + Vector3.right * distancia;
        }
        else
        {
            posicionFinal = posicionInicial + Vector3.left * distancia;
        }

        objetivo = posicionFinal;
    }

    private void FixedUpdate()
    {
        Vector3 nuevaPosicion = Vector3.MoveTowards(
            rb.position,
            objetivo,
            velocidad * Time.fixedDeltaTime
        );

        rb.MovePosition(nuevaPosicion);

        if (Vector3.Distance(rb.position, objetivo) < 0.01f)
        {
            if (objetivo == posicionFinal)
            {
                objetivo = posicionInicial;
            }
            else
            {
                objetivo = posicionFinal;
            }
        }
    }
}