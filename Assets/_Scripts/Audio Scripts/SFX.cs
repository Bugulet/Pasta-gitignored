using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [FMODUnity.EventRef] public string sfxEvent;

    public void Play()
    {
        FMODUnity.RuntimeManager.PlayOneShot(sfxEvent, GetComponent<Transform>().position);
    }
}