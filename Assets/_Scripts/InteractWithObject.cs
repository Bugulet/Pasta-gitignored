using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{

    [Tooltip("The index of the interaction so they happen in order")]
    [SerializeField] protected int InteractionNumber = 0;

    protected InteractionManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<InteractionManager>();
    }

    public virtual void Interact()
    {
        if (manager.CheckInteraction(InteractionNumber))
        {
            Debug.Log("changed numb");
        }
    }
}