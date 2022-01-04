using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public int num;
    public Light light;
    // Start is called before the first frame update
    void Start()
    {
        PersistentPlayer pp = Object.FindObjectOfType<PersistentPlayer>();
        light.intensity = 0;
        if (pp != null)
        {
            if (num <= pp.whichBattle)
            {
                light.intensity = 8;
            }
            
        }
        if (num == 0 && pp == null)
        {
            light.intensity = 8;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
