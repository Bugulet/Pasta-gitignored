using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInterract : MonoBehaviour
{
    [SerializeField] private Canvas MainUI;

    [Tooltip("How much the anxiety level increases when looking at a bad memory")]
    [SerializeField] private int AnxietyLevelIncrease = 10;

    [Tooltip("Max distance for the player to be able to interract with objects")]
    [SerializeField] private float InterractionDistance;
    
    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        //check if it collided with something
        if (Physics.Raycast(transform.position,transform.forward, out hit,InterractionDistance))
        {
            //check if it is interractible
            if (hit.collider.CompareTag("Interractible") || hit.collider.CompareTag("Bad Memory") || hit.collider.CompareTag("InterractObjects"))
            {
                var nameChange = MainUI.GetComponent<MainUIManager>();
                nameChange.ChangeObjectName(hit.collider.name);

                //check if interraction is started
                if (Input.GetMouseButtonDown(0))
                {
                    if(hit.collider.CompareTag("Interractible"))
                    {
                        if(hit.collider.GetComponent<EnableText>()!=null)
                        {
                            hit.collider.GetComponent<EnableText>().StartHint();
                        }
                        else
                        {
                            Debug.Log("Enable text component not added");
                        }
                    }
                    else if(hit.collider.CompareTag("Bad Memory"))
                    {
                        if (hit.collider.GetComponent<EnableText>() != null)
                        {
                            hit.collider.GetComponent<EnableText>().StartHint();
                        }
                        FindObjectOfType<AnxietyManager>().IncreaseAnxiety(AnxietyLevelIncrease);
                    }
                    else
                    {
                        if (hit.collider.GetComponent<InteractWithObject>() != null)
                        {
                            hit.collider.GetComponent<InteractWithObject>().Interact();
                        }
                    } 
                    if (hit.collider.GetComponent<SFX>() != null)
                    {
                        hit.collider.GetComponent<SFX>().Play();
                    }
                    // Debug.Log("object: " + hit.collider.name + " hit at distance: "+hit.distance);
                }
            }
        }
        
        //if the collider does not exist or is not interractible, set the UI tip to blank
        if(hit.collider==null ||( !hit.collider.CompareTag("Interractible") && !hit.collider.CompareTag("Bad Memory") && !hit.collider.CompareTag("InterractObjects")))
        {
            MainUI.GetComponent<MainUIManager>().ChangeObjectName("");
        }
    }
}
