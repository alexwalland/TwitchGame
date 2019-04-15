using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    void Start()
    {
        PlayerPrefs.SetInt("online", 0);
        PlayerPrefs.SetFloat("sfxV", 1.0f);
        PlayerPrefs.SetFloat("mV", 1.0f);
        PlayerPrefs.SetString("username", "null");
        PlayerPrefs.SetString("password", "null");
    }

    public void PlayGame()
    {
        //check to see if connected to determine whether the twitch or offline level is needed
        if (PlayerPrefs.GetInt("offline") == 0)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeVFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("sfxV", volume);
    }

    public void ChangeMusixVolume(float volume)
    {
        PlayerPrefs.SetFloat("mV", volume);
    }

    public void GetUserName(string username)
    {
        PlayerPrefs.SetString("username", username);
    }

    public void GetPassword(string AOuth)
    {
        PlayerPrefs.SetString("password", AOuth);
    }
}
