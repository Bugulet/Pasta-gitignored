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
