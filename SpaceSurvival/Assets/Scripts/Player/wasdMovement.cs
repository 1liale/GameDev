using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows object to be controlled by wasd arrow keys
public class wasdMovement : MonoBehaviour
{

    // Zoomy level
    public float speed;
    // Allow character to move up and down
    public bool EnableVerticalMovement = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Updated object's position and scale
        Vector3 pos = transform.position;
        Vector3 scale = transform.localScale;

        if (Input.GetKey ("w")) {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey ("a")) {
            pos.x -= speed * Time.deltaTime;
            scale.x = -1; //Face object leftwards
        }
        if (Input.GetKey ("s")) {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey ("d")) {
            pos.x += speed * Time.deltaTime;
            scale.x = 1; //Face object rightwards
        }

        //Cancel vertical movement
        if (!EnableVerticalMovement) { 
            pos.y = transform.position.y;
        }

        transform.position = pos;
        transform.localScale = scale;
    }
}
