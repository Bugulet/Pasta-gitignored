using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private Camera BedCamera;
    [SerializeField] private Camera PlayerCamera;

    [SerializeField] private bool PTSDMode = false;
    [SerializeField] private Text RMBInstruction;
    [SerializeField] private Text LMBInstruction;
    [SerializeField] private AnxietyManager manager;

    void Start()
    {
        if (!BedCamera || !PlayerCamera)
        {
            Debug.Log("CAMERA NOT SET PROPERLY FOR CAMERA CHANGER");
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            //keep the bed camera
            BedCamera.enabled = true;
            PlayerCamera.enabled = false;
            
        }
    }

    private int PTSDCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (PTSDCount >= 1)
        {
            if (Input.GetMouseButtonDown(0) && !PlayerCamera.enabled)
            {
                //change camera
                BedCamera.enabled = false;
                PlayerCamera.enabled = true;
                
            }

            if (Input.GetMouseButtonDown(1) && !PlayerCamera.enabled)
            {
                //34 so you can press up to 3 times
                manager.IncreaseAnxiety(34);
            }
        }

        if (Input.GetMouseButtonDown(0) && !PlayerCamera.enabled)
        {
            if (!PTSDMode)
            {
                //change camera
                BedCamera.enabled = false;
                PlayerCamera.enabled = true;
                
            }
            else
            {
                RMBInstruction.text = "Press right click to snooze...";
                LMBInstruction.fontSize = LMBInstruction.fontSize - 4;
                PTSDCount++;
            }
        }

        
    }
}
