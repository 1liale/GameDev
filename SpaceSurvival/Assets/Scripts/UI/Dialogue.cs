using System;
using UnityEngine;

///<summary>Contains one sequence of game dialogue, loaded from a .txt file</summary><see href="">Dialogue Formatting Guide</see>
public class Dialogue
{
    private Tuple<string, string>[] lines;
    private int index;

    ///reset's dialogue line to beginning of dialogue sequence
    public void Reset()
    {
        index = 0;
    }
    
    ///Separates a .txt file into the individual bits of dialogue
    public void Load(string txtFile, int index)
    {
        TextAsset txtAssets = Resources.Load(txtFile) as TextAsset;
        string[] strDialogues = txtAssets.ToString().Split('%');
        if (index < strDialogues.Length)
        {
            string strDialogue = strDialogues[index];
            string[] strLines = strDialogue.Split('\n');
            lines = new Tuple<string, string>[strLines.Length];
            for (int i = 0; i < strLines.Length; ++i) //for each dialogue, 
            {
                string text = strLines[i].Contains("@") ? 
                    strLines[i].Split('@')[1] : strLines[i];
                //if character name exists, update it. Else, keep previous name
                string name = strLines[i].Contains("@") ? 
                    strLines[i].Split('@')[0] : lines[i - 1].Item1;
                lines[i] = new Tuple<string, string>(name, text);
            }
        }
    }

    ///<returns>The current dialogue being spoken, where <code>Tuple.Item1</code> = Name and <code>Tuple.Item2</code> = Dialogue</return>
    public Tuple<string, string> NextLine()
    {
        if (index >= lines.Length - 1)
            return null;
        return lines[index++];
    }

}
