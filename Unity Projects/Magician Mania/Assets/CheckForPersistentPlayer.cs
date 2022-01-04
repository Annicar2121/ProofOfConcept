using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPersistentPlayer : MonoBehaviour
{
    public GameObject ppPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
        if (GameObject.FindGameObjectWithTag("PP") == null)
        {
            Instantiate(ppPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
