using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float rotSpeed = 10.0f;

    void Update()
    {
        transform.Rotate(Vector3.right * rotSpeed * Time.deltaTime, Space.World);
    }
}
