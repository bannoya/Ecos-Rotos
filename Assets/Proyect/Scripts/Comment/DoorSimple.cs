using UnityEngine;

public class DoorSimple : MonoBehaviour
{
    [Header("Movimiento")]
    public float distanciaMovimiento = 4f;
    public float velocidad = 2f;

    [Header("Dirección")]
    public DireccionPuerta direccion = DireccionPuerta.Arriba;

    private Vector3 posicionCerrada;
    private Vector3 posicionAbierta;

    private bool abrir = false;
    private bool cerrar = false;

    public enum DireccionPuerta
    {
        Arriba,
        Abajo,
        Derecha,
        Izquierda,
        Adelante,
        Atras
    }

    void Start()
    {
        posicionCerrada = transform.position;
        posicionAbierta = posicionCerrada + ObtenerDireccion() * distanciaMovimiento;
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

    private Vector3 ObtenerDireccion()
    {
        switch (direccion)
        {
            case DireccionPuerta.Arriba:
                return Vector3.up;

            case DireccionPuerta.Abajo:
                return Vector3.down;

            case DireccionPuerta.Derecha:
                return Vector3.right;

            case DireccionPuerta.Izquierda:
                return Vector3.left;

            case DireccionPuerta.Adelante:
                return Vector3.forward;

            case DireccionPuerta.Atras:
                return Vector3.back;

            default:
                return Vector3.up;
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