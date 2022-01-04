using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Part : MonoBehaviour
{
    public int index;
   // public string tag;

    public Part(int idx, string tag)
    {
       // this.tag = tag;
        this.index = idx;
    }


    public int getIndex()
    {
        return this.index;
    }

    public string getTag()
    {
        return this.tag;
    }
}
