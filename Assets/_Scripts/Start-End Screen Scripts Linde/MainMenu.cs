using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("_Game");
        //SceneManager.LoadScene("level"); //out of the 2 options, this one is better
        Debug.Log("Start loaded");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        Debug.Log("Credits Loaded");
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    
    public void Main()
    {
        SceneManager.LoadScene("_Main_Menu");
        Debug.Log("Main Menu");
    }
}