using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float move_speed = 5f;
    Vector2 movement;
    public IInteractable interactable;


    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
	{
        rb.MovePosition(rb.position + movement * move_speed * Time.fixedDeltaTime);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        interactable = collision.collider.GetComponent<IInteractable>();
        Debug.Log(interactable);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        interactable = null;
    }

    public void Interact()
    {
        if (interactable != null)
        {
            interactable.Interact();
        }
    }


}
