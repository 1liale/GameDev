using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public string[] names;
    private int curSelect = 0;

    //private TypeEffect display;

    private NameDisplay characterName;

    DialogueManager dialogueManager; 

    // Start is called before the first frame update
    void Start()
    {
        characterName = FindObjectOfType<NameDisplay>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        displayDescription();
        dialogueManager.setLeftSwipe();

        characterName.setName(names[curSelect]);

        for(int i = 1; i < characters.Length; i++)
        {
            characters[i].GetComponent<SpriteRenderer>().enabled = false;
        } 
    }

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
        dialogueManager.setLeftSwipe();
    }

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
        dialogueManager.setRightSwipe();
    }

    private void displayDescription()
    {
        dialogueManager.LoadDialogue("CharSelection", curSelect);
        dialogueManager.SetPlay(true);
    }
}
