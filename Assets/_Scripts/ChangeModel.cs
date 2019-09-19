using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModel : MonoBehaviour
{

    [Tooltip("The object that will be spawned when the object will be changed")]
    [SerializeField] private GameObject DifferentObject;

    [Tooltip("The index of the interaction so they happen in order")]
    [SerializeField] private int InteractionNumber = 0;

    private InteractionManager manager;

    private void Start()
    {
        manager = FindObjectOfType<InteractionManager>();
    }

    public void ChangeObject()
    {
        if (manager.CheckInteraction(InteractionNumber))
        {
            Instantiate(DifferentObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
