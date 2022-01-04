using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenConsoleManager : MonoBehaviour
{

    public Boolean complete;
    public GameObject[] consoles;
    public Boolean active;
    public BrokenConsole activeConsole;
    public GameObject vaultDoor;
    // Start is called before the first frame update
    void Start()
    {
        consoles = GameObject.FindGameObjectsWithTag("BrokenConsole");
        complete = false;
        active = false;
        activeConsole = consoles[0].GetComponent<BrokenConsole>();
        Debug.Log("There are " + consoles.Length + " broken consoles in the scene");

    }

    // Update is called once per frame
    void Update()
    {
        active = checkActive();
        complete = checkAllDone();
        if (complete)
        {
            Debug.Log("ALL CONSOLES FIXED");
        }
    }




    //checks if all broken console objects have been repaired
    public Boolean checkAllDone()
    {
        int i = 0;
        foreach(GameObject c in consoles)
        {
            BrokenConsole con = c.GetComponent<BrokenConsole>();
            if(con.repaired == true)
            {
               i++;  
            }
           
        }
        if(i >= 4)
        {
            if (vaultDoor != null)
            {
                Destroy(vaultDoor);
            }
        }
        if(i == 5) {
            return true;
        }
        return false;
    }

    //checks if all broken console objects have been repaired
    public Boolean checkActive()
    {
        foreach (GameObject c in consoles)
        {
            InteractConsole con = c.GetComponent<InteractConsole>();
            if (con.pressed == true)
            {
                Debug.Log("Active console is " + c);
                activeConsole = c.GetComponent<BrokenConsole>();
                return true;
            }
        }

        return false;
    }

    //return total numConsoles
    public int numConsoles()
    {
        return consoles.Length;
    }

    public int numFixed()
    {
        int fixedNum = 0;
        for (int i = 0; i < numConsoles(); i++)
        {
            BrokenConsole c = consoles[i].GetComponent<BrokenConsole>();
            if (c.repaired)
            {
                fixedNum++;
            }
        }

        return fixedNum;
    }


}
