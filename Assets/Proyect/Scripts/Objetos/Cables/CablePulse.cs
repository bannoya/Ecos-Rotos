using UnityEngine;

public class CablePulse : MonoBehaviour
{
    public Color emissionColor = Color.cyan;
    public float pulseSpeed = 2f;
    public float minIntensity = 1f;
    public float maxIntensity = 3f;

    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

        // Asegura que la emisión esté activa
        mat.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * pulseSpeed, 1f);

        float intensity = Mathf.Lerp(minIntensity, maxIntensity, t);

        mat.SetColor("_EmissionColor", emissionColor * intensity);
    }
}