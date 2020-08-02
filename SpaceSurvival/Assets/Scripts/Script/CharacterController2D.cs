using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class CharacterController2D : MonoBehaviour
{					
	public float speed = 0.4f;

	private int moveRight = 0;
	private bool isWalking = false;
	private bool facingRight = false;

	private Rigidbody2D rigidbody;
    private Animator animator;
	private Vector2 velocity;
	private Vector2 userInput;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		userInput = transform.position;
	}

	// Helper method to change the direction that the character is facing
	private void flip()
	{
		facingRight = !facingRight;
		Vector3 toScale = transform.localScale;
		toScale.x *= -1;
		transform.localScale = toScale;
	}

    public void Teleport(Vector2 newPos)
    {
        userInput += newPos - (Vector2)transform.position;
        transform.position = newPos;
    }

	void Update()
	{
		// When left mouse button is pressed down
		if (Input.GetMouseButton(0))
        {
			// Character starts walking
			animator.SetBool("walk", true);
			isWalking = true;

			// Stores mouse's position 
            Debug.Log("Mouse button clicked");
			Debug.Log(animator.GetBool("walk"));
			userInput = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			// Prints mouse x and object's current x coordinate
			//Debug.Log(userInput.x);
			//Debug.Log(transform.position.x);

			// Checks if mouse click is to the right of the object
			if(userInput.x > transform.position.x)
			{
				moveRight = -1;
			} 

			// Checks if mouse click is to the left of the object
			else if(userInput.x < transform.position.x)
			{
				moveRight = 1;
			}
			
        }
		else 
		{
			// Character stops walking
			animator.SetBool("walk", false);
			isWalking = false;
		}

		
	}
	
	void FixedUpdate()
	{

		// if(((Vector2)transform.position != userInput) && isWalking)
    	// {
       		transform.position = Vector2.MoveTowards(transform.position, new Vector2(userInput.x,transform.position.y), speed * Time.deltaTime);
    	// }

		if (moveRight > 0 && !facingRight)
		{
			flip();
		}

		// Otherwise if the input is moving the player left and the player is facing right...
		else if (moveRight < 0 && facingRight)
		{
			flip();
		}
	}

}