using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsDictionary : MonoBehaviour
{

    //internal pair class
    public class Pair
    {
        int index;
        string tag;

        public Pair(int idx, string t)
        {
            this.index = idx;
            this.tag = t;
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

    public List<Pair> partsCatalog = new List<Pair>();

    public void Start()
    {
        //hardcoding parts
        partsCatalog.Add( new Pair(0, "Screw"));
        partsCatalog.Add( new Pair(1, "Spring"));

    }

    public void Update()
    {
        //TODO: Attempted to scan the scene for all items in it and add as they become available, couldn't work it, so
        //just adding them as hardcode (THIS MAKES THE Part SCRIPT a little redundant but meh)
        ////build dictionary
        //GameObject[] parts = GameObject.FindGameObjectsWithTag("Part");
        //foreach (GameObject g in parts)
        //{
        //    Part p = g.GetComponent<Part>();
        //    if (!partsCatalog.ContainsKey(p.getTag()))
        //    {
        //        partsCatalog.Add(p.getTag(), p.getIndex());
        //    }
        //}

        //Debug.Log("Printing Dictionary");
        //Debug.Log("There are " + partsCatalog.Count + " in the dictionary");
       
    }
}
