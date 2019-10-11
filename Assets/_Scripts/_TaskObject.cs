using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class _TaskObject : MonoBehaviour
{
    private _TaskManager _manager;
    
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

        if (differentObject == null)
            return;
        
        if (changesModel)
        {
            Instantiate(differentObject, transform.position, transform.rotation);
            
            transform.gameObject.SetActive(false);
        }
    }
}
