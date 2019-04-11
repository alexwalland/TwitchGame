using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            Show();
        }
    }

    private void Show()
    {
        pauseMenu.SetActive(true);
    }

    public void Unpause()
    {
         Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void ChangeVFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("sfxV", volume);
    }

    public void ChangeMusixVolume(float volume)
    {
        PlayerPrefs.SetFloat("mV", volume);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
