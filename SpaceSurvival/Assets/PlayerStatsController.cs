using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{

    public int maxFood = 100;
    public int currentFood;

    public StatBar Foodbar;

    // Start is called before the first frame update
    void Start()
    {
        currentFood = maxFood;
        Foodbar.setMax(maxFood);
    }

    // Update is called once per frame
    void Update()
    {
        currentFood -= 1;
        Foodbar.setValue(currentFood);
    }
}
