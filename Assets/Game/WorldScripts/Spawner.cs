using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class Spawner : MonoBehaviour
{
    public static Action onSpawned;

    [SerializeField] private GameObject player;
    [SerializeField] private Spawn[] spawns;
    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        int number_spawn = UnityEngine.Random.Range(0, spawns.Length - 1);
        PhotonNetwork.Instantiate(player.name, spawns[number_spawn].position(), Quaternion.identity);

        onSpawned?.Invoke();
    }

}
