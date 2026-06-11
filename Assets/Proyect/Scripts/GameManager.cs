using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverCanvas;
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public GameObject BarraVida;
    public GameObject ImagenGameOver;

    public void MostrarGameOver()
    {
        Time.timeScale = 0;
        GameOverCanvas.SetActive(true);
        PauseButton.SetActive(false);
        BarraVida.SetActive(false);
        ImagenGameOver.SetActive(true);
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
