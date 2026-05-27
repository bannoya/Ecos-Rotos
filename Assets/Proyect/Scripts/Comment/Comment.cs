using UnityEngine;

public class Comment : MonoBehaviour
{
    public bool isPositive;

    public BridgeManager manager;

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
        }

        gameObject.SetActive(false);
    }
}