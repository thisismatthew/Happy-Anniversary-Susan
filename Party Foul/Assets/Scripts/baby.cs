using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baby : npc
{
    private bool crying = false;
    public float cryingTimer = 10f;
    public Sprite[] babySprites;

   public override void Wander()
    {
        
        if (cryingTimer >= 0)
        {
            cryingTimer -= Time.deltaTime;
            base.Wander();
        }
        else
        {
            BigCry();
        }
        
        
    }

    public override void Interact()
    {
       
        if (cryingTimer <= 20)
        {
            animator.SetBool("crying", false);
            cryingTimer += 20;
        }
        
    }

    private void BigCry()
    {
        animator.SetBool("crying", true);
        FindObjectOfType<AudioManager>().Play("cry"); // bell plays when ending?
    }

}
