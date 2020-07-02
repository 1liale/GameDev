using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject pointer1;
    public GameObject pointer2;

    public void onHover()
    {
        pointer1.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void offHover()
    {
        pointer1.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void onClick()
    {
        pointer1.GetComponent<SpriteRenderer>().enabled = false;
        pointer2.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void swipeLeft()
    {
        
    }
    public void swipeRight()
    {
        
    }

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
