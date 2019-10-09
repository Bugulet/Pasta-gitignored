using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rename : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.Contains("Clone"))
        {
            gameObject.name = gameObject.name.Substring(0, gameObject.name.Length - 7);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
