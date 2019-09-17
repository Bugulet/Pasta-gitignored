using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerText : MonoBehaviour
{
    public GameObject player;
    public Transform textPosition;

    private float _textX;
    private float _textY; // Don't want to change the current Y rotation
    private float _textZ;
    private void Start()
    {
        if (player == null) { throw new Exception("Please attach the player to " + gameObject.name); }
        if (textPosition == null) { Debug.Log("TextPosition has not been assigned to " + gameObject.name); }
    }

    private void Update()
    {
        var eulerAngles = player.transform.eulerAngles;
        _textX = eulerAngles.x;
        _textY = eulerAngles.y;
        _textZ = eulerAngles.z;

        transform.eulerAngles = new Vector3(_textX - _textX, _textY, _textZ - _textZ);
    }
}
