using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableText : MonoBehaviour
{

    [SerializeField] private int waitTime = 3;
    [SerializeField] private TextMeshPro hintText;

    private string message;
    private bool textStarted;
    private int messageIterator = 1;

    private void Start()
    {
        if (hintText != null)
        {
            message = hintText.text;
            hintText.enabled = false;
        }

        if (hintText == null)
        {
            throw new Exception("Message missing from " + gameObject.name);
        }
    }

    //start writing the text
    public void StartHint()
    {
        messageIterator = 0;
        textStarted = true;
        hintText.enabled = true;
        hintText.text = "";
    }

    //start deleting the text
    private void DeleteHint()
    {
        textStarted = false;
        totalTime = 0;
    }


    //total time since the text was completely written
    private float totalTime = 0;

    private void Update()
    {
        if (hintText != null)
        {
            if (textStarted)
            {
                if (message.Equals(hintText.text))
                {
                    if (totalTime >= waitTime)
                    {
                        DeleteHint();
                    }
                    else
                    {
                        totalTime += Time.deltaTime;
                    }
                }
                else
                {
                    hintText.SetText(message.Substring(0, messageIterator++));
                }
            }
            else
            {
                if (hintText.text.Length > 0)
                {
                    messageIterator--;
                    hintText.SetText(message.Substring(0, messageIterator));
                }
            }
        }

    }

}
