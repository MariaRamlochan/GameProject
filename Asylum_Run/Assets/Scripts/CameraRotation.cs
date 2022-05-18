using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float speed = 20;

    private void Update()
    {
        gameObject.transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
