using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerClass : MonoBehaviour
{
    [HideInInspector] public GameObject player;
    private void OnEnable()
    {
        PlayerSetup.onFoundPlayer += GetPlayer;
    }

    private void OnDisable()
    {
        PlayerSetup.onFoundPlayer -= GetPlayer;
    }

    public void GetPlayer(GameObject player)
    {
        this.player = player;
    }
}
