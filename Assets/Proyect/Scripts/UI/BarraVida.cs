using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class BarraVida : MonoBehaviour
{
    public Image rellenoBarraVida;
    private PlayerHealth playerHealth;
  
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

  
    void Update()
    {
     rellenoBarraVida.fillAmount = (float)playerHealth.vidaActual/playerHealth.vidaMaxima;
    }
}
