using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text clock;
    public float speed;

    float totalTime;
    float minutes;
    float hours;
    float days;
    string meridien;

    // Start is called before the first frame update
    void Start()
    {
        clock = GetComponent<Text>();
        
        speed = 1;
        totalTime = 480;
    }

    // Update is called once per frame
    void Update()
    {
        //1 sec = 1 min at normal speed
        totalTime += Time.deltaTime * speed;

        minutes = Mathf.Floor(totalTime % 60);
        hours = Mathf.Floor((totalTime % 720)/60);
        days = Mathf.Floor(totalTime / 1440) + 1;

        if (Mathf.Floor((totalTime % 1440)/60) < 12){
            meridien = "AM";
        }else{
            meridien = "PM";
        }

        if (hours == 0){
            hours = 12;
        }
        clock.text = "Day" + days.ToString() + ", " + hours.ToString("00") + ":" + minutes.ToString("00") + " " + meridien;
    }
}
