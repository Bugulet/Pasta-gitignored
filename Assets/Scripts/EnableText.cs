using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableText : MonoBehaviour
{

    [SerializeField] private TextMeshPro hintText;

    private string message;
    private bool IsInside;
    private int messageIterator = 1;

    private void Start()
    {
        if (hintText != null)
        {
            message = hintText.text;
            hintText.enabled = false;
        }
    }

    public void StartHint()
    {
        messageIterator = 1;
        IsInside = true;
        hintText.enabled = true;
        hintText.text = "";
    }

    private void DeleteHint()
    {
        IsInside = false;
        totalTime = 0;
    }

    int waitTime = 3;
    float totalTime = 0;

    private void Update()
    {
        if (hintText != null)
        {
            if (IsInside)
            {
                if (!message.Equals(hintText.text))
                {
                    hintText.SetText(message.Substring(0, messageIterator++));
                }
                else
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
            }
            else
            {
                if (hintText.text.Length > 0)
                {
                    hintText.SetText(message.Substring(0, messageIterator--));
                }
            }
        }
    }

}
