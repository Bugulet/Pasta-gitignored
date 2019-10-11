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
    
    [SerializeField] private float walkingSpeed;

    private PlayerMovement _isMoving;

    private void Start()
    {
        InvokeRepeating(nameof(CallFootsteps), 0, walkingSpeed);
        _isMoving = FindObjectOfType<PlayerMovement>();
    }
    
    private void Update()
    {
        if (_isMoving.MovementGetter())
        {
            playerIsMoving = true;
        }

        if (!_isMoving.MovementGetter())
        {
            playerIsMoving = false;
        }
        
        /*
        if (playerSpeed.velocity.magnitude > 0.01f)
        {
            playerIsMoving = true;
        }
        else
        {
            playerIsMoving = false;
        }

        
        else if (playerSpeed.velocity.magnitude <= 0.1f)
        {
            playerIsMoving = false;
        }
        */
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
