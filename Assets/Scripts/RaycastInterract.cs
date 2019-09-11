using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInterract : MonoBehaviour
{
    

    [SerializeField] private Canvas MainUI;

    //how much the anxiety level increases when looking at a bad memory 
    [SerializeField] private int AnxietyLevelIncrease = 10;

    //max distance for the player to be able to interract with objects
    [SerializeField] private float InterractionDistance;
    
    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        //check if it collided with something
        if (Physics.Raycast(transform.position,transform.forward, out hit,InterractionDistance))
        {
            //check if it is interractible
            if (hit.collider.CompareTag("Interractible") || hit.collider.CompareTag("Bad Memory"))
            {
                MainUI.GetComponent<MainUIManager>().ChangeObjectName(hit.collider.name);
                

                //check if interraction is started
                if (Input.GetMouseButtonDown(0))
                {
                    if(hit.collider.CompareTag("Interractible"))
                    {
                        hit.collider.GetComponent<EnableText>().StartHint();
                    }
                    else
                    {
                        hit.collider.GetComponent<EnableText>().StartHint();
                        FindObjectOfType<AnxietyManager>().IncreaseAnxiety(AnxietyLevelIncrease);
                    }
                    // Debug.Log("object: " + hit.collider.name + " hit at distance: "+hit.distance);
                }
            }
        }
        
        //if the collider does not exist or is not interractible, set the UI tip to blank
        if(hit.collider==null ||( !hit.collider.CompareTag("Interractible") && !hit.collider.CompareTag("Bad Memory")))
        {
            MainUI.GetComponent<MainUIManager>().ChangeObjectName("");
        }
    }
}
