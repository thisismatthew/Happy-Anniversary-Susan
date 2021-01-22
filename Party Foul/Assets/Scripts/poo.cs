using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poo : MonoBehaviour, IInteractable
{
    public GameObject selfReference;
    public void Interact()
    {
        PlayRandomPoo();
        Destroy(selfReference);
    }

    public void StopInteract()
    {
        throw new System.NotImplementedException();
    }

    private void PlayRandomPoo()
    {
        string poo = "Poo_";
        poo += Random.Range(0, 8).ToString();
        FindObjectOfType<AudioManager>().Play(poo);
    }

}
