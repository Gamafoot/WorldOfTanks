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


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        AbsoluteMovePlayer(speedMovement);
        AbsoluteRotatePlayerTest();
    }

    private void AbsoluteMovePlayer(float speed){
        moveDirection = Vector3.forward * Input.GetAxis("Vertical") * speed;
        moveDirection += Vector3.right * Input.GetAxis("Horizontal") * speed;
        characterController.Move(moveDirection*Time.deltaTime);
    }

    private void AbsoluteRotatePlayerTest(){
        if (Input.GetAxis("Vertical") > 0){
            rotateDirection = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetAxis("Vertical") < 0){
            rotateDirection = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetAxis("Horizontal") > 0){
            rotateDirection = Quaternion.Euler(0, 90, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0){
            rotateDirection = Quaternion.Euler(0, -90, 0);
        }

        transform.localRotation = Quaternion.Lerp(transform.localRotation, rotateDirection, smoothRotate * Time.deltaTime);
    }
}
