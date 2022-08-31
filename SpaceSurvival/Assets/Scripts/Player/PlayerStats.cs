using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public event Action<float> healthUpdate;
    public event Action<float> foodUpdate;
    public event Action<float> energyUpdate;

    public enum Level { Base, First, Second, Third };

    private float health;
    private float food;
    private float energy;
    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            healthUpdate?.Invoke(value);
        }
    }
    public float Food
    {
        get { return food; }
        set
        {
            food = value;
            foodUpdate?.Invoke(value);
        }
    }
    public float Energy
    {
        get { return energy; }
        set
        {
            energy = value;
            energyUpdate?.Invoke(value);
        }
    }

    public float Trust { get; set; }
    public float Morality { get; set; }

    public Level HealthScience { get; set; }
    public Level Engineering { get; set; }
    public Level ComputerScience { get; set; }

    public Level Strength { get; set; }
    public Level Endurance { get; set; }

    private float deltaHealth;
    private float deltaHeal;
    private float deltaFood;
    private float deltaEnergy;

    void Start()
    {
        Reset();
    }

    void Update()
    {
        float health = Health;
        float food = Food;
        float energy = Energy;

        food -= deltaFood * Time.deltaTime;
        food = Mathf.Clamp(food, 0f, 1f);

        energy -= deltaEnergy * Time.deltaTime /
            Mathf.Max(Mathf.Sqrt(food), 0.01f);
        energy = Mathf.Clamp(energy, 0f, 1f);

        health += deltaHeal * Time.deltaTime;
        health -= deltaHealth * Time.deltaTime /
            Mathf.Max(Mathf.Sqrt(food), 0.01f) /
            Mathf.Max(Mathf.Sqrt(energy), 0.01f);
        health = Mathf.Clamp(health, 0f, 1f);

        Health = health;
        Food = food;
        Energy = energy;
    }

    static void Write(StreamWriter writer)
    {
        writer.WriteLine("Test");
        writer.Close();
    }

    static void Read(StreamReader reader)
    {
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

    public void Reset() {
        Health = 100f;
        Food = 100f;
        Energy = 100f;
        Trust = 50f;
        Morality = 100f;

        HealthScience = Level.Base;
        Engineering = Level.Base;
        ComputerScience = Level.Base;
        Strength = Level.Base;
        Endurance = Level.Base;
    }

}
