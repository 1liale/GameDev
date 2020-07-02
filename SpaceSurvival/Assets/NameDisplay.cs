using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameDisplay : MonoBehaviour
{
    Text txt;

    // Use this for initialization
    void Start () 
    {
        txt = gameObject.GetComponent<Text>(); 
        txt.text="Hello";
    }
    public void setName(string str)
    {
        txt.text = "Hello";
    }
}
