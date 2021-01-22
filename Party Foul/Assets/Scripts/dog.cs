using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog : npc
{
    
    public float pooTimer = 20f;
    public GameObject poo;

    public override void Wander()
    {

        if (pooTimer >= 0)
        {
            pooTimer -= Time.deltaTime;
            base.Wander();
        }
        else
        {
            Poo();
            pooTimer += 8f;
        }


    }

    public override void Interact()
    {
        if (pooTimer <= 20)
        {
            pooTimer += 20;
        }

    }

    private void Poo()
    {
        Vector3 pooLocation = this.transform.position;
        Instantiate(poo, pooLocation, Quaternion.identity);
    }

}
