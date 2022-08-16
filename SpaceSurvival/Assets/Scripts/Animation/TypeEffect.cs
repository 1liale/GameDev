using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public float delay = 0.08f;
    public string fullText;
    private string currentText = "";
    private IEnumerator current;
    
    public void beginType(string str)
    {
        if (current != null)
            StopCoroutine(current);
        StartCoroutine(current = showText(str));
    } 

    IEnumerator showText(string str)
    {
        for(int i = 0; i < str.Length; i++)
        {
            currentText = str.Substring(0,i+1);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
