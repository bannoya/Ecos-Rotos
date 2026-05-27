using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    private Camera miCamara;

    [Header("Seguimiento del jugador")]
    public Transform player;
    public Vector3 offset = new Vector3(0, 2, -10);
    public float suavizado = 5f;

    private bool modo2D = true;

    void Start()
    {
        miCamara = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (player == null) return;

        if (modo2D)
        {
            Vector3 posicionDeseada = new Vector3(
                player.position.x + offset.x,
                player.position.y + offset.y,
                offset.z
            );

            transform.position = Vector3.Lerp(
                transform.position,
                posicionDeseada,
                suavizado * Time.deltaTime
            );
        }
        else
        {
            Vector3 posicionDeseada = player.position + offset;

            transform.position = Vector3.Lerp(
                transform.position,
                posicionDeseada,
                suavizado * Time.deltaTime
            );
        }
    }

    // Llama a esta función para activar la vista de plataformas 2D
    public void ConfigurarModo2D()
    {
        modo2D = true;

        miCamara.orthographic = true;
        miCamara.orthographicSize = 5f;

        transform.rotation = Quaternion.Euler(0, 0, 0);

        offset = new Vector3(0, 2, -10);
    }

    // Llama a esta función para activar la vista del laberinto 3D
    public void ConfigurarModo3D()
    {
        modo2D = false;

        miCamara.orthographic = false;
        miCamara.fieldOfView = 60f;

        transform.rotation = Quaternion.Euler(30, 45, 0);

        offset = new Vector3(0, 8, -10);
    }
}
