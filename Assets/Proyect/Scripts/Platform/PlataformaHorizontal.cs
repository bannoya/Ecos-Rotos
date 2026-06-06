using UnityEngine;

public class PlataformaHorizontal : MonoBehaviour
{
    public float distancia = 5f;
    public float velocidad = 2f;

    public bool empiezaDerecha = true;

    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    private Vector3 objetivo;

    void Start()
    {
        posicionInicial = transform.position;

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

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            objetivo,
            velocidad * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, objetivo) < 0.01f)
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