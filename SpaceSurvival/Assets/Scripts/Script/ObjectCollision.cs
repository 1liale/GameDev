using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator anim;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Door")
        {
            Debug.Log("Door zone entered");
            anim = collider.GetComponent<Animator>();
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Door")
        {
            Debug.Log("Door zone entered");
            if(Input.GetKey(KeyCode.H))
            {
                Debug.Log("Door open");
                anim.SetBool("openDoor",true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        anim.SetBool("openDoor",false);
    }
}
