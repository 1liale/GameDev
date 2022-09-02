using System;
using UnityEngine;
using Cinemachine;

public class CharacterController2D : MonoBehaviour
{
	private Rigidbody2D rigidbody;
    private Animator animator;

	public float speed = 1f;
	// Allow character to move up and down
	public bool enableVerticalMovement = false;

	private bool isWalking = false;

	private Vector2 target;

	void Awake()
    {
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
    }

	void Start()
	{
		target = transform.position;
	}

    public void Teleport(Vector3 pos)
    {
        Vector2 delta = pos - transform.position;
        transform.position = pos;
        //target += delta;
        CinemachineVirtualCamera camera =
            FindObjectOfType<CinemachineVirtualCamera>();
        camera.OnTargetObjectWarped(transform, delta);
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
			target = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
		Vector3 pos = transform.position;
		Vector3 scale = transform.localScale;

		/*
		pos = Vector2.MoveTowards(pos, target, speed * Time.fixedDeltaTime);
		int dir = Mathf.Sign(target.x - pos.x);
		if (dir != 0) {
			scale.x = dir * Mathf.Abs(scale.x);
		}
		*/

		if (Input.GetKey("w"))
		{
			pos.y += speed * Time.fixedDeltaTime;
		}
		if (Input.GetKey("a"))
		{
			pos.x -= speed * Time.fixedDeltaTime;
			scale.x = -Mathf.Abs(scale.x); //Face object leftwards
		}
		if (Input.GetKey("s"))
		{
			pos.y -= speed * Time.fixedDeltaTime;
		}
		if (Input.GetKey("d"))
		{
			pos.x += speed * Time.fixedDeltaTime;
			scale.x = +Mathf.Abs(scale.x); //Face object rightwards
		}

		//Cancel vertical movement
		if (!enableVerticalMovement)
		{
			pos.y = transform.position.y;
		}

		transform.position = pos;
		transform.localScale = scale;
	}

}