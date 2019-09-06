using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnxietyCounter : MonoBehaviour
{

    [SerializeField] private int StartingHour = 9;
    [SerializeField] private int StartingMinute = 0;
    [SerializeField] private int UpdateRate = 1;

    private int currentHour;
    private int currentMinute;
    private TextMeshProUGUI text;
    

    private void OnEnable()
    {
        //get the component
        text = GetComponent<TextMeshProUGUI>();

        //invoke the repeating
        InvokeRepeating("UpdateTime", 0f, UpdateRate);

        currentHour = StartingHour;
        currentMinute = StartingMinute;
    }

    private void UpdateTime()
    {
        currentMinute++;
        if (currentMinute >= 60)
        {
            currentHour++;
            currentMinute = 0;
        }
        //set the UI
        if(currentMinute%15==0)
        if(currentMinute<10)
        {
            text.SetText(currentHour + ":0" + currentMinute);
        }
        else
        {
            text.SetText(currentHour + ":" + currentMinute);
        }
    }

}
