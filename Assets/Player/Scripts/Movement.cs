using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Player settigns")]
    [SerializeField] private float speedMovement;
    [SerializeField] private float speedRotate;
    [SerializeField] private float smoothRotate;

    [Header("Player references")]
    [SerializeField] private FixedJoystick joystick;
    private CharacterController characterController;

    //Направление игрока
    private Vector3 moveDirection = Vector3.zero;
    // Поворот игрока
    private Quaternion rotateDirection = Quaternion.identity;

    // Переменные для быстрого и удобного написания кода
    private float vertical = 0;
    private float horizontal = 0;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
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
