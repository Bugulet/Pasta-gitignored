using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyCamera : MonoBehaviour
{
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject fireCam;
    private void Start()
    {
        if (playerCam == null || fireCam == null)
        {
            throw new Exception("Camera missing from " + gameObject.name);
        }
    }

    private void Update()
    {
        float camX = playerCam.transform.eulerAngles.x;
        float camY = playerCam.transform.eulerAngles.y;
        float camZ = playerCam.transform.eulerAngles.z;
        fireCam.transform.eulerAngles = new Vector3(camX, camY, camZ);
    }
}
