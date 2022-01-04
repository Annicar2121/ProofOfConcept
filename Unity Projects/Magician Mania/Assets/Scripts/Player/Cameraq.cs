using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraq : MonoBehaviour
{
    public Transform camtransform;
    public Transform target;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camtransform.position = new Vector3(target.position.x, target.position.y, target.position.z - distance);
    }
}
