using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnxietyCounter : MonoBehaviour
{
    [Header("Starting time")]
    [SerializeField] private int StartingHour = 9;
    [SerializeField] private int StartingMinute = 0;


    [Header("Other data")]
    [Tooltip("How many minutess are added per second")]
    [SerializeField] private int UpdateRate = 1;
    
    private GameTime time;
    private PhoneManager phoneManager;

    [Tooltip("The text element on the normal UI")]
    [SerializeField] private TextMeshProUGUI TimeText;
    

    private void OnEnable()
    {
        time = new GameTime();
        time.minutes = 0;
        time.hour = 0;
        phoneManager = FindObjectOfType<PhoneManager>();

        //invoke the repeating
        InvokeRepeating("UpdateTime", 0f, UpdateRate);

        time.hour = StartingHour;
        time.minutes = StartingMinute;
    }

    private void UpdateTime()
    {
        time.minutes++;
        if (time.minutes >= 60)
        {
            time.hour++;
            time.minutes = 0;
        }
        //set the UI
        //if(time.minutes%15==0)
        if(time.minutes<10)
        {   
            TimeText.SetText(time.hour + ":0" + time.minutes);
        }
        else
        {
            TimeText.SetText(time.hour + ":" + time.minutes);
        }

        //Debug.Log(time.tring());

        //checks if a message needs to be sent
        phoneManager.CheckTimes();
    }

    public GameTime GetTime()
    {
        return time;
    }

}
