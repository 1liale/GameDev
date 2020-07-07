using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsAnim : MonoBehaviour
{
    public float increment;
    public float time;
    private SpriteRenderer spaceship;
    private SpriteRenderer background;

    private Color[] decorsColor;

    private int counter = 0;
 
 void startBlur()
 {
    StartCoroutine(blurEffect());
 }

 IEnumerator blurEffect()
 {
    spaceship = GameObject.Find ("Spaceship").GetComponent<SpriteRenderer> ();
    background = GameObject.Find ("Background").GetComponent<SpriteRenderer> ();

    Color tmp = spaceship.color;
    Color tmp1 = background.color;  
    
    while(tmp.a >= 0 || tmp1.a >= 0)
    {
        tmp.a -= increment;
        tmp1.a -= increment;
        spaceship.color = tmp;
        background.color = tmp1;
        yield return new WaitForSeconds(time);
    }
    StopCoroutine(blurEffect());
 }

}
