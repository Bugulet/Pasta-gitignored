using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPlayerPos : MonoBehaviour
{
    [SerializeField] private GameObject playerPos;
    [SerializeField] private GameObject dupePlayer;
    private void Start()
    {
    }

    private void Update()
    {
        dupePlayer.transform.position = new Vector3(playerPos.transform.position.x, playerPos.transform.position.y,
            (playerPos.transform.position.z + 100));
    }
}
