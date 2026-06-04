using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class BarraVida : MonoBehaviour
{
    public Image rellenoBarraVida;
    private PlayerController PlayerController;
    private float VidaMaxima;
    void Start()
    {
        PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
        VidaMaxima = 10; // habria que añadir realmente en PlayerController un item de vida, igual
                         // Segun nuestra idea arranca el PJ con la mitad de la vida

    }

  
    void Update()
    {
      //  rellenoBarraVida.fillAmount = PlayerController.vida/VidaMaxima;
    }
}
