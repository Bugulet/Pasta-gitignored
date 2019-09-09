using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.PostProcessing;

public class AnxietyManager : MonoBehaviour
{
    private int AnxietyMeter = 0;
    
    [SerializeField] private PostProcessingProfile postProcProf;
   

    private void Update()
    {
        var vignette = postProcProf.vignette.settings;
        var bloom = postProcProf.bloom.settings;
        var grayScale = postProcProf.colorGrading.settings;

        grayScale.basic.saturation = 1 - (AnxietyMeter / 100f);

        vignette.intensity= AnxietyMeter / 200f;

        //bloom.bloom.intensity = AnxietyMeter/100f;

        postProcProf.colorGrading.settings = grayScale;
       // postProcProf.vignette.settings = vignette;
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
        if (AnxietyMeter >= 100)
        {
            Debug.Log("Changed scene");
            SceneManager.LoadScene("EndScene");
        }
    }

}
