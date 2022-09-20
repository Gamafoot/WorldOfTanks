using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera settings")]
    [SerializeField] private float speed;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Transform player;

    private void Update()
    {
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(player.position.x, transform.position.y, player.position.z), smoothSpeed * speed * Time.deltaTime);
    }
}
