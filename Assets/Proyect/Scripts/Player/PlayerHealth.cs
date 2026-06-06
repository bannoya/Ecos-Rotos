using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual;

    public enum EstadoJugador
    {
        Motivado,
        Neutral,
        Ansioso,
        Muerto
    }

    public EstadoJugador estadoActual;

    void Start()
    {
        vidaActual = vidaMaxima/2;
        ActualizarEstado();
    }

    public void TakeDamage(int damage)
    {
        vidaActual -= damage;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        ActualizarEstado();
    }

    public void Curar(int cantidad)
    {
        vidaActual += cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        ActualizarEstado();
    }

    void ActualizarEstado()
    {
        float porcentaje = (float)vidaActual / vidaMaxima;

        if (vidaActual <= 0)
        {
            estadoActual = EstadoJugador.Muerto;
        }
        else if (porcentaje <= 0.25f)
        {
            estadoActual = EstadoJugador.Ansioso;
        }
        else if (porcentaje <= 0.50f)
        {
            estadoActual = EstadoJugador.Neutral;
        }
        else
        {
            estadoActual = EstadoJugador.Motivado;
        }

        Debug.Log($"Vida: {vidaActual} - Estado: {estadoActual}");
    }
}