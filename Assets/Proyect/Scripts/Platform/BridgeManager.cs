using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    public GameObject bridge;

    int positives = 0;

    public int needed = 3;

    void Start()
    {
        bridge.SetActive(false);
    }

    public void AddPositive()
    {
        positives++;

        if (positives >= needed)
        {
            bridge.SetActive(true);

            Debug.Log("PUENTE ACTIVADO");
        }
    }
}