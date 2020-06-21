using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float autoDestroyTime;

    private void Start()
    {
        Destroy(gameObject, autoDestroyTime);
    }
}