public class Shooting : GetPlayerClass
{
    public void Shoot()
    {
        if (player != null)
        {
            player.GetComponent<GunSettings>().Shoot();
        }
    }
}
