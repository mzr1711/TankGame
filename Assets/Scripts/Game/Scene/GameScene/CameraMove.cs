using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;

    public float height;

    private Vector3 pos;

    void LateUpdate()
    {
        if (target == null)
            return;

        pos.x = target.position.x;
        pos.y = height;
        pos.z = target.position.z;
        transform.position = pos;
    }
}
