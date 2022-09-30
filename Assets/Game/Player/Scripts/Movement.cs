using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviour
{
    [Header("Player settigns")]
    [SerializeField] private float speedMovement;
    [SerializeField] private float speedRotate;
    [SerializeField] private float smoothRotate;

    // Player references
    private FixedJoystick joystick;
    private CharacterController characterController;

    //Направление игрока
    private Vector3 moveDirection = Vector3.zero;
    //Падание/Гравитация игрока
    private Vector3 velocity;

    // Переменные для быстрого и удобного написания кода
    private float vertical = 0;
    private float horizontal = 0;

    PhotonView photonView;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        joystick = PlayerComponents.joystick;
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (!photonView.IsMine)
            return;

        vertical = joystick.Vertical;
        horizontal = joystick.Horizontal;

        AbsoluteMovePlayer(speedMovement);
    }

    private void AbsoluteMovePlayer(float speed){
        // Метод для абсолютного движения игрока

        moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        if (moveDirection.magnitude >= 0.1f){
            RotatePlayer();
            characterController.Move(moveDirection*speed*Time.deltaTime);
        }
    }

    private void RotatePlayer(){
        // Метод поворота игрока

        float rotationAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, rotationAngle, 0), smoothRotate*Time.deltaTime);
    }
}
