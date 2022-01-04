using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
A UIManager class that handles user input and cycles through different screens and displays of UI, such as menus.
This specific UI manager was used for the Atomic Robotic Game you can find here;
https://sebsthename.itch.io/atomic-robotic
**/
public class UIManager : MonoBehaviour
{

    GameObject[] pauseObjects;
    GameObject[] workbenchObjects;
    GameObject[] repairsObjects;
    GameObject[] upgradesObjects;
    public InteractConsole console;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        workbenchObjects = GameObject.FindGameObjectsWithTag("Workbench");
        repairsObjects = GameObject.FindGameObjectsWithTag("Repairs");
        upgradesObjects = GameObject.FindGameObjectsWithTag("Upgrades");
        hideWorkbench();
    }

    // Update is called once per frame
    void Update()
    {


        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Registered escape pressed");

            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
               // showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                Time.timeScale = 1;
               // hidePaused();
            }
        }

        //pauses game if controlpanel interacted with, opens workbench
        if(Input.GetKeyDown(KeyCode.C) && console.pressed)
        {

            Debug.Log("Registered console pressed");
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showWorkbench();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                Time.timeScale = 1;
                hideWorkbench();
            }
        }

    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //shows objects with Workbench tag
    public void showWorkbench()
    {
        foreach (GameObject g in workbenchObjects)
        {
            g.SetActive(true);
        }
        //default to repairs being shown on workbench opening
        foreach (GameObject g in repairsObjects)
        {
            g.SetActive(true);
        }
    }

    //shows objects with Repairs tag
    public void showRepairs()
    {
        foreach (GameObject g in repairsObjects)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in upgradesObjects)
        {
            g.SetActive(false);
        }
    }

    //shows objects with Upgrades tag
    public void showUpgrades()
    {
        foreach (GameObject g in repairsObjects)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in upgradesObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    //hides objects with Workbench tag
    public void hideWorkbench()
    {
        foreach (GameObject g in workbenchObjects)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in repairsObjects)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in upgradesObjects)
        {
            g.SetActive(false);
        }
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }

    //Reloads the Level
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
