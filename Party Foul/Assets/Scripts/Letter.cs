using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public Animator animator;
    private float timer = 20f;
    // Update is called once per frame
    void Update()
    {
        timer -= 0.01f;
        Debug.Log(timer);
        animator.SetFloat("Timer", timer);
    }
}
