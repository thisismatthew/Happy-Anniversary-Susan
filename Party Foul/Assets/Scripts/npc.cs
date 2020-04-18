using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{

    //much of this script was pulled from https://forum.unity.com/threads/making-npcs-wander-in-2d.524950/
    internal Transform thisTransform;
    public float moveSpeed = 0.2f;
    public Vector2 decisionTime = new Vector2(1, 4);
    internal float decisionTimeCount = 0;
    // The possible directions that the object can move int, right, left, up, down, and zero for staying in place. I added zero twice to give a bigger chance if it happening than other directions
    internal Vector3[] moveDirections = new Vector3[] { Vector3.right, Vector3.left, Vector3.forward, Vector3.back, Vector3.zero, Vector3.zero };
    internal int currentMoveDirection;
    private npc target;
    

    public string Name { get => name; set => name = value; }

    void Start()
    {
        thisTransform = this.transform; // Cache the transform for quicker access
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y); // Set a random time delay for taking a decision ( changing direction, or standing in place for a while )
        ChooseMoveDirection();// Choose a movement direction, or stay in place
    }

    
    public void Wander()
    { 
        thisTransform.position += moveDirections[currentMoveDirection] * Time.deltaTime * moveSpeed;  // Move the object in the chosen direction at the set speed

        if (decisionTimeCount > 0) decisionTimeCount -= Time.deltaTime;
        else
        {
            decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y); // Choose a random time delay for taking a decision ( changing direction, or standing in place for a while )
            ChooseMoveDirection();// Choose a movement direction, or stay in place
        }
    }

    void ChooseMoveDirection()
    {
        // Choose whether to move sideways or up/down
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "npc")
        {
            currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
        }
    }
}
