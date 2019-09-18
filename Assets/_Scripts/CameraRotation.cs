using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {
    
    void Update () {
        transform.Rotate(0, -0.25f, 0, Space.World);
    }
}