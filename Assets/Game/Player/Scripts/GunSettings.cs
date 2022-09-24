using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSettings : MonoBehaviour
{
    [Header("Shoot settings")]

    [Tooltip("����� �����������")]
    [SerializeField] private float timeReload;

    [Tooltip("�������������� �� ������")]
    [SerializeField] private bool reloading = true;

    [Tooltip("������� ��������")]
    [SerializeField] private Transform shootPosition;

    [Tooltip("������ �������")]
    [SerializeField] private GameObject bullet_prefub;

    public void Shoot()
    {
        // ��� ������� �� ������ �������� ����� ���������� ����� shoot

        StartCoroutine(Shoot_CoolDown(timeReload));
    }

    private IEnumerator Shoot_CoolDown(float timeReload)
    {
        // �������� � ��������� �� cooldown (�������� ��������)

        if (reloading)
        {
            reloading = false;
            CreateBullet();
            yield return new WaitForSeconds(timeReload);
            reloading = true;
        }
    }

    private void CreateBullet()
    {
        // ������ ����

        Instantiate(bullet_prefub, shootPosition.position, shootPosition.rotation * Quaternion.Euler(90, 0, 0));
    }
}
