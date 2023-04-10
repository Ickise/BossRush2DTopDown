using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayTheGame()
    {
        SceneManager.LoadScene("Game");
    }
     public void QuitTheGame()
    {
        Application.Quit();
    }
}
