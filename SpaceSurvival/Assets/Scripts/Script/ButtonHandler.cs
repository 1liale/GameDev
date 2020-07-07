using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>Class <c>ButtonHandler</c> contains functions giving buttons their functionality.</summary>
public class ButtonHandler : MonoBehaviour
{
    ///Object containing sprite to appear on hover
    public GameObject pointer1;
    ///Object containing sprite to appear on click
    public GameObject pointer2;
    ///Behavior for pointer hover over button 
    public void onHover()
    {
        pointer1.GetComponent<SpriteRenderer>().enabled = true;
    }

    ///Behavior for pointer move away from button 
    public void offHover()
    {
        pointer1.GetComponent<SpriteRenderer>().enabled = false;
    }
    ///Behavior 
    public void onSwipe()
    {
        pointer1.GetComponent<SpriteRenderer>().enabled = false;
        pointer2.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void offSwipe()
    {
        pointer1.GetComponent<SpriteRenderer>().enabled = true;
        pointer2.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void onClick()
    {
        pointer1.GetComponent<SpriteRenderer>().enabled = false;
        pointer2.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void returnMenu()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
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
