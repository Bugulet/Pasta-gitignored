using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _TaskManager : MonoBehaviour
{
    private int _currentObjective;
    [SerializeField] private int maxObjective = 4;
    private FMOD.Studio.Bus _masterBus;

    private void Start()
    {
        _masterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
    }
    
    // if object has task object script, current objective ++, do action of changing model on the respective stuff, erase name

    public void Task()
    {
        _currentObjective++;

        Debug.Log("Current task: " + _currentObjective);
    }
    
    void Update()
    {
        //Debug.Log("Current Objective " + CurrentObjective);
        if (_currentObjective == maxObjective)
        {
            SceneManager.LoadScene("_Good_End");
            
            _masterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
