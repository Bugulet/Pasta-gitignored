using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : MonoBehaviour
{
    [SerializeField] private BreathingExercise breathingScript;

    private FMOD.Studio.EventInstance _breathing;

    private void Start()
    {
        _breathing = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Breathing");
    }

    private void Update()
    {
        bool circleExpanding = breathingScript.GetAttackIsHappening();
        if (!circleExpanding)
        {
            _breathing.start();
            if (Mathf.Sin(Time.time) < -0.5f)
            {
                _breathing.setParameterValue("state", 0.0f); // To breathe in
            }
            else if (Mathf.Sin(Time.time) > 0.5f)
            {
                _breathing.setParameterValue("state", 1.0f); // To breathe out
            }
        }
    }
}
