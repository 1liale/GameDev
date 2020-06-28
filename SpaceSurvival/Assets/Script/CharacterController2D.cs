using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class CharacterController2D : MonoBehaviour
{					
	public float speed = 6f;
	private bool moveRight = false;
	private bool isWalking = false;

	private Rigidbody2D rigidbody;
	private Vector2 velocity;
	private Vector2 userInput;


	public Animator animator;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		userInput = transform.position;
	}

	void Update()
	{
		// When left mouse button is pressed down
		if (Input.GetMouseButton(0))
        {
			animator.SetBool("walk", true);
			isWalking = true;
			// Stores mouse's position 
            Debug.Log("Mouse button clicked");
			Debug.Log(animator.GetBool("walk"));
			userInput = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

		else 
		{
			animator.SetBool("walk", false);
			isWalking = false;
		}
	}

	void FixedUpdate()
	{

		if(((Vector2)transform.position != userInput) && isWalking)
    	{
       		transform.position = Vector2.MoveTowards(transform.position, userInput, speed * Time.deltaTime);
    	}
	}

}