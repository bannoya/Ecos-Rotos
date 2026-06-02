using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject SelectorMenu;
    public GameObject MainMenu;

    public void OpenSelectorMenu()
    {
        MainMenu.SetActive(false);
        SelectorMenu.SetActive(true);
    }

    public void OpenMainMenu()
    {
        SelectorMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void CloseGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("level 1");
    }

    public void PlayNivel1()
    {
        SceneManager.LoadScene("level 1");
    }

    public void PlayNivel2()
    {
        //SceneManager.LoadScene("level 2");
    }

    public void PlayNivel3()
    {
       // SceneManager.LoadScene("level 3");
    }

    public void PlayNivel4()
    {
        //SceneManager.LoadScene("level 4");
    }

}
