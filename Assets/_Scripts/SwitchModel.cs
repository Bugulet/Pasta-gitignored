using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchModel : MonoBehaviour
{
    [Tooltip("The object that will be spawned when the object will be changed")]
    [SerializeField] private GameObject DifferentObject;

    private Renderer _currentRenderer;
    private Collider _currentCollider;

    private void Start()
    {
        _currentRenderer = gameObject.GetComponent<Renderer>();
        _currentCollider = gameObject.GetComponent<BoxCollider>();
    }

    public void ChangeObject()
    {
        Instantiate(DifferentObject, transform.position, transform.rotation);

        _currentCollider.enabled = false;
        _currentRenderer.enabled = false;
        
        Debug.Log("Has Changed Object");
    }
}
