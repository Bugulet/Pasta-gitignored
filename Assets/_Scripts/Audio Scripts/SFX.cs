using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [FMODUnity.EventRef] public string sfxEvent;

    private bool _isPlaying = false;

    [SerializeField] private float clipLength;
    private void Start()
    {
        
    }

    public void Play()
    {
        if (_isPlaying == false)
        {
            FMODUnity.RuntimeManager.PlayOneShot(sfxEvent, GetComponent<Transform>().position);
            _isPlaying = true;
            WaitForEnd(clipLength);
        }
    }

    private IEnumerator WaitForEnd(float length)
    {
        length = clipLength;
        yield return new WaitForSeconds(length);
        _isPlaying = false;
    }
    
}