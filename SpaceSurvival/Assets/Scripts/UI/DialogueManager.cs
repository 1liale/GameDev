using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    public static DialogueManager Instance {
        get { return instance; }
    }

    public static event Action<string> nameUpdate;
    public static event Action<string> textUpdate;

    private Dialogue dialogue;
    private bool onPlay;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            //Debug.LogError("Duplicate DialogueManager", this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogue != null && onPlay) Display();
        }
    }

    void OnDestroy()
    {
        instance = null;
    }

    public void Play()
    {
        onPlay = true;
        if (dialogue != null) Display();
    }

    public void Pause()
    {
        onPlay = false;
    }

    public void LoadDialogue(Dialogue dialogue)
    {
        dialogue.Reset();
        this.dialogue = dialogue;
    }

    public void LoadDialogue(string txtFile, int index)
    {
        dialogue = new Dialogue();
        dialogue.Load(txtFile, index);
        dialogue.Reset();
    }

    void Display()
    {
        Tuple<string, string> line = dialogue.NextLine();
        if (line != null)
        {
            string name = line.Item1;
            string text = line.Item2;

            nameUpdate?.Invoke(name);
            textUpdate?.Invoke(text);
        }
        else
        {
            onPlay = false;
        }
    }
}
