using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

///<summary>Manages Character Selection scene</summary>
public class CharacterSelection : MonoBehaviour
{
    ///Characters to be selected from
    public GameObject[] characters;
    ///Character names
    public string[] names;
    
    private static int curSelect = 0;

    private NameDisplay characterName;

    DialogueManager dialogueManager; 

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            characterName = FindObjectOfType<NameDisplay>();
            dialogueManager = FindObjectOfType<DialogueManager>();
            displayDescription();
            characterName.setName(names[curSelect]);
        }

        for(int i = 0; i < characters.Length; i++)
        {
            characters[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        characters[curSelect].GetComponent<SpriteRenderer>().enabled = true; 
    }

    ///Switches to left character
    public void switchLeft()
    {
        characters[curSelect].GetComponent<SpriteRenderer>().enabled = false;

        if(curSelect - 1 >= 0)
            curSelect -= 1;
        else
            curSelect = characters.Length - 1;
        
        characters[curSelect].GetComponent<SpriteRenderer>().enabled = true;
        characterName.setName(names[curSelect]);
        displayDescription();
    }
    ///Switches to right character
    public void switchRight()
    {
        characters[curSelect].GetComponent<SpriteRenderer>().enabled = false;

        if(curSelect + 1 == characters.Length)
            curSelect = 0;
        else
            curSelect += 1;

        characters[curSelect].GetComponent<SpriteRenderer>().enabled = true;
        characterName.setName(names[curSelect]);
        displayDescription();
    }

    private void displayDescription()
    {
        dialogueManager.LoadDialogue("CharSelection", curSelect);
        dialogueManager.SetPlay(true);
    }

    public static void checkCurScene()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log(curSelect);
        }
    }
}
