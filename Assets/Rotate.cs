using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed = 1f;
    public Vector3 axis;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(axis, rotateSpeed * Time.deltaTime);
    }
}
