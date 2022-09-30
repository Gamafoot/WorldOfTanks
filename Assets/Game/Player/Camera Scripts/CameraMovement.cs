using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera settings")]

    [Tooltip("Скорость перемещения камеры")]
    [SerializeField] private float speed;

    [Tooltip("Скорость плавности перемещения")]
    [SerializeField] private float smoothSpeed;

    private void Update()
    {
        if (PlayerComponents.player != null)
        {
            PlayerCameraMovement(PlayerComponents.player.transform, speed, smoothSpeed);
        }
    }

    private void PlayerCameraMovement(Transform target, float speed, float smoothSpeed){
        // Метод для плавного перемещения камеры за игроком

        Vector3 from = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 to = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = Vector3.Lerp(from, to, smoothSpeed * speed * Time.deltaTime);
    }
}
