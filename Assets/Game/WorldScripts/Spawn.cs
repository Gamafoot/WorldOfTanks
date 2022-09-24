using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Этот скрипт используется как тип для объектов
    public Vector3 position()
    {
        return transform.position;
    }
}
