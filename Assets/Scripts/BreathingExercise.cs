using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreathingExercise : MonoBehaviour
{

    [SerializeField] private RawImage circle;
    [SerializeField] private TextMeshProUGUI instruction;
    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private int BreathInThreshold = 3;
    [SerializeField] private int BreathHoldThreshold = 3;
    [SerializeField] private int BreathOutThreshold = 3;

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
        instruction.alpha = 0;
        counter.alpha = 0;
        circle.GetComponent<RawImage>().enabled = false;
        circle.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackIsHappening)
        {
            instruction.alpha = 255;
            counter.alpha = 255;

            //set the circle to visible
            circle.GetComponent<RawImage>().enabled = true;

            //breath in
            if (breathingStage == 0)
            {
                instruction.SetText("Left click to breathe in" + '\n' + (3 - currentRepeats) + " more times to go");
                if (Input.GetMouseButton(0))
                {
                    breathCounter += Time.deltaTime;
                    circle.transform.localScale = breathCounter * Vector3.one;
                    counter.SetText("" + (int)breathCounter);
                    if (breathCounter > BreathInThreshold)
                    {
                        breathingStage++;
                        breathCounter = 0;
                    }
                }
            }

            //hold breath
            if (breathingStage == 1)
            {
                instruction.SetText("Don't press anything to hold breath" + '\n' + (3 - currentRepeats) + " more times to go");
                if (!Input.GetMouseButton(1) && !Input.GetMouseButton(0))
                {
                    breathCounter += Time.deltaTime;
                    //circle.transform.localScale = BreathInThreshold * Vector3.one - breathCounter * Vector3.one;
                    counter.SetText("" + (int)breathCounter);
                    if (breathCounter > BreathHoldThreshold)
                    {
                        breathingStage++;
                        breathCounter = 0;
                    }
                }
            }

            //breathe out
            if (breathingStage == 2)
            {
                instruction.SetText("Right click to breathe out" + '\n' + (3 - currentRepeats) + " more times to go");
                if (Input.GetMouseButton(1))
                {
                    breathCounter += Time.deltaTime;
                    circle.transform.localScale = BreathInThreshold * Vector3.one - breathCounter * Vector3.one;
                    counter.SetText("" + (int)breathCounter);
                    if (breathCounter > BreathOutThreshold)
                    {
                        breathingStage = 0;
                        breathCounter = 0;
                        currentRepeats++;
                        //attack ends
                        if (currentRepeats >= 3)
                        {
                            StopPanicAttack();
                        }
                    }
                }
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

    public void StopPanicAttack()
    {
        attackIsHappening = false;
        breathingStage = 0;
        breathCounter = 0;
        currentRepeats = 0;

        instruction.alpha = 0;
        counter.alpha = 0;
        circle.GetComponent<RawImage>().enabled = false;
        circle.transform.localScale = Vector3.zero;

    }
}
