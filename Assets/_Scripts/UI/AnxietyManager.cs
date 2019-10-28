using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class AnxietyManager : MonoBehaviour
{
    private int AnxietyMeter = 0;

    [SerializeField] private PostProcessingProfile postProcProf;
    [SerializeField] BreathingExercise exercise;

    private float _chromaIntense;
    /// <summary>
    /// at what percentage does the exercise start
    /// </summary>
    [SerializeField][Range(0,100)] private int BreathingExerciseThreshold = 70;

    private FMOD.Studio.Bus _masterBus;

    private void Start()
    {
        _masterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
        _chromaIntense = 0;
    }

    private void SetEffects()
    {
        var chroma = postProcProf.chromaticAberration.settings;
        var grain = postProcProf.grain.settings;
        var grayScale = postProcProf.colorGrading.settings;

        grayScale.basic.saturation = 1 - (AnxietyMeter / 100f);
        if (AnxietyMeter < 25)
        {
            chroma.intensity = 0f;
            grain.intensity = 0f;
            grain.luminanceContribution = 1.0f;
        }

        if (AnxietyMeter >= 25)
        {
            _chromaIntense = 0.50f;
            StartCoroutine(ResetChroma());
            chroma.intensity = _chromaIntense;
            grain.intensity = 0.212f;
            grain.luminanceContribution = 0.8f;
        }

        if (AnxietyMeter >= 50)
        {
            _chromaIntense = 1.14f;
            StartCoroutine(ResetChroma());
            chroma.intensity = _chromaIntense;
            grain.intensity = 0.212f;
            grain.luminanceContribution = 0.45f;
        }

        if (AnxietyMeter >= 70)
        {
            _chromaIntense = 1.77f;
            StartCoroutine(ResetChroma());
            chroma.intensity = _chromaIntense;
            grain.intensity = 0.212f;
            grain.luminanceContribution = 0.1f;
        }

        postProcProf.colorGrading.settings = grayScale;
        postProcProf.chromaticAberration.settings = chroma;
        postProcProf.grain.settings = grain;
    }
    
    //reset the values to default, at least one of them
    private void OnDestroy()
    {
        var grayScale = postProcProf.colorGrading.settings;
        grayScale.basic.saturation = 1;
        
        var chroma = postProcProf.chromaticAberration.settings;
        chroma.intensity = 0;

        var grain = postProcProf.grain.settings;
        grain.intensity = 0;
        grain.luminanceContribution = 1;
        
        postProcProf.colorGrading.settings = grayScale;
        postProcProf.chromaticAberration.settings = chroma;
        postProcProf.grain.settings = grain;
    }

    private IEnumerator ResetChroma()
    {
        var chroma = postProcProf.chromaticAberration.settings;
        yield return new WaitForSeconds(5.0f);
        for (float i = _chromaIntense; i > 0; i -= 0.05f)
        {
            _chromaIntense = i;
            chroma.intensity = _chromaIntense;
            postProcProf.chromaticAberration.settings = chroma;
        }
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
                Debug.Log("Bad end scene");
                SceneManager.LoadScene("_Bad_End");

                _masterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
            exercise.StartPanicAttack();
        }
    }
}
