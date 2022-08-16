using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform target;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Portal entered");
        Rigidbody2D rb = collider.attachedRigidbody;
        if (rb.tag == "Player")
        {
            CharacterController2D controller = 
                rb.GetComponent<CharacterController2D>();
            controller.Teleport(target.position);
        }
    }
}
