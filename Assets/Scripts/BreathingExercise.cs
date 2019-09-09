using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathingExercise : MonoBehaviour
{

    [SerializeField] private RawImage circle;
   // [SerializeField] private 
    private bool attackIsHappening = false;

    //the amount of times the entire 4-7-8 process was repeated
    private int currentRepeats = 0;

    // Start is called before the first frame update
    void Start()
    {
        //make sure its invisible at first
        circle.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        //if(attackIsHappening)
    }

    public void StartPanicAttack()
    {
        attackIsHappening = true;
    }
}
