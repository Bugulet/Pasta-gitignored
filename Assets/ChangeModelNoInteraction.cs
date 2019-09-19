using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModelNoInteraction : InteractWithObject
{
    [Tooltip("The object that will be spawned when the object will be changed")]
    [SerializeField] private GameObject DifferentObject;



    private void Start()
    {
        //manager = FindObjectOfType<InteractionManager>();

    }

    override public void Interact()
    {
       // manager.CheckInteraction(InteractionNumber);
        Instantiate(DifferentObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
