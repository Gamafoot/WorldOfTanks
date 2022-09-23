using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera settings")]

    [Tooltip("Скорость перемещения камеры")]
    [SerializeField] private float speed;

    [Tooltip("Скорость плавности перемещения")]
    [SerializeField] private float smoothSpeed;

    [Tooltip("Цель за которой будет летать камера")]
    [SerializeField] private Transform player;

    private void Update()
    {
        PlayerCameraMovement(speed, smoothSpeed);
    }

    private void PlayerCameraMovement(float smooth, float smoothSpeed){
        // Метод для плавного перемещения камеры за игроком

        Vector3 from = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 to = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.position = Vector3.Lerp(from, to, smoothSpeed * speed * Time.deltaTime);
    }
}
