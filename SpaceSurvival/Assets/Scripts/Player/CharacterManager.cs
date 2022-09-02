using System;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager instance;
    public static CharacterManager Instance
    {
        get { return instance; }
    }

    public static event Action<int> characterUpdate;

    public enum Character { Veteran, ComputerScientist, Nutritionist, Engineer };

    private Character activeCharacter;
    public Character ActiveCharacter
    {
        get { return activeCharacter; }
        set {
            activeCharacter = value;
            characterUpdate?.Invoke((int)value);
        }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            //Debug.LogError("Duplicate CharacterManager", this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {

    }

    void OnDestroy()
    {
        instance = null;
    }
}
