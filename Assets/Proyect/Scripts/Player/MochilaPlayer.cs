using UnityEngine;

public class MochilaPersonaje : MonoBehaviour
{
    [Header("Configuración de la Mochila")]
    public int cantidadActual = 0;
    public int capacidadMaxima = 5; // El límite de espacio de la mochila

    // Verifica si la mochila tiene espacio para guardar más
    public bool TieneEspacio()
    {
        return cantidadActual < capacidadMaxima;
    }

    // Añade recursos a la mochila
    public void GuardarRecurso(int cantidad)
    {
        cantidadActual += cantidad;
        if (cantidadActual > capacidadMaxima)
        {
            cantidadActual = capacidadMaxima;
        }
        Debug.Log($"Mochila: {cantidadActual}/{capacidadMaxima}");
    }
}

