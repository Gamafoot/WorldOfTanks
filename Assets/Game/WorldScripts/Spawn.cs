using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Spawn : MonoBehaviour
{
    public bool isSpawnFree;

    private void Start()
    {
        isSpawnFree = true;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        isSpawnFree = false;
    }

    private void OnTriggerExit(Collider other)
    {
        isSpawnFree = true;
    }
}
