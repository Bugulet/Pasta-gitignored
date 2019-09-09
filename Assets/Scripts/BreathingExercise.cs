using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathingExercise : MonoBehaviour
{

    [SerializeField] private RawImage circle;
    [SerializeField] private int BreathInThreshold = 4;
    [SerializeField] private int BreathHoldThreshold = 7;
    [SerializeField] private int BreathOutThreshold = 8;

    private bool attackIsHappening = false;

    //the amount of times the entire 4-7-8 process was repeated
    private int currentRepeats = 0;

    //0 is in, 1 is hold, 2 is out
    private int breathingStage = 0;

    private float breathCounter = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        //make sure its invisible at first
        circle.GetComponent<RawImage>().enabled = false;
        circle.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackIsHappening)  
        {
            //set the circle to visible
            circle.GetComponent<RawImage>().enabled = true;

            if (breathCounter < BreathInThreshold && breathingStage==0)
            {
                if (Input.GetMouseButton(0))
                {
                    breathCounter += Time.deltaTime;
                    circle.transform.localScale = breathCounter * Vector3.one ;
                }
            }
            else
            {
                breathingStage++;
                attackIsHappening = false;
            }
        }
    }

    public void StartPanicAttack()
    {
        Debug.Log("started");
        //reset all the variables
        breathingStage = 0;
        breathCounter = 0;

        attackIsHappening = true;
    }
}
