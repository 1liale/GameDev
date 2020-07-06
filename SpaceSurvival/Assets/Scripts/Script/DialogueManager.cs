using System;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Dialogue dialogue;
    private bool playDialogue;

    private TypeEffect display;

    public void SetPlay(bool playDialogue)
    {
        this.playDialogue = playDialogue;
    }

    public void LoadDialogue(Dialogue dialogue)
    {
        this.dialogue = dialogue;
        dialogue.Reset();
    }

    public void LoadDialogue(string txtFile, int index)
    {
        dialogue = new Dialogue();
        dialogue.Load(txtFile, index);
        dialogue.Reset();
    }

    void Start()
    {
        display = FindObjectOfType<TypeEffect>();
    }

    void Update()
    {
        if (!playDialogue) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Tuple<string, string> line = dialogue.NextLine();
            if (line != null)
            {
                string name = line.Item1;
                string text = line.Item2;
                // display
                display.beginType(text);
            }
        }
    }
}
