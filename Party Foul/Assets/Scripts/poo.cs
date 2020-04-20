using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poo : MonoBehaviour, IInteractable
{
    public GameObject selfReference;
    public void Interact()
    {
        Destroy(selfReference);
    }

    public void StopInteract()
    {
        throw new System.NotImplementedException();
    }
}
