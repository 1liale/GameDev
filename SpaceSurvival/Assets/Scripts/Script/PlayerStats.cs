using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerStats : MonoBehaviour
{

    string path = "Assets/Script/GameData.txt";

    static void WriteString()
    {
        // Write data to GameStats.txt file
        string path = "Assets/Script/GameData.txt";

        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Test");
        writer.Close();
    }

    static void ReadString()
    {
        string path = "Assets/Script/GameData.txt";

        //Read the text from GameStats.txt file
        StreamReader reader = new StreamReader(path); 
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

}
