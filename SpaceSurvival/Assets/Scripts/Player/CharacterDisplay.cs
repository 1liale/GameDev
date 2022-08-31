using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterDisplay : MonoBehaviour
{
    public GameObject[] characters;

    void Awake()
    {
        CharacterManager.characterUpdate += DisplayCharacter;
    }

    void Start()
    {
        Debug.Log(CharacterManager.Instance.ActiveCharacter);
        DisplayCharacter((int)CharacterManager.Instance.ActiveCharacter);
    }

    void OnDestroy()
    {
        CharacterManager.characterUpdate -= DisplayCharacter;
    }

    public void DisplayCharacter(int character)
    {
        for (int i = 0; i < characters.Length; ++i)
        {
            characters[i].SetActive(i == character);
        }
    }
}
