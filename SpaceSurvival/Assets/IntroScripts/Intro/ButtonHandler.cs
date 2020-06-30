using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    
    public GameObject pointerButton1;
    public GameObject pointerButton2;
    public void onHover()
    {
        pointerButton1.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void offHover()
    {
        pointerButton1.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void buttonClicked()
    {
        pointerButton1.GetComponent<SpriteRenderer>().enabled = false;
        pointerButton2.GetComponent<SpriteRenderer>().enabled = true;
    }
}
