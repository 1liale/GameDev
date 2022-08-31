using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private PlayerStats playerStats;

    public event Action physicalInjury;
    public event Action oxygenLeak;
    public event Action dispenserMalfunc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
