using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private int _disaster_count;
	private int _score;
	public GameObject _player;
	public npc[] _non_player_characters;
    public float _interaction_range = 1f;
    public GameObject[] _interactable_object;

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
        foreach (GameObject interactable in _interactable_object)
        {
            if (Vector3.Distance(_player.transform.position, interactable.transform.position) <= _interaction_range)
            {
                Debug.Log(interactable);
            }
        }

    }
}
