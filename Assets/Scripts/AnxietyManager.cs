using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AnxietyManager : MonoBehaviour
{
    private int AnxietyMeter = 0;

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
