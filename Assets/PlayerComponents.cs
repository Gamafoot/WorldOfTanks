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
    [SerializeField] private GameObject playerUI;

    private void Start()
    {
        joystick = joystickRef;
        healthImage = healthImageRef;
        spawner = spawnerRef;
    }

    private void OnEnable()
    {
        Status.onPlayerRespawn += EnableHUD;
        Status.onPlayerDead += DisableHUD;
    }

    private void OnDisable()
    {
        Status.onPlayerRespawn -= EnableHUD;
        Status.onPlayerDead -= DisableHUD;
    }

    private void EnableHUD()
    {
        playerUI.SetActive(true);
    }
    private void DisableHUD()
    {
        playerUI.SetActive(false);
    }
}
