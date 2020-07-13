using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    private Dialogue dialogue;
    private bool playDialogue;

    private bool leftSwipe = false, rightSwipe = false;
    private TypeEffect display;

    public void SetPlay(bool playDialogue)
    {
        this.playDialogue = playDialogue;
    }

    public void LoadDialogue(Dialogue dialogue)
    {
        this.dialogue = dialogue;
        dialogue.Reset();
    }

    public void LoadDialogue(string txtFile, int index)
    {
        dialogue = new Dialogue();
        dialogue.Load(txtFile, index);
        dialogue.Reset();
    }

    void Start()
    {
        display = FindObjectOfType<TypeEffect>();
    }

    public void setLeftSwipe()
    {
        leftSwipe = true;
    }

    public void setRightSwipe()
    {
        rightSwipe = true;
    }

    void Update()
    {
        if (!playDialogue) return;

        if (Input.GetKeyDown(KeyCode.Return) || leftSwipe || rightSwipe)
        {
            leftSwipe = false;
            rightSwipe = false;
            Tuple<string, string> line = dialogue.NextLine();
            if (line != null)
            {
                string name = line.Item1;
                string text = line.Item2;
                // display
                display.beginType(text);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
