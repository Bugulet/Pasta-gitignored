using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionManager : MonoBehaviour
{

    [HideInInspector] public int CurrentObjective = 0;
    [SerializeField] private int MaxObjective = 5;
    
    private FMOD.Studio.Bus _masterBus;

    private void Start()
    {
        _masterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
    }

    //check if this is a good interaction in order
    public bool CheckInteraction(int interactionNumber)
    {
        //Debug.Log("checking");
        if (interactionNumber - 1 == CurrentObjective)
        {
            PrintInteractionNumber();

            CurrentObjective = interactionNumber;
            return true;
        }
        else return false;
    }

    [ContextMenu("Check interaction number")]
    private void PrintInteractionNumber()
    {
        Debug.Log("Current objective -> " + CurrentObjective);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current Objective " + CurrentObjective);
        if (CurrentObjective == MaxObjective)
        {
            SceneManager.LoadScene("_Good_End");
            
            _masterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
