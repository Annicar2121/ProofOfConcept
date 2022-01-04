using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform camtransform;
    public Transform target;
    public float distance;

 void Update()
    {

        camtransform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - distance);

    }
}
