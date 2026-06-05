using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    public DoorSimple[] puertas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (DoorSimple puerta in puertas)
            {
                if (puerta != null)
                {
                    puerta.Abrir();
                }
            }
        }
    }
}
