using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimation : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer)
        {
            Destroy(gameObject);
        }
    }
}
