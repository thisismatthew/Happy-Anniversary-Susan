using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float move_speed = 5f;
    private Vector2 movement;
    public IInteractable interactable;
    public Animator animator;
    public SpriteRenderer sr;


    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", (Mathf.Abs((float)movement.x) + Mathf.Abs((float)movement.y)));
        if ((float)movement.x < 0)
            sr.flipX = true;
        else
            sr.flipX = false;
     

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
