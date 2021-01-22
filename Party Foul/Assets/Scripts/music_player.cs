using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_player : MonoBehaviour, IInteractable
{
    public float musicTimer = 25f;
    private bool musicPlaying;
    public float waitTimeMin = 2f;
    public float waitTimeMax = 12f;
    public Animator animator;
    // Start is called before the first frame update



    void Start()
    {
        FindObjectOfType<AudioManager>().Play("music");
        musicPlaying = true;
        animator.SetBool("playing", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (musicPlaying)
        {
            musicTimer -= Time.deltaTime;
            if (musicTimer <= 0)
            {
                FindObjectOfType<AudioManager>().Play("scratch");
                FindObjectOfType<AudioManager>().Pause("music");
                animator.SetBool("playing", false);
                musicPlaying = false;
                
            }

        }
        
    }

    public void Interact()
    {
        if (!musicPlaying)
        {
            musicTimer += Random.Range(waitTimeMin, waitTimeMax);
            animator.SetBool("playing", true);
            musicPlaying = true;
            FindObjectOfType<AudioManager>().UnPause("music");
        }
    }

    public void StopInteract()
    {
        throw new System.NotImplementedException();
    }

}
