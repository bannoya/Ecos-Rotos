using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    [SerializeField] private ElevatorTrigger elevatorTrigger;

    private bool used;

    private void OnTriggerEnter(Collider other)
    {
        if (used) return;

        if (other.CompareTag("Player"))
        {
            used = true;

            if (elevatorTrigger != null)
            {
                elevatorTrigger.AutorizarAscensor();
            }

            Debug.Log("Botón activado.");
        }
    }
}