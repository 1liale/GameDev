﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>Stores functions for Buttons</summary>
public class ButtonHandler : MonoBehaviour
{
    ///GameObject of Arrow that appeares before onHover
    public GameObject pointer1;
    ///GameObject of Arrow that appears when clicked
    public GameObject pointer2;

    ///Displays onHover arrow
    public void onHover()
    {
        pointer1.GetComponent<SpriteRenderer>().enabled = true;
    }
    ///Displays default arrow
    public void offHover()
    {
        pointer1.GetComponent<SpriteRenderer>().enabled = false;
    }
    ///Displays onClicked arrow
    public void onClick()
    {
        pointer1.GetComponent<SpriteRenderer>().enabled = false;
        pointer2.GetComponent<SpriteRenderer>().enabled = true;
    }
    ///Return's scene to IntroScreen
    public void returnMenu()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }
    ///Switches scene to CharacterSelection Scene
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    ///Quit's game
    public void quitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
