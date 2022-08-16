using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private PlayerStats playerStats;

    public event Action PhysicalInjury;
    public event Action OxygenLeak;
    public event Action DispenserMalfunc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
