﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setMax(float value)
    {
        slider.maxValue = value;
        slider.value = value;

        fill.color = gradient.Evaluate(1f);
    }

    public void setValue(float value)
    {
        slider.value = value;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
