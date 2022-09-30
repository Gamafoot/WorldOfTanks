using UnityEngine;
using UnityEngine.UI;

public class PlayerComponents : MonoBehaviour
{
    public static GameObject player;
    public static FixedJoystick joystick;
    public static Image healthImage;
    public static Spawner spawner;

    [SerializeField] private FixedJoystick joystickRef;
    [SerializeField] private Image healthImageRef;
    [SerializeField] private Spawner spawnerRef;

    private void Start()
    {
        joystick = joystickRef;
        healthImage = healthImageRef;
        spawner = spawnerRef;
    }
}
