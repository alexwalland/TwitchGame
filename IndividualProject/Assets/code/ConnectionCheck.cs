using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ConnectionCheck : MonoBehaviour
{
    public RawImage connector;

    void Update()
    {
        if (PlayerPrefs.GetInt("online") == 1)
        {
            connector.color = Color.green;
        }
    }
}
