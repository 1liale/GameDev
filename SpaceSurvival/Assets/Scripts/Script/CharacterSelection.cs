using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public string[] names;
    private int curSelect = 0;

    NameDisplay characterName;
    // Start is called before the first frame update
    void Start()
    {
        // characterName = new NameDisplay();
        characterName = FindObjectOfType<NameDisplay>();
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
    }
}
