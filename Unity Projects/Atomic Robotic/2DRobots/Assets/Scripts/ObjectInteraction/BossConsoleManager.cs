using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossConsoleManager : MonoBehaviour
{
    public Boolean complete;
    public GameObject[] consoles;
    public Boolean active;
    public bossConsoles activeConsole;
    // Start is called before the first frame update
    void Start()
    {
        consoles = GameObject.FindGameObjectsWithTag("BossConsole");
        complete = false;
        active = false;
        activeConsole = consoles[0].GetComponent<bossConsoles>();

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
        if (numFixed() == numConsoles())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //checks if all broken console objects have been repaired
    public Boolean checkActive()
    {
        foreach (GameObject c in consoles)
        {
            InteractConsole con = c.GetComponent<InteractConsole>();
            if (con.pressed == true)
            {
                activeConsole = c.GetComponent<bossConsoles>();
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
            bossConsoles c = consoles[i].GetComponent<bossConsoles>();
            if (c.repaired)
            {
                fixedNum++;
            }
        }

        return fixedNum;
    }
}
