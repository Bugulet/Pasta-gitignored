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
    [SerializeField] private int BreathingExerciseThreshold = 70;


    private void Update()
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

        CheckAnxiety();

        Debug.Log("INCREASED ANXIETY, LEVEL: " + AnxietyMeter);
    }

    public void DecreaseAnxiety(int level)
    {
        AnxietyMeter -= level;

        Debug.Log("DECREASED ANXIETY, LEVEL: " + AnxietyMeter);
    }

    public int GetAnxiety()
    {
        Debug.Log("ANXIETY LEVEL: " + AnxietyMeter);
        return AnxietyMeter;
    }

    public void CheckAnxiety()
    {
        if (AnxietyMeter > BreathingExerciseThreshold)
        {
            if (AnxietyMeter >= 100)
            {
                Debug.Log("Changed scene");
                SceneManager.LoadScene("EndScene");
            }

            exercise.StartPanicAttack();

        }

    }

}
