using System;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private Tuple<string, string>[] lines;
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
        if (index >= lines.Length)
            return null;
        return lines[++index];
    }

}
