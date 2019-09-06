using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnxietyFeedback : MonoBehaviour
{

     private Image image;
    [SerializeField] private AnxietyManager manager;

    private Color newColor;
    
    // Update is called once per frame
    private void Start()
    {
        image = GetComponent<Image>();
        newColor = image.color;
    }

    void Update()
    {
        newColor.a = manager.GetAnxiety()/100f;
        image.color = newColor;
    }
}
