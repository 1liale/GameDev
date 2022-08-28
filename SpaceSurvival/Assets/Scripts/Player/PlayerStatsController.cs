using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    public delegate void StatUpdateHandler(float value);

    public event StatUpdateHandler HealthUpdate;
    public event StatUpdateHandler FoodUpdate;
    public event StatUpdateHandler EnergyUpdate;

    public StatBar healthBar;
    public StatBar foodBar;
    public StatBar energyBar;

    public PlayerStats stats;

    private float deltaHealth;
    private float deltaHeal;
    private float deltaFood;
    private float deltaEnergy;

    void Awake()
    {
        stats = new PlayerStats();

        HealthUpdate += healthBar.SetValue;
        FoodUpdate += foodBar.SetValue;
        EnergyUpdate += energyBar.SetValue;
    }

    void Update()
    {
        float health = stats.Health;
        float food = stats.Food;
        float energy = stats.Energy;

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

        stats.Health = health;
        stats.Food = food;
        stats.Energy = energy;

        HealthUpdate?.Invoke(stats.Health);
        FoodUpdate?.Invoke(stats.Food);
        EnergyUpdate?.Invoke(stats.Energy);
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
    
    void OnDestroy()
    {
        HealthUpdate -= healthBar.SetValue;
        FoodUpdate -= foodBar.SetValue;
        EnergyUpdate -= energyBar.SetValue;
    }
}
