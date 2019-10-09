using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BreathingExercise : MonoBehaviour
{
    [SerializeField] private GameObject NormalUI;
    [SerializeField] private AnxietyManager manager;
     private RawImage circle;
     private TextMeshProUGUI instruction;
     private TextMeshProUGUI counter;
     private Image crosshair;
    [SerializeField] private int ScoreThreshold = 3;

    [SerializeField] private RaycastInterract disableInteraction;
    
    private bool attackIsHappening = false;
    private bool activateAttack = false;

    private float circleScale = 1.5f;

    //the amount of times the entire 4-7-8 process was repeated
    private int currentRepeats = 0;

    //0 is in, 1 is hold, 2 is out
    private int breathingStage = 0;

    private float breathCounter = 0;
    
    private int score=0;

    private bool _hasBreathed = false;

    // Audio
    private FMOD.Studio.EventInstance _breathing;
    private bool _breathingAudioPlaying = false;

    void Start()
    {
        circle = NormalUI.transform.GetChild(0).GetComponent<RawImage>();
        instruction = NormalUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        counter = NormalUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>();   
        crosshair = NormalUI.transform.GetChild(3).GetComponent<Image>();
        //make sure its invisible at first
        instruction.alpha = 0;
        counter.alpha = 0;
        circle.GetComponent<RawImage>().enabled = false;
        circle.transform.localScale = Vector3.one*0.5f;
        
        _breathing = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Breathing");
    }

    // Update is called once per frame
    void Update()
    {
        if (activateAttack)
        {
            if (_breathingAudioPlaying == false)
            {
                _breathing.start();
                _breathing.setParameterValue("state", 0.5f); // Failed at breathing
                _breathingAudioPlaying = true;
            }
            
            instruction.alpha = 255;
            instruction.SetText("Press F to start the breathing exercise");
            
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                attackIsHappening = true;
                activateAttack = false;
            }
        }

        if (attackIsHappening)
        {
            if (_breathingAudioPlaying == false)
            {
                _breathing.start();
                _breathingAudioPlaying = true;
            }
        }

        if (Mathf.Sin(Time.time) > 0.45f && Mathf.Sin(Time.time) < 0.55)
        {
            _hasBreathed = false;
        }
        
        if (attackIsHappening)
        {
            instruction.SetText("Left Click when circle is big or small." +'\n'+(ScoreThreshold-score)+" points to go");
            crosshair.GetComponent<Image>().enabled = false;
            instruction.alpha = 255;
            counter.alpha = 255;

            //set the circle to visible
            circle.GetComponent<RawImage>().enabled = true;

            circle.transform.localScale =  map(Mathf.Sin(Time.time), -1,1, 0.5f, circleScale) * Vector3.one;
            Color c = new Color(1, map(Mathf.Sin(Time.time), -1, 1, 0.5f, 1), map(Mathf.Sin(Time.time), -1,1,0,1 ),0.5f);
            circle.GetComponent<RawImage>().color = c;

            disableInteraction.enabled = false;

            if (Input.GetMouseButtonDown(0))
            {
                if (Mathf.Sin(Time.time) < -0.4f && _hasBreathed == false) // small circle
                {
                    _breathing.setParameterValue("state", 1.0f); // To breathe in
                    score++;
                    _hasBreathed = true;
                }
                else if (Mathf.Sin(Time.time) > 0.6f && _hasBreathed == false) // big circle
                {
                    _breathing.setParameterValue("state", 0.0f); // To breathe out
                    score++;
                    _hasBreathed = true;
                }
                else
                {
                    _breathing.setParameterValue("state", 0.5f); // Failed at breathing
                    score = 0;
                    FailPanicAttack();
                }
                counter.SetText(""+score);
            }

            if (score >= ScoreThreshold)
            {
                StopPanicAttack();
            }
        }
    }

    public void StartPanicAttack()
    {
        Debug.Log("started");
        //reset all the variables
        breathingStage = 0;
        breathCounter = 0;

        activateAttack = true;
    }

    public void StopPanicAttack()
    {
        activateAttack = false;
        attackIsHappening = false;
        breathingStage = 0;
        breathCounter = 0;
        currentRepeats = 0;

        score = 0;

        instruction.alpha = 0;
        counter.alpha = 0;
        circle.GetComponent<RawImage>().enabled = false;
        circle.transform.localScale = Vector3.zero;

        crosshair.GetComponent<Image>().enabled = true ;

        manager.SetAnxiety(20);

        disableInteraction.enabled = true;

    }
    
    public void FailPanicAttack()
    {
        activateAttack = true;
        attackIsHappening = false;
        breathingStage = 0;
        breathCounter = 0;
        currentRepeats = 0;

        score = 0;

        instruction.alpha = 0;
        counter.alpha = 0;
        circle.GetComponent<RawImage>().enabled = false;
        circle.transform.localScale = Vector3.zero;

        crosshair.GetComponent<Image>().enabled = true ;

    }

    //number mapping
    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
    
    public bool GetAttackIsHappening()
    {
        return attackIsHappening;
    }
}
