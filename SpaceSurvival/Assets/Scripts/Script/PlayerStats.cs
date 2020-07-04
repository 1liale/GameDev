using System.IO;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public enum Level { Base, First, Second, Third };

    public float Food { get; private set; }
    public float Energy { get; private set; }
    public float Vitality { get; private set; }

    public float Trust { get; private set; }
    public float Morality { get; private set; }

    public Level LvlHealthSci { get; private set; }
    public Level LvlEngineer { get; private set; }
    public Level LvlComputerSci { get; private set; }
    public Level LvlNews { get; private set; }

    public Level LvlStrength { get; private set; }
    public Level LvlEndurance { get; private set; }

    public StatBar foodBar;
    public StatBar energyBar;
    public StatBar vitalityBar;

    private float rtFoodDec;
    private float rtEnergyDec;
    private float rtVitalityInc;
    private float rtVitalityDec;

    void Start()
    {
        Food = 1f;
        Energy = 1f;
        Vitality = 1f;
    }

    void Update()
    {
        Food -= rtFoodDec * Time.deltaTime;
        Food = Mathf.Clamp(Food, 0f, 1f);

        Energy -= rtEnergyDec * Time.deltaTime / 
            Mathf.Max(Mathf.Sqrt(Food), 0.01f);
        Energy = Mathf.Clamp(Energy, 0f, 1f);

        Vitality += rtVitalityInc * Time.deltaTime;
        Vitality -= rtVitalityDec * Time.deltaTime /
            Mathf.Max(Mathf.Sqrt(Food), 0.01f) / 
            Mathf.Max(Mathf.Sqrt(Energy), 0.01f);
        Vitality = Mathf.Clamp(Vitality, 0f, 1f);

        foodBar.setValue(Food);
        energyBar.setValue(Energy);
        vitalityBar.setValue(Vitality);
    }

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
