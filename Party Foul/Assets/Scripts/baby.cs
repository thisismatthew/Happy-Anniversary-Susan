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

        if (crying == false)
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
        
    }

    public override void Interact()
    {
       
        if (cryingTimer <= 20)
        {
            
            animator.SetBool("crying", false);
            cryingTimer += 20;
            crying = false;
            PlayRandomShush();
            FindObjectOfType<AudioManager>().Stop("cry");
        }
        
    }

    private void BigCry()
    {
        crying = true;
        FindObjectOfType<AudioManager>().Play("cry");
        animator.SetBool("crying", true);


    }

    private void PlayRandomShush()
    {
        string shush = "SHUSH_";
        shush += Random.Range(0, 8).ToString();
        Debug.Log(shush);
        FindObjectOfType<AudioManager>().Play(shush);

    }

}
