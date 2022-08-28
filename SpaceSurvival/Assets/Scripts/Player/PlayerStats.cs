using UnityEngine;

public class PlayerStats
{
    public enum Level { Base, First, Second, Third };

    public float Health { get; set; }
    public float Food { get; set; }
    public float Energy { get; set; }

    public float Trust { get; set; }
    public float Morality { get; set; }

    public Level HealthSci { get; set; }
    public Level Engineer { get; set; }
    public Level ComputerSci { get; set; }

    public Level Strength { get; set; }
    public Level Endurance { get; set; }

    public PlayerStats() {
        Health = 100f; Food = 100f; Energy = 100f;
        Trust = 50f; Morality = 100f;

        HealthSci = Level.Base; Engineer = Level.Base; ComputerSci = Level.Base;
        Strength = Level.Base; Endurance = Level.Base;
    }

}
