using System.Collections;
using System.Collections.Generic;
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

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            if (reloading){
                StartCoroutine(Shoot_CoolDown(timeReload));
            }
        }
    }

    private IEnumerator Shoot_CoolDown(float timeReload){
        reloading = false;
        Shoot();
        yield return new WaitForSeconds(timeReload);
        reloading = true;
    }

    private void Shoot(){
        GameObject bullet = Instantiate(bullet_prefub, shootPosition.position, shootPosition.rotation*Quaternion.Euler(90, 0, 0));
    }
}
