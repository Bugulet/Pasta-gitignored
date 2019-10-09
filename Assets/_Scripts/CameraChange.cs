using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraChange : MonoBehaviour
{

    [Header("Game cameras")]
    [Space]


    [SerializeField] private Camera BedCamera;
    
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private GameObject fireRoom;

    [Space]
    
    [SerializeField] private TextMeshPro RMBInstruction;
    [SerializeField] private TextMeshPro LMBInstruction;

    [Header("Game UIs")]
    [Space]

    [SerializeField] private Canvas NormalUI;
    [SerializeField] private Canvas BedUI;

    [Header("Anxiety manager")]
    [Space]

    [SerializeField] private AnxietyManager manager;

    [Header("Rotations")] 
    [SerializeField] private GameObject player;
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
            BedUI.enabled = true;

            PlayerCamera.enabled = false;
            player.SetActive(false);
            NormalUI.enabled = false;
            fireRoom.SetActive(false);
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
                BedUI.enabled = false;
                RMBInstruction.enabled = false;
                LMBInstruction.enabled = false;
                
                player.SetActive(true);
                PlayerCamera.enabled = true;
                NormalUI.enabled = true;
                fireRoom.SetActive(true);
            }

            if (Input.GetMouseButtonDown(1) && !PlayerCamera.enabled)
            {
                manager.IncreaseAnxiety(40);
            }
        }
        
        if (Input.GetMouseButtonDown(0) && !PlayerCamera.enabled)
        {
            RMBInstruction.text = "Press right click to snooze...";
            LMBInstruction.fontSize -= 1;
            PTSDCount++;
        }
    }
}
