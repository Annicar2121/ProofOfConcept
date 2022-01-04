using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBenchUIBehavior : MonoBehaviour
{
    public GameObject UIobject;
    // Start is called before the first frame update
    public void exit()
    {
        UIobject.transform.localScale = new Vector3(0f, 0f, 0f); //this makes everything transparent
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
