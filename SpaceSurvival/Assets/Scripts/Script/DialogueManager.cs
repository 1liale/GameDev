using System;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Dialogue dialogue;
    private bool playDialogue;

    public void SetPlay(bool playDialogue)
    {
        this.playDialogue = playDialogue;
    }

    public void LoadDialogue(Dialogue dialogue)
    {
        this.dialogue = dialogue;
        dialogue.Reset();
    }

    void Update()
    {
        if (!playDialogue) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tuple<string, string> line = dialogue.nextLine();
            if (line != null)
            {
                string name = line.Item1;
                string text = line.Item2;
                // display

            }
        }
    }
}
