using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    ///Number of characters to display until text wraps around
    public int wrapSize;
    private Dialogue dialogue;
    private bool playDialogue;
    private Text nameDisplay;
    private TypeEffect textDisplay;

    public void SetPlay(bool playDialogue)
    {
        this.playDialogue = playDialogue;
        if (playDialogue) Display();
    }

    ///Loads a sequence of dialogue to be accessed later
    public void LoadDialogue(Dialogue dialogue)
    {
        dialogue.Reset();
        this.dialogue = dialogue;
    }

    ///Loads a sequence of dialogue from a string
    public void LoadDialogue(string txtFile, int index)
    {
        dialogue = new Dialogue();
        dialogue.Load(txtFile, index);
        dialogue.Reset();
    }

    private void checkCurScene()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Awake()
    {
        textDisplay = FindObjectOfType<TypeEffect>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (playDialogue) Display();
        }
    }
    void Display()
    {
        Tuple<string, string> line = dialogue.NextLine();
        if (line != null)
        {
            string name = line.Item1;
            string text = line.Item2;
            if (wrapSize > 0) textDisplay.beginType(text, wrapSize);
            else textDisplay.beginType(text);
        }
        else
        {
            playDialogue = false;
            checkCurScene();
        }
    }
}
