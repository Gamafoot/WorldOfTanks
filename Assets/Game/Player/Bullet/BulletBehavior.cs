using Photon.Pun;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [Header("Bullet settings")]

    [Tooltip("Скорость снаряда")]
    [SerializeField] private float speed;

    [Tooltip("Урон от снаряда")]
    [SerializeField] private float damage;

    [Tooltip("Слой врагов по котрым будет проходить урон")]
    [SerializeField] private int numberEnemiesLayer;

    [Tooltip("Время жизни снаряда (в секундах)")]
    [SerializeField] private float lifeTime;


    private void Start() {
        Invoke("DestroyBullet", lifeTime);
    }

    private void DestroyBullet() {
        Destroy(transform.gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.gameObject.tag == "Player")
        {
            collision.transform.GetComponent<Status>().TakeDamage(damage);
        }
        Destroy(transform.gameObject);
    }
}
