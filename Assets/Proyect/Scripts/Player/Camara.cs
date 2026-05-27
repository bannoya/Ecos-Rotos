using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    private Camera miCamara;

    void Start()
    {
        miCamara = GetComponent<Camera>();
    }

    // Llama a esta función para activar la vista de plataformas 2D
    public void ConfigurarModo2D()
    {
        miCamara.orthographic = true;
        miCamara.orthographicSize = 5f; // Ajusta el zoom a tu gusto
        // Opcional: Rotar la cámara para que mire de frente al plano 2D
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Llama a esta función para activar la vista del laberinto 3D
    public void ConfigurarModo3D()
    {
        miCamara.orthographic = false;
        miCamara.fieldOfView = 60f; // Campo de visión estándar en 3D
        // Opcional: Rotar la cámara en diagonal (estilo isométrica o tercera persona)
        transform.rotation = Quaternion.Euler(30, 45, 0);
    }
}
