using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class CharacterController2D : MonoBehaviour
{					
	public float speed = 6f;

	private Rigidbody2D rigidbody;
	private Vector2 velocity;
	private Vector2 userInput;

	[SerializeField]
	Transform target;

	void Start()
	{	
		rigidbody = GetComponent<Rigidbody2D>();
		userInput = transform.position;
	}

	void Update()
	{
		// When left mouse button is pressed down
		if(Input.GetMouseButtonDown(0))
        {
			// Stores mouse's position 
            Debug.Log("Mouse button clicked");
			userInput = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			// Display on inspector
			target.position = userInput;
        }
	}

	void FixedUpdate()
	{

		if((Vector2)transform.position != userInput)
    	{
       		transform.position = Vector2.MoveTowards(transform.position, userInput, speed * Time.deltaTime);
    	}
	}

}