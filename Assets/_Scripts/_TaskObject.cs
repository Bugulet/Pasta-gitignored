using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class _TaskObject : MonoBehaviour
{
    private _TaskManager _manager;
    
    [SerializeField] private RawImage currentTask;
    
    [SerializeField] private GameObject differentObject;

    private Renderer _currentRenderer;
    private Collider _currentCollider;

    [SerializeField] private bool changesModel = false;

    // Start is called before the first frame update
    private void Start()
    {
        _manager = FindObjectOfType<_TaskManager>();
        _currentRenderer = gameObject.GetComponent<Renderer>();
        _currentCollider = gameObject.GetComponent<BoxCollider>();

        if (currentTask == null)
        {
            throw new Exception("Current task image is missing from " + gameObject.name);
        }

        if (changesModel && differentObject == null)
        {
            throw new Exception("Different Object missing from " + gameObject.name);
        }
    }

    public void TaskInteraction()
    {
        _manager.Task();

        currentTask.enabled = true;

        if (differentObject == null)
            return;
        
        if (changesModel)
        {
            Instantiate(differentObject, transform.position, transform.rotation);
            
            transform.gameObject.SetActive(false);
        }
    }
}
