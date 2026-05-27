using UnityEngine;

public class EmotionalBridge : MonoBehaviour
{
    public GameObject bridge;

    public void ActivateBridge()
    {
        bridge.SetActive(true);
    }
}