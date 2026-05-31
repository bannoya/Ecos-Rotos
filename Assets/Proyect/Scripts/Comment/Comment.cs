using UnityEngine;

public class Comment : MonoBehaviour
{
    public bool isPositive;

    public BridgeManager manager;

    [Header("Puertas / paredes")]
    public DoorSimple[] puertas;

    public void Select()
    {
        if (manager == null)
        {
            Debug.LogError("BridgeManager NO asignado");
            return;
        }

        if (isPositive)
        {
            manager.AddPositive();

            foreach (DoorSimple puerta in puertas)
            {
                if (puerta != null)
                {
                    puerta.Abrir();
                }
            }
        }

        gameObject.SetActive(false);
    }
}