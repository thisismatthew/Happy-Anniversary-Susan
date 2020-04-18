using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float move_speed = 5f;
    Vector2 movement;
    // Start is called before the first frame update

  

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
	{
        rb.MovePosition(rb.position + movement * move_speed * Time.fixedDeltaTime);
	}
}
