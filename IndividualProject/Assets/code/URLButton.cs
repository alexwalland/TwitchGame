using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLButton : MonoBehaviour
{
    public void GetOAuthCode()
    {
        Application.OpenURL("https://twitchapps.com/tmi/");
        Debug.Log("working");
    }
}
