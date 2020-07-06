using System;
using UnityEngine;

public class Dialogue
{
    private Tuple<string, string>[] lines;
    private int index;

    public void Reset()
    {
        index = 0;
    }
    
    public void Load(string txtFile, int index)
    {
        TextAsset txtAssets = Resources.Load(txtFile) as TextAsset;
        string[] strDialogues = txtAssets.ToString().Split('%');
        if (index < strDialogues.Length)
        {
            string strDialogue = strDialogues[index];
            string[] strLines = strDialogue.Split('\n');
            lines = new Tuple<string, string>[strLines.Length];
            for (int i = 0; i < strLines.Length; ++i)
            {
                string text = strLines[i].Contains("@") ? 
                    strLines[i].Split('@')[1] : strLines[i];
                string name = strLines[i].Contains("@") ? 
                    strLines[i].Split('@')[0] : lines[i - 1].Item1;
                lines[i] = new Tuple<string, string>(name, text);
            }

        }

    }

    public Tuple<string, string> NextLine()
    {
        if (index >= lines.Length)
            return null;
        return lines[index++];
    }

}
