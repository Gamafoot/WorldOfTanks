using UnityEngine;

public class Shooting : MonoBehaviour
{
    public void Shoot()
    {
        if (PlayerComponents.player != null)
        {
            PlayerComponents.player.GetComponent<GunSettings>().Shoot();
        }
    }
}
