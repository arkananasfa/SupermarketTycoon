using System;
using UnityEngine;

public class SpinningObject : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * 180f);
    }
}