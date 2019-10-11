using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{

    [Tooltip("The index of the interaction so they happen in order")]
    [SerializeField] protected int InteractionNumber = 0;
    
    
    public int currentInteraction = 0;

    [HideInInspector] public int currentTask;
    private InteractionManager _manager;

    // Start is called before the first frame update
    void Start()
    {
        _manager = FindObjectOfType<InteractionManager>();
    }
    
    public virtual void Interact()
    {
        if (_manager.CheckInteraction(InteractionNumber))
        {
            Debug.Log("changed numb");
        }
    }
}