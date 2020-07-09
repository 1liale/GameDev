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
    ///wrap's text after <code>wrapSize</code> characters are displayed
    public void beginType(string str, int wrapSize)
    {
        if (current != null){
            StopCoroutine(current);
        }
        StartCoroutine(current = showText(str, wrapSize));
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
    ///wrap's text after <code>wrapSize</code> characters are displayed
    IEnumerator showText(string str, int wrapSize)
    {
        this.GetComponent<Text>().text = "";
        for(int i = 0; i < str.Length; i++)
        {
            if ((i+1)%wrapSize==0) 
                this.GetComponent<Text>().text+='\n';
            //currentText = str.Substring(0,i+1);
            this.GetComponent<Text>().text += str[i];
            yield return new WaitForSeconds(delay);
        }
    }
}
