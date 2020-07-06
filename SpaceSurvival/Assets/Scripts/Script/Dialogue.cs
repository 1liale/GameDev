using System;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    private List<Tuple<string, string>> lines;
    private int index;

    public void Reset()
    {
        index = 0;
    }
    
    public void Load()
    {
        
    }

    public Tuple<string, string> nextLine()
    {
        if (index >= lines.Count)
            return null;
        return lines[++index];
    }

}
