using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastInterract : MonoBehaviour
{
    [SerializeField] private Canvas MainUI;

    [Tooltip("How much the anxiety level increases when looking at a bad memory")]
    [SerializeField] private int AnxietyLevelIncrease = 25;

    [Tooltip("Max distance for the player to be able to interract with objects")]
    [SerializeField] private float InterractionDistance;
    MainUIManager nameChange;
    private RaycastHit hit;

    [Space]
    [Header("Flashback Room Properties")]
    [SerializeField] private RawImage fireCamera;

    private void Start()
    {
        nameChange = MainUI.GetComponent<MainUIManager>();
        nameChange.ChangeObjectName("");
    }
    
    void Update()
    {
        //check if it collided with something
        if (Physics.Raycast(transform.position,transform.forward, out hit,InterractionDistance))
        {
            //Debug.Log(hit.collider.tag);
            //check if it is interractible
            if (hit.collider.CompareTag("Interractible") || hit.collider.CompareTag("Bad Memory"))
            {
               // Debug.Log(hit.collider.name);
                string name = hit.collider.name;
                
                nameChange.ChangeObjectName(name);

                //check if interraction is started
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.collider.GetComponent<InteractWithObject>() != null)
                    {
                        hit.collider.GetComponent<InteractWithObject>().Interact();
                        if (hit.collider.CompareTag("Bad Memory"))
                        {
                            StartCoroutine(ImageFadeIn());
                            
                            StartCoroutine(ImageFadeOut());
                        }
                        
                    }

                    if (hit.collider.GetComponent<EnableText>() != null)
                    {
                        hit.collider.GetComponent<EnableText>().StartHint();
                    }

                    if (hit.collider.CompareTag("Bad Memory"))
                    {
                        FindObjectOfType<AnxietyManager>().IncreaseAnxiety(AnxietyLevelIncrease);
                    }
                    //else
                    //{
                    //    if (hit.collider.GetComponent<InteractWithObject>() != null)
                    //    {
                    //        hit.collider.GetComponent<InteractWithObject>().Interact();
                    //    }
                    //}
                    // Debug.Log("object: " + hit.collider.name + " hit at distance: "+hit.distance);
                    if (hit.collider.GetComponent<SFX>() != null)
                    {
                        hit.collider.GetComponent<SFX>().Play();
                    }
                }
            }

            //if the collider does not exist or is not interractible, set the UI tip to blank
            if (hit.collider == null || (!hit.collider.CompareTag("Interractible") && !hit.collider.CompareTag("Bad Memory")))
            {
                // Debug.Log("pula mea");
                MainUI.GetComponent<MainUIManager>().ChangeObjectName("");
            }
        }

        IEnumerator ImageFadeIn()
        {
            for (float f = 0.05f; f <= 1; f += 0.05f)
            {
                Color c = fireCamera.material.color;
                c.a = f;
                fireCamera.material.color = c;
                yield return new WaitForSeconds(0.05f);
            }
        }

        IEnumerator ImageFadeOut()
        {
            for (float f = 1.0f; f >= -0.05f; f -= 0.05f)
            {
                Color c = fireCamera.color;
                c.a = f;
                fireCamera.color = c;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
