﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;

public class TwitchTest : MonoBehaviour
{
    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;

    private string username;
    private string channelname;
    private string password;

    public void Update()
    {
        username = PlayerPrefs.GetString("username");
        channelname = PlayerPrefs.GetString("username");
        password = PlayerPrefs.GetString("password");
    }

    public void Connect()
    {
        //makes sure that we have a password and username
        if (username == "null" || password == "null")
        {
            //dont connect
        }
        else
        {
            twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
            reader = new StreamReader(twitchClient.GetStream());
            writer = new StreamWriter(twitchClient.GetStream());

            writer.WriteLine("PASS " + password);
            writer.WriteLine("NICK " + username);
            writer.WriteLine("USER " + username + " 8*:" + username);
            writer.WriteLine("JOIN #" + channelname);
            writer.Flush();

            if (twitchClient.Connected)
            {
                PlayerPrefs.SetInt("online", 1);
            }
            else
            {
                PlayerPrefs.SetInt("online", 0);
            }
        }
    }
}
