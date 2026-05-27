using UnityEngine;

public class RecursoMundo : MonoBehaviour
{
    // Solo los 2 estados que realmente necesitas
    public enum EstadoRecurso { Tomado, NoTomado }

    [Header("Estado Actual")]
    public EstadoRecurso estadoActual = EstadoRecurso.NoTomado;

    [Header("Componentes Visuales 3D")]
    private MeshRenderer miRender; // Renderizador para objetos 3D
    private Collider miCollider;   // Colisionador 3D

    void Start()
    {
        // Obtenemos automáticamente los componentes 3D del objeto
        miRender = GetComponent<MeshRenderer>();
        miCollider = GetComponent<Collider>();
    }

    public void IntentarTomar(MochilaPersonaje mochila)
    {
        // Regla: Si el objeto está en el suelo (NoTomado) y la mochila tiene espacio
        if (estadoActual == EstadoRecurso.NoTomado && mochila.TieneEspacio())
        {
            // Transición de estado
            estadoActual = EstadoRecurso.Tomado;

            // Añade el objeto a la mochila del personaje
            mochila.GuardarRecurso(1);

            // Desaparece del suelo inmediatamente
            AlternarVisibilidad(false);
        }
        else
        {
            Debug.Log("No se puede tomar: El objeto ya fue tomado o la mochila está llena.");
        }
    }

    // Apaga el modelo 3D y su colisionador para que parezca que desapareció
    private void AlternarVisibilidad(bool visible)
    {
        if (miRender != null) miRender.enabled = visible;
        if (miCollider != null) miCollider.enabled = visible;
    }

    // Método opcional: Llama a esto si quieres que el recurso vuelva a aparecer en el suelo
    public void SoltarRecurso()
    {
        estadoActual = EstadoRecurso.NoTomado;
        AlternarVisibilidad(true);
    }
}
