using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baby : npc
{
    private bool crying = false;
    public float cryingTimer = 10f;

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
            cryingTimer += 20;
        }
        
    }

    private void BigCry()
    {
        Debug.Log("BIG CRY BIG CRY!");
    }

}
