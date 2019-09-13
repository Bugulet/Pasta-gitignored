using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModel : MonoBehaviour
{

    [SerializeField] GameObject DifferentObject;

    public void ChangeObject()
    {
        
        Instantiate(DifferentObject,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
