using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    public float distancia = 3f;
    public float velocidad = 2f;

    [Header("Dirección inicial")]
    public bool empiezaSubiendo = true;

    private Vector3 posicionInicial;
    private Vector3 posicionFinal;

    void Start()
    {
        posicionInicial = transform.position;

        if (empiezaSubiendo)
        {
            posicionFinal = posicionInicial + Vector3.up * distancia;
        }
        else
        {
            posicionFinal = posicionInicial + Vector3.down * distancia;
        }
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * velocidad, 1f);

        transform.position = Vector3.Lerp(posicionInicial, posicionFinal, t);
    }
}