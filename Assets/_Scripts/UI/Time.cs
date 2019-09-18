using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameTime
{
    [Tooltip("Hour at which the message will be received")]
    [SerializeField] public int hour=0;
    [Tooltip("Hour at which the message will be received")]
    [SerializeField] public int minutes=0;

    public string tring()
    {
        return hour + ":" + minutes;
    }
}