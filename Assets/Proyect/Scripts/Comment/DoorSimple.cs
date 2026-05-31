using UnityEngine;

public class DoorSimple : MonoBehaviour
{
    public float alturaSubida = 4f;
    public float velocidad = 2f;

    private Vector3 posicionCerrada;
    private Vector3 posicionAbierta;

    private bool abrir = false;
    private bool cerrar = false;

    void Start()
    {
        posicionCerrada = transform.position;
        posicionAbierta = posicionCerrada + Vector3.up * alturaSubida;
    }

    void Update()
    {
        if (abrir)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                posicionAbierta,
                velocidad * Time.deltaTime
            );

            if (transform.position == posicionAbierta)
            {
                abrir = false;
            }
        }

        if (cerrar)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                posicionCerrada,
                velocidad * Time.deltaTime
            );

            if (transform.position == posicionCerrada)
            {
                cerrar = false;
            }
        }
    }

    public void Abrir()
    {
        abrir = true;
        cerrar = false;
    }

    public void Cerrar()
    {
        cerrar = true;
        abrir = false;
    }
}