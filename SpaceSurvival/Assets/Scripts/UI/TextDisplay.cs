using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    private Text text;

    public float delay = 0.08f;
    public string fullText;
    private string currentText = "";
    private IEnumerator current;

    void Awake()
    {
        text = gameObject.GetComponent<Text>();
        DialogueManager.textUpdate += BeginType;
    }

    void OnDestroy()
    {
        DialogueManager.textUpdate -= BeginType;
    }
    
    public void BeginType(string str)
    {
        if (current != null)
            StopCoroutine(current);
        StartCoroutine(current = ShowText(str));
    } 

    IEnumerator ShowText(string str)
    {
        for(int i = 0; i < str.Length; i++)
        {
            currentText = str.Substring(0,i+1);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
