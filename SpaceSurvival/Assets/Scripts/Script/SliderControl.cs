using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    private static Slider slider;
    private AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.gameObject.SetActive(false);
        backgroundMusic = GameObject.Find("BackgroundAudio").GetComponent<AudioSource>();
        slider.value = backgroundMusic.volume;
    }

    // Update is called once per frame
    public static void setVisible()
    {
        slider.gameObject.SetActive(true);
    }

    void Update()
    {
        backgroundMusic.volume = slider.value;
    }
}
