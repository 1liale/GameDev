using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    // Define avatars
   public GameObject avatar1, avatar2, avatar3, avatar4;

    // Set all as inactive
	void Start () 
    {
		avatar1.gameObject.SetActive (false);
		avatar2.gameObject.SetActive (false);
        avatar3.gameObject.SetActive (false);
		avatar4.gameObject.SetActive (false);
	}

    public void setChar1()
    {
        pickAvatar(1);
    }

    public void setChar2()
    {
        pickAvatar(2);
    }

    public void setChar3()
    {
        pickAvatar(3);
    }

    public void setChar4()
    {
        pickAvatar(4);
    }

	// public avatar based on avatar selection
	public void pickAvatar(int whichAvatarIsOn)
	{
		// processing whichAvatarIsOn variable
		switch (whichAvatarIsOn) {

		case 1:
            Debug.Log("Picked first character");
			avatar1.gameObject.SetActive (true);
			break;

		case 2:
            Debug.Log("Picked second character");
			avatar2.gameObject.SetActive (true);
			break;

        case 3:
            Debug.Log("Picked third character");
            avatar3.gameObject.SetActive (true);
			break;

        case 4:
            Debug.Log("Picked fourth character");
			avatar4.gameObject.SetActive (true);
			break;    
		}
			
	}
}
