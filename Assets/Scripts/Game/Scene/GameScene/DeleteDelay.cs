using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDelay : MonoBehaviour
{
    public float delay = 2;

    void Start()
    {
        Destroy(gameObject, delay);
    }
}
