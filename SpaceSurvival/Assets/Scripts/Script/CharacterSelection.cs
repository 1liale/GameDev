﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>Manages Character Selection scene</summary>
public class CharacterSelection : MonoBehaviour
{
    ///Characters to be selected from
    public GameObject[] characters;
    ///Character names
    public string[] names;
    private int curSelect = 0;

    private NameDisplay characterName;

    DialogueManager dialogueManager; 

    // Start is called before the first frame update
    void Start()
    {
        characterName = FindObjectOfType<NameDisplay>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        displayDescription();

        characterName.setName(names[curSelect]);

        for(int i = 1; i < characters.Length; i++)
        {
            characters[i].GetComponent<SpriteRenderer>().enabled = false;
        } 
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

        GameManager.Character = curSelect;
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

        GameManager.Character = curSelect;
    }

    private void displayDescription()
    {
        dialogueManager.LoadDialogue("CharSelection", curSelect);
        dialogueManager.SetPlay(true);
    }
}
