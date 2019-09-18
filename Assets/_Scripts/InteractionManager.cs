using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{

    [HideInInspector] public int CurrentObjective = 0;
    [SerializeField] private int MaxObjective = 6;


    // Start is called before the first frame update
    void Start()
    {

    }

    //check if this is a good interaction in order
    public bool CheckInteraction(int interactionNumber)
    {
        if (interactionNumber - 1 == CurrentObjective)
        {
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
        if (CurrentObjective == MaxObjective)
        {
            Debug.Log("GOTO END");
        }
    }
}
