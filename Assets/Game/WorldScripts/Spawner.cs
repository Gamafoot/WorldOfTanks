using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefubPlayer;
    [SerializeField] private Spawn[] spawns;
    [SerializeField] private float spawnTime;
    [SerializeField] private float respawnTime;

    private void Start()
    {
        StartCoroutine(IESpawnPlayer());
    }

    public void RespawnPlayer(GameObject respawnPlayer)
    {
        StartCoroutine(IERepawnPlayer(respawnPlayer));
    }

    private int GetIndexFreeSpawn()
    {
        int spawnIndex;

        while (true)
        {
            spawnIndex = Random.Range(0, spawns.Length - 1);

            if (spawns[spawnIndex].isSpawnFree)
            {
                break;
            }
        }

        return spawnIndex;
    }

    private IEnumerator IESpawnPlayer()
    {
        yield return new WaitForSeconds(spawnTime);

        int spawnIndex = GetIndexFreeSpawn();

        GameObject player = PhotonNetwork.Instantiate(prefubPlayer.name, spawns[spawnIndex].GetPosition(), Quaternion.identity);
        PlayerComponents.player = player;
    }

    private IEnumerator IERepawnPlayer(GameObject respawnPlayer)
    {
        yield return new WaitForSeconds(respawnTime);

        int spawnIndex = GetIndexFreeSpawn();

        Vector3 spawnPosition = spawns[spawnIndex].GetPosition();

        respawnPlayer.transform.position = new Vector3(spawnPosition.x, respawnPlayer.transform.position.y, spawnPosition.z);
        respawnPlayer.SetActive(true);
    }
}
