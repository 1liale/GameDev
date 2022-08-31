using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameDisplay : MonoBehaviour
{
    private Text text;

    void Awake()
    {
        text = GetComponent<Text>(); 
        DialogueManager.nameUpdate += SetName;
    }

    void OnDestroy()
    {
        DialogueManager.nameUpdate -= SetName;
    }

    public void SetName(string name)
    {
        text.text = name;
    }
}
