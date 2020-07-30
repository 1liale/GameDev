using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int Character { get; set; }

    ///Return's scene to IntroScreen
    public void LoadMenu()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }
    ///Switches scene to CharacterSelection Scene
    public void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    ///Quit's game
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
