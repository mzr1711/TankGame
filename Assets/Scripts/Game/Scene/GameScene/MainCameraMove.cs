using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour
{
    public Transform mountPos;

    void LateUpdate()
    {
        if(mountPos != null)
        {
            transform.position = mountPos.position;
            transform.rotation = mountPos.rotation;
        }
    }
}
