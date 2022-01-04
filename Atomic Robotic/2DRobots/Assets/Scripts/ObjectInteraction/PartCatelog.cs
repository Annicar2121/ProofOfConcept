using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCatelog
{
    //a class that creates a random amount of parts and places them in an array to be passed
    //to the broken consoles, to set what parts are needed to repair a specific console

    public List<int> seen;
    int ran = Random.Range(1, 3);
    int NUM_PARTS;
    public PartsDictionary dict;

    public PartCatelog(int num)
    {
        this.NUM_PARTS = num;
        makeParts();
    }

    public Part[] makeParts()
    {
       
        Debug.Log("Going too require " + ran + " parts");
        Part[] parts = new Part[ran];

        for(int i= 0; i < ran; i++)
        {
            int ran2 = Random.Range(0, NUM_PARTS);
            //parts[i] = new Part(ran2, dict);
            parts[i] = new Part(0, "Screw");
        }

        return parts;
    }

}
