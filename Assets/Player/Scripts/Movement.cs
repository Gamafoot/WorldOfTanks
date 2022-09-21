using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Player settigns")]
    [SerializeField] private float speedMovement;
    [SerializeField] private float speedRotate;
    [SerializeField] private float smoothRotate;

    private Vector3 moveDirection = Vector3.zero;
    private Quaternion rotateDirection = Quaternion.identity;
    private bool can_change_direction;
    private CharacterController characterController;

    float vertical = 0;
    float horizontal = 0;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        AbsoluteMovePlayer(speedMovement);
    }

    private void AbsoluteMovePlayer(float speed){
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        if (moveDirection.magnitude >= 0.1f){
            RotatePlayer();
            characterController.Move(moveDirection*speed*Time.deltaTime);
        }
    }

    private void RotatePlayer(){
        float rotationAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, rotationAngle, 0), smoothRotate*Time.deltaTime);
    }
}
