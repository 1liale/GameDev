using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public float delay = 0.0075f;
    public string fullText;
    private string currentText = ""; 
    IEnumerator curRoutine;
    
    public void beginType(string str)
    {
        curRoutine = showText(str);
        StartCoroutine(curRoutine);
    } 

    public IEnumerator showText(string str)
    {
        for(int i = 0; i < str.Length; i++)
        {
            currentText = str.Substring(0,i+1);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
