using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Text outcomeGame;
    public void Start()
    {
        outcomeGame.text =
            "Dear Alex, Today was a good day and here’s why, After Hazel got home from work, we spend the rest of the afternoon and evening together. We talked about my dad, it was nice to have someone to talk to about all this. We went to the latest Disney live action remake and went out for sushi after. Kind of felt like a date, maybe there’s something there that wasn’t there before… Sincerely, Me";
        //above is just for testing purposes, below would be what it'd be like.
        /*if (goodEnd) //the condition + the different end texts, ideally they'd be sprites instead of text
        {
            outcomeGame.text =
                "Dear Alex, Today was a good day and here’s why, After Hazel got home from work, we spend the rest of the afternoon and evening together. We talked about my dad, it was nice to have someone to talk to about all this. We went to the latest Disney live action remake and went out for sushi after. Kind of felt like a date, maybe there’s something there that wasn’t there before… Sincerely, Me";
        }
        else
        {
            outcomeGame.text =
                "Dear Alex, Today wasn’t a good day and here’s why, I had a panic attack, my mind went back to the day of the fire, the day my dad died. That’s how Hazel found me, she was really sweet and held me until the worst was over. I feel bad for ruining our day, though. I wish today could have ended differently, but I’m glad Hazel was there to support me, she’s a great friend. Sincerely, Me";
        }*/
    }
    public void BacktoMain()
    {
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene("Startscreen"); //out of the 2 options, this one is better
        Debug.Log("MAIN");
    }
    public void CreditsRoll()
    {
        Debug.Log("CREDITS");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
