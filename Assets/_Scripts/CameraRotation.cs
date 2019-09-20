using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] [Range(-1,1)] private float rotationSpeed;
    void Update () {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
    }
}