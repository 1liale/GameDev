using System;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Dialogue dialogue;
    private bool playDialogue;

    private string txtFile = "CharSelection";
    string txtContent;

    private string[] sections;

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

    public string[] getDescription(int option)
    {
        string[] curLines = sections[option].Split('\n');
        Debug.Log("split worked");
        return curLines;
    }

    // Reads from CharSelect.txt 
    private void loadSelectDialogue()
    {
        TextAsset txtAssets = Resources.Load(txtFile) as TextAsset;  
        txtContent = txtAssets.ToString();
        sections = txtContent.Split('%');
        Debug.Log(sections[0]);
    }
}
