using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_player : MonoBehaviour, IInteractable
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Playing Music");
    }

    public void StopInteract()
    {
        throw new System.NotImplementedException();
    }

}
