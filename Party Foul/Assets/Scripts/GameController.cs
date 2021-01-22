using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	//private int _disaster_count;
	//private int _score;
	public Player _player;
	public npc[] _non_player_characters;
    public float timeUntilSusan = 120f;
    public GameObject Susan;
    private bool SusanHere = false;
    public Animator camera_animator;
   

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{

        foreach (npc ai in _non_player_characters)
        {
            ai.Wander();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.Interact();
        }

        timeUntilSusan -= Time.deltaTime;
        if (timeUntilSusan <= 0 && SusanHere == false)
        {
            FindObjectOfType<AudioManager>().Play("Door");
            SusanHere = true;
            Instantiate(Susan);
            if (RoomPerfect())
            {
                //play Susans Takes you back
                FindObjectOfType<AudioManager>().Play("Susan_Win");
                FindObjectOfType<music_player>().musicTimer += 1000; // music plays rest of song
                FindObjectOfType<baby>().cryingTimer += 1000; // baby no cry cause mama and papa are happy
                FindObjectOfType<dog>().pooTimer += 1000; // dog holds it in because the alpha is home
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Susan_Lose");
                FindObjectOfType<music_player>().musicTimer -= 100; // music stops
                FindObjectOfType<baby>().cryingTimer -= 100; // baby crys at the failure of thier father
                FindObjectOfType<dog>().pooTimer -= 100; // dog lets it loose
                //play susan rejects you.
               
            }
            camera_animator.SetBool("Susan_Home", true);
        }
        if (timeUntilSusan < -50)
        {
            Application.Quit();
        }
       
    }

    bool RoomPerfect()
    {
        if ((FindObjectOfType<poo>() == null) && (FindObjectOfType<music_player>().musicTimer > 0) && (FindObjectOfType<baby>().cryingTimer > 0))
            return true;
        else
            return false;
    }

  
}
