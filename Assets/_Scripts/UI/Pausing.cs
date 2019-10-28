using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausing : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private FMOD.Studio.Bus _masterBus;
    private bool _isPaused = false;

    [SerializeField] private PlayerMovement mover;
    [SerializeField] private LookatMouse seer;
    
    private void Start()
    {
        if (pauseMenu == null)
        {
            throw new Exception("Pause menu not inserted in " + gameObject.name);
        }
        _masterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _isPaused = !_isPaused;

        if (_isPaused)
            ActivatePause();

        if (!_isPaused)
            DisablePause();
    }

    private void ActivatePause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        mover.enabled = false;
        seer.enabled = false;
    }

    private void DisablePause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        mover.enabled = true;
        seer.enabled = true;
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("_Main_Menu");
        _masterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Time.timeScale = 1;
    }

    public void Continue()
    {
        _isPaused = false;
    }
}
