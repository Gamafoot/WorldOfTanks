using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class Spawner : MonoBehaviourPun
{
    [SerializeField] private GameObject prefubPlayer;
    [SerializeField] private Spawn[] spawns;
    [SerializeField] private float spawnTime;
    [SerializeField] private float respawnTime;

    private void Start()
    {
        StartCoroutine(IESpawnPlayer());
    }

    public Vector3 GetFreeSpawn()
    {
        int spawnIndex;

        while (true)
        {
            spawnIndex = UnityEngine.Random.Range(0, spawns.Length - 1);

            if (spawns[spawnIndex].isSpawnFree)
            {
                break;
            }
        }

        return spawns[spawnIndex].GetPosition();
    }

    private IEnumerator IESpawnPlayer()
    {
        yield return new WaitForSeconds(spawnTime);

        GameObject createdPlayer = PhotonNetwork.Instantiate(prefubPlayer.name, GetFreeSpawn(), Quaternion.identity);
        PlayerComponents.player = createdPlayer;
    }
}
