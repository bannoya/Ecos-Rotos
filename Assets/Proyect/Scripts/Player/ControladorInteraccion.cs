using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorInteraccion : MonoBehaviour
{
    private MochilaPersonaje miMochila;
    private RecursoMundo recursoCercano;

    void Start()
    {
        miMochila = GetComponent<MochilaPersonaje>();
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            IntentarRecolectar();
        }
    }

    private void IntentarRecolectar()
    {
        if (recursoCercano != null)
        {
            recursoCercano.IntentarTomar(miMochila);
        }
        else
        {
            Debug.Log("No hay ningún recurso cerca para recolectar.");
        }
    }

    // ==========================================
    // CAMBIA ESTAS FUNCIONES EN TU SCRIPT:
    // ==========================================

    private void OnTriggerEnter(Collider collision) // <--- Cambiado a 3D (Sin el 2D)
    {
        if (collision.CompareTag("Recurso"))
        {
            recursoCercano = collision.GetComponent<RecursoMundo>();
            Debug.Log("¡Recurso 3D detectado! Presiona E.");
        }
    }

    private void OnTriggerExit(Collider collision) // <--- Cambiado a 3D (Sin el 2D)
    {
        if (collision.CompareTag("Recurso"))
        {
            recursoCercano = null;
            Debug.Log("Te has alejado del recurso.");
        }
    }
}
