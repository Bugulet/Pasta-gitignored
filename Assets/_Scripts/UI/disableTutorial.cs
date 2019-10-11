using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableTutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutParent;

    private void OnTriggerEnter(Collider other)
    {
        tutParent.SetActive(false);
    }
}