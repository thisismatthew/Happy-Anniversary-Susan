using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private int _disaster_count;
	private int _score;
	public Player _player;
	public npc[] _non_player_characters;
   

	// Start is called before the first frame update
	void Start()
	{
		_disaster_count = 0;
		_score = 0;
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

    }

  
}
