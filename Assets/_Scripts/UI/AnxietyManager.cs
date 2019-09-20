using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.PostProcessing;

public class AnxietyManager : MonoBehaviour
{
    private int AnxietyMeter = 0;

    [SerializeField] private PostProcessingProfile postProcProf;
    [SerializeField] BreathingExercise exercise;

    /// <summary>
    /// at what percentage does the exercise start
    /// </summary>
    [SerializeField][Range(0,100)] private int BreathingExerciseThreshold = 70;

    private FMOD.Studio.Bus _masterBus;

    private void Start()
    {
        _masterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
    }

    private void SetEffects()
    {
        var vignette = postProcProf.vignette.settings;
        var bloom = postProcProf.bloom.settings;
        var grayScale = postProcProf.colorGrading.settings;

        grayScale.basic.saturation = 1 - (AnxietyMeter / 100f);

        postProcProf.colorGrading.settings = grayScale;
    }
    
    //reset the values to default, at least one of them
    private void OnDestroy()
    {
        var grayScale = postProcProf.colorGrading.settings;
        grayScale.basic.saturation = 1;
        postProcProf.colorGrading.settings = grayScale;
    }

    public void IncreaseAnxiety(int level)
    {
        AnxietyMeter += level;

        SetEffects();

        CheckAnxiety();

        Debug.Log("INCREASED ANXIETY, LEVEL: " + AnxietyMeter);
    }

    public void SetAnxiety(int level)
    {
        AnxietyMeter = level;

        SetEffects();

        Debug.Log("SET ANXIETY, LEVEL: " + AnxietyMeter);
    }

    public int GetAnxiety()
    {
        //Debug.Log("ANXIETY LEVEL: " + AnxietyMeter);
        return AnxietyMeter;
    }

    public void CheckAnxiety()
    {
        if (AnxietyMeter > BreathingExerciseThreshold)
        {
            if (AnxietyMeter >= 100)
            {
                Debug.Log("Changed scene");
                SceneManager.LoadScene("_Bad_End");

                _masterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }

            exercise.StartPanicAttack();

        }

    }

}
