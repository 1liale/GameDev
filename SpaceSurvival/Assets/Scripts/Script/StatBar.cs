﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public Slider slider;

    public void setMax(int value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void setValue(float value)
    {
        slider.value = (int)(value * 100);
    }
}
