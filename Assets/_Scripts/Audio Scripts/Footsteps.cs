using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [FMODUnity.EventRef] 
    public string inputSound;

    private bool playerIsMoving;

    [SerializeField] private Rigidbody playerSpeed; 
    
    [SerializeField]
    private float walkingSpeed;

    private void Start()
    {
        InvokeRepeating(nameof(CallFootsteps), 0, walkingSpeed);
    }
    private void Update()
    {
        if (playerSpeed.velocity.magnitude > 1.0f)
        {
            playerIsMoving = true;
        } else if (playerSpeed.velocity.magnitude <= 1.0f)
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
