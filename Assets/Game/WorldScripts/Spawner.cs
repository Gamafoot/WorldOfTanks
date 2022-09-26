using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class Spawner : MonoBehaviour
{
    public static Action onSpawned;

    [SerializeField] private GameObject prefubPlayer;
    [SerializeField] private Spawn[] spawns;
    [SerializeField] private float coolDown;

    private void Start()
    {
        StartCoroutine(SpawnPlayer());
    }

    private IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(coolDown);

        int number_spawn;

        while (true)
        {
            number_spawn = UnityEngine.Random.Range(0, spawns.Length - 1);

            if (spawns[number_spawn].isSpawnFree)
            {
                break;
            }
        }
        PhotonNetwork.Instantiate(prefubPlayer.name, spawns[number_spawn].position(), Quaternion.identity);
        onSpawned?.Invoke();
    }

}
