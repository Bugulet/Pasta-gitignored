using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    
    [SerializeField] GameTime[] MessageTimes;

    private AnxietyCounter counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = FindObjectOfType<AnxietyCounter>();
    }

    // Update is called once per frame
    public void CheckTimes()
    {
        
        for (int i = 0; i < MessageTimes.Length; i++)
        {
           
            GameTime g = MessageTimes[i];
            
            if (counter.GetTime().hour==g.hour && counter.GetTime().minutes == g.minutes)
            {
                Debug.Log("yaasss" + g.minutes + "        " + counter.GetTime().minutes);
            }
            
        }
    }
}
