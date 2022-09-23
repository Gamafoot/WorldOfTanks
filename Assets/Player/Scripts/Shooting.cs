using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Shoot settings")]

    [Tooltip("Время перезарядки")]
    [SerializeField] private float timeReload;

    [Tooltip("Пережаряжается ли сейчас")]
    [SerializeField] private bool reloading = true;

    [Tooltip("Позиция выстрела")]
    [SerializeField] private Transform shootPosition;

    [Tooltip("Префаб снаряда")]
    [SerializeField] private GameObject bullet_prefub;

    public void Shoot(){
        // При нажатии на кнопку выстрела будет вызываться метод shoot

        StartCoroutine(Shoot_CoolDown(timeReload));
    }

    private IEnumerator Shoot_CoolDown(float timeReload){
        // Карутина с проверкой на cooldown (задержка вытстрела)
    
        if (reloading){
            reloading = false;
            CreateBullet();
            yield return new WaitForSeconds(timeReload);
            reloading = true;
        }
    }

    private void CreateBullet(){
        // Создаёт пулю

        Instantiate(bullet_prefub, shootPosition.position, shootPosition.rotation*Quaternion.Euler(90, 0, 0));
    }
}
