using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

///<summary>Manages Character Selection scene</summary>
public class CharacterSelection : MonoBehaviour
{
    ///Characters to be selected from
    public string[] names;
    public Text nameDisplay;

    private DialogueManager dialogueManager;
    private CharacterManager characterManager;

    void Awake()
    {
        dialogueManager = DialogueManager.Instance;
        characterManager = CharacterManager.Instance;
        CharacterManager.characterUpdate += DisplayName;
        CharacterManager.characterUpdate += DisplayDescription;
    }

    // Start is called before the first frame update
    void Start()
    {
        characterManager.ActiveCharacter = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogueManager.Pause();
            Debug.Log(characterManager.ActiveCharacter);
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
    }

    void OnDestroy()
    {
        CharacterManager.characterUpdate -= DisplayName;
        CharacterManager.characterUpdate -= DisplayDescription;
    }

    private void DisplayName(int character)
    {
        nameDisplay.text = names[character];
    }

    private void DisplayDescription(int character)
    {
        dialogueManager.LoadDialogue("CharSelection", character);
        dialogueManager.Play();
    }

    ///Switches to character to the left
    public void SwitchLeft()
    {
        int character = (int)characterManager.ActiveCharacter;
        if (--character < 0)
            character = names.Length - 1;

        characterManager.ActiveCharacter = (CharacterManager.Character)character;
    }

    ///Switches to character to the right
    public void SwitchRight()
    {
        int character = (int)characterManager.ActiveCharacter;
        if (++character >= names.Length)
            character = 0;

        characterManager.ActiveCharacter = (CharacterManager.Character)character;
    }

}
