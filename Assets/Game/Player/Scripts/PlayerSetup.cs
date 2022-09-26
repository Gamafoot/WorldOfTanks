using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerSetup : MonoBehaviour
{
    public static Action<GameObject> onFoundPlayer;

    public GameObject player;
    public FixedJoystick joystick;
    public Image healthImage;

    private void OnEnable()
    {
        Spawner.onSpawned += FindPlayer;
    }

    private void OnDisable()
    {
        Spawner.onSpawned -= FindPlayer;
    }

    private void FindPlayer()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            onFoundPlayer?.Invoke(player);
        }
    }
}
