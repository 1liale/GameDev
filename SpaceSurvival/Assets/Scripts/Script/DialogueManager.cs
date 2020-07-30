using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Dialogue dialogue;
    private bool playDialogue;
    private Text nameDisplay;
    private TypeEffect textDisplay;

    public void SetPlay(bool playDialogue)
    {
        this.playDialogue = playDialogue;
        if (playDialogue) Display();
    }

    public void LoadDialogue(Dialogue dialogue)
    {
        dialogue.Reset();
        this.dialogue = dialogue;
    }

    public void LoadDialogue(string txtFile, int index)
    {
        dialogue = new Dialogue();
        dialogue.Load(txtFile, index);
        dialogue.Reset();
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

            textDisplay.beginType(text);
        }
        else
        {
            playDialogue = false;
        }
    }
}
