using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [FMODUnity.EventRef] 
    public string inputSound;

    private bool playerIsMoving;
    
    [SerializeField]
    private float walkingSpeed;

    private void Start()
    {
        InvokeRepeating(nameof(CallFootsteps), 0, walkingSpeed);
    }
    private void Update()
    {
        if (Input.GetAxis("Vertical") >= 0.01f
            || Input.GetAxis("Vertical") <= -0.01f
            || Input.GetAxis("Horizontal") >= 0.01f
            || Input.GetAxis("Horizontal") <= -0.01f)
        {
            playerIsMoving = true;
        } else if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0)
        {
            playerIsMoving = false;
        }
    }

    private void CallFootsteps()
    {
        if (playerIsMoving == true)
        {
            //Debug.Log("Player movement is making noise");
            FMODUnity.RuntimeManager.PlayOneShot(inputSound);
        }
    }

    private void OnDisable()
    {
        playerIsMoving = false;
    }
}
