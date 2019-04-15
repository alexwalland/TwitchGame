using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;

public class twitchInteraction : MonoBehaviour
{

    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;

    private string username;
    private string channelname;
    private string password;

    public GameObject player;
    public Weapon[] guns;
    public fistController fist;
    public knife knife;
    public bMove[] bullets;
    public AudioSource[] songs;
    public int difficulty = 1;

    void Start()
    {
        //set twitch details to playerprefs set in options menu
        username = PlayerPrefs.GetString("username");
        channelname = PlayerPrefs.GetString("username");
        password = PlayerPrefs.GetString("password");
        Connect();
    }

    void Update()
    { 
        PlayerPrefs.SetInt("difficulty", difficulty);
        ReadChat();
    }

    private void Connect()
    {
        twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        reader = new StreamReader(twitchClient.GetStream());
        writer = new StreamWriter(twitchClient.GetStream());

        writer.WriteLine("PASS " + password);
        writer.WriteLine("NICK " + username);
        writer.WriteLine("USER " + username + " 8*:" + username);
        writer.WriteLine("JOIN #" + channelname);
        writer.Flush();
    }

    private void ReadChat()
    {
        // seperate the messages from twitch into the message and chatname and send the message to part that changes the game
        if (twitchClient.Available > 0)
        {
            var message = reader.ReadLine();

            if (message.Contains("PRIVMSG"))
            {
                var splitPoint = message.IndexOf("!", 1);
                var chatName = message.Substring(0, splitPoint);
                chatName = chatName.Substring(1);

                splitPoint = message.IndexOf(":", 1);
                message = message.Substring(splitPoint + 1);


                GameInputs(message);
            }
        }
    }

    private void GameInputs(string ChatInputs)
    {
        if (ChatInputs.ToLower() == "1")
        {
            fist.selectWeapon(1);
        }
        if (ChatInputs.ToLower() == "2")
        {
            fist.selectWeapon(2);
        }
        if (ChatInputs.ToLower() == "3")
        {
            fist.selectWeapon(3);
        }
        if (ChatInputs.ToLower() == "4")
        {
            fist.selectWeapon(4);
        }
        if (ChatInputs.ToLower() == "0")
        {
            fist.selectWeapon(0);
        }
        if (ChatInputs.ToLower() == "heal")
        {
            player.GetComponent<PlayerController>().health = player.GetComponent<PlayerController>().dHealth;
        }
        if (ChatInputs.ToLower() == "nerf")
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i].damage > 10)
                {
                    bullets[i].damage = 10;
                }
            }
        }
        if (ChatInputs.ToLower() == "buff")
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i].damage < 20)
                {
                    bullets[i].damage = 20;
                }
            }
            knife.damage = 15;
            fist.damage = 12;
        }
        if (ChatInputs.ToLower() == "extend")
        {
            fist.speed = 3;
        }
        if (ChatInputs.ToLower() == "fast")
        {
            player.GetComponent<PlayerController>().speed = player.GetComponent<PlayerController>().initialSpeed * 1.5f;
        }
        if (ChatInputs.ToLower() == "slow")
        {
            player.GetComponent<PlayerController>().speed = player.GetComponent<PlayerController>().initialSpeed * 0.5f;
        }
        if (ChatInputs.ToLower() == "burst rifle")
        {
            guns[2].fireRate = 3;
        }
        if (ChatInputs.ToLower() == "more health")
        {
            player.GetComponent<PlayerController>().health *= 1.5f;
            player.GetComponent<PlayerController>().dHealth *= 1.5f;
        }
        if (ChatInputs.ToLower() == "less health")
        {
            player.GetComponent<PlayerController>().health *= 0.5f;
            player.GetComponent<PlayerController>().dHealth *= 0.5f;
        }
        if (ChatInputs.ToLower() == "reset")
        {
            player.GetComponent<PlayerController>().dHealth = 100f;
            player.GetComponent<PlayerController>().speed = player.GetComponent<PlayerController>().initialSpeed;
            knife.damage = 8;
            fist.damage = 6;
            guns[2].fireRate = guns[2].initialFireRate;
            Time.timeScale = 1;
        }
        if (ChatInputs.ToLower() == "song1")
        {
            for (int i = 0; i < songs.Length; i++)
            {
                songs[i].Stop();
            }
            songs[0].Play();
        }

        if (ChatInputs.ToLower() == "song2")
        {
            for (int i = 0; i < songs.Length; i++)
            {
                songs[i].Stop();
            }
            songs[1].Play();
        }
        if (ChatInputs.ToLower() == "song3")
        {
            for (int i = 0; i < songs.Length; i++)
            {
                songs[i].Stop();
            }
            songs[2].Play();
        }
        if (ChatInputs.ToLower() == "song4")
        {
            for (int i = 0; i < songs.Length; i++)
            {
                songs[i].Stop();
            }
            songs[3].Play();
        }
        if (ChatInputs.ToLower() == "song5")
        {
            for (int i = 0; i < songs.Length; i++)
            {
                songs[i].Stop();
            }
            songs[4].Play();
        }
        if (ChatInputs.ToLower() == "song6")
        {
            for (int i = 0; i < songs.Length; i++)
            {
                songs[i].Stop();
            }
            songs[5].Play();
        }
        if (ChatInputs.ToLower() == "song7")
        {
            for (int i = 0; i < songs.Length; i++)
            {
                songs[i].Stop();
            }
            songs[6].Play();
        }
        if (ChatInputs.ToLower() == "easier")
        {
            if (difficulty > 1 )
            {
                difficulty--;
            }
        }
        if (ChatInputs.ToLower() == "harder")
        {
            if (difficulty < 3)
            {
                difficulty++;
            }
        }
        if (ChatInputs.ToLower() == "slower")
        {
            Time.timeScale = 0.5f;
        }
        if (ChatInputs.ToLower() == "faster")
        {
            Time.timeScale = 1.5f;
        }
    }
}