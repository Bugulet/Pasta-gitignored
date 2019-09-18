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

    // Update is called once per frame
    void Update()
    {
        if (CurrentObjective == MaxObjective)
        {
            Debug.Log("GOTO END");
        }
    }
}
