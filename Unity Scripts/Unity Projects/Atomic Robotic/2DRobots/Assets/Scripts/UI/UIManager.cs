using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    GameObject[] startObjects;
    GameObject[] howtoObjects;
    GameObject[] howtoObjectsTwo;
    GameObject[] pauseObjects;
    GameObject[] workbenchObjects;
    GameObject[] repairsObjects;
    GameObject[] upgradesObjects;
    GameObject[] brokenProgressObjects;
    GameObject[] brokenConsoleObjects;
    GameObject[] wonObjects;
    GameObject[] loseObjects;
    GameObject[] warningObjects;
    GameObject[] UItop;
    //public ConsoleTrigger console;
    public InteractConsole console;
    public InteractConsole[] brokenConsoles;
    public BrokenConsoleManager brokenOnes;
    public BossConsoleManager bossOnes;
    public Boolean startMenu;
    public Boolean onPgOne;
    public Boolean onPgTwo;
    public Player player;
    public Timer timer;
    public Text error;
    public GameObject alreadyFixed;
    public GameObject door;
    public ButtonManager bmanager;
    public Text vault;
    public Text vaultClosed;
    public Text secondObj;
    public Image secBG;
    public AudioManager audioManager;
    public AudioClip winSong, loseSong;
    public bool truf = false;
    

    Boolean showed;
    // Start is called before the first frame update
    void Start()
    {
        showed = false;
        int i = 0;
        Time.timeScale = 0;
        startMenu = true;
        onPgOne = false;
        onPgTwo = false;
        //pauseObjects = GameObject.FindGameObjectsWithTag("PauseMenu");
        workbenchObjects = GameObject.FindGameObjectsWithTag("Workbench");
        repairsObjects = GameObject.FindGameObjectsWithTag("Repairs");
        upgradesObjects = GameObject.FindGameObjectsWithTag("Upgrades");
        startObjects = GameObject.FindGameObjectsWithTag("Start_Menu");
        howtoObjects = GameObject.FindGameObjectsWithTag("HowTo");
        howtoObjectsTwo = GameObject.FindGameObjectsWithTag("HowToTwo");
        brokenProgressObjects = GameObject.FindGameObjectsWithTag("BrokenFill");
        brokenConsoleObjects = GameObject.FindGameObjectsWithTag("BrokenConsole");
        wonObjects = GameObject.FindGameObjectsWithTag("GameWon");
        loseObjects = GameObject.FindGameObjectsWithTag("GameOver");
        warningObjects = GameObject.FindGameObjectsWithTag("NotEnough");
        UItop = GameObject.FindGameObjectsWithTag("UITop");
        winSong = Resources.Load<AudioClip>("winSong");
        loseSong = Resources.Load<AudioClip>("loseSong");
        audioManager = FindObjectOfType<AudioManager>();



        brokenConsoles = new InteractConsole[brokenConsoleObjects.Length];

        foreach(GameObject c in brokenConsoleObjects)
        {
            brokenConsoles[i] = c.GetComponent<InteractConsole>();
            i++;
        }
        hideAllSub();

    }

    // Update is called once per frame
    void Update()
    {

        //won the game
        //BossDead, can fix last console
        if (brokenOnes.complete)
        {
            Time.timeScale = 0;
            showWon();
            if (truf == false)
            {
                audioManager.initEndSong(winSong);
                truf = true;
            }
            

        }

        //vault door has opened, show notification
        if(brokenOnes.numFixed() == 4 && showed == false)
        {
            StartCoroutine(VaultCoroutine());
           secondObj.enabled = true;
            secBG.enabled = true;
            showed = true;
    

        }


        //lost the game or died
        if (player.playerHealth.curHealth <= 0 || timer.outOfTime == true)
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0;
            showLost();
            if (truf == false) {
                audioManager.initEndSong(loseSong);
                truf = true;
            }
        }

        //Debug.Log("In UI manager we register benchEnabled as " + console.benchEnabled);

        if (startMenu== true)
        {
                Time.timeScale = 0;
                showStart();

            //starts the gameplay
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Registered escape pressed");

                 if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                    hideStart();
                }
            }

        }

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
                Time.timeScale = 1;
               // hidePaused();
            }
        }

        //pauses game if controlpanel interacted with, opens workbench
        //if(Input.GetKeyDown(KeyCode.C) && (console.benchEnabled == true))
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
                Time.timeScale = 1;
                hideWorkbench();
            }
        }

       //begins fillbar for repairing consoles
       if (Input.GetKeyDown(KeyCode.C) && brokenOnes.active)
       {
            Debug.Log("Registered click on broken panel!");

            StartCoroutine(RepairCoroutine());

       }

        //begins fillbar for repairing Boss-related consoles
        if (Input.GetKeyDown(KeyCode.C) && bossOnes.active)
        {
            Debug.Log("Registered click on broken panel!");

            StartCoroutine(BossRepairCoroutine());

        }




    }

    //coroutine for repairing consoles
    private IEnumerator RepairCoroutine()
    {
        if (brokenOnes.activeConsole.repaired == false)
        {

            Boolean error = true;

            if (player.allParts[0] >= brokenOnes.activeConsole.numScrews
                && player.allParts[1] >= brokenOnes.activeConsole.numSprings)
            {
                showFill();
                yield return new WaitForSeconds(3);

                if (brokenOnes.active)
                {
                    error = brokenOnes.activeConsole.repair(player.allParts);
                    Debug.Log("Returned " + error);
                }
                else
                {
                    Debug.Log("You pulled away too fast!");
                }
            }
            else
            {
                showError();
                yield return new WaitForSeconds(3);
                hideError();
            }


            hideFill();
        }
        else
        {
            alreadyFixed.SetActive(true);
            yield return new WaitForSeconds(2);
            alreadyFixed.SetActive(false);


        }


    }



    //coroutine for repairing boss consoles
    private IEnumerator BossRepairCoroutine()
    {
        if (bossOnes.activeConsole.repaired == false)
        {

                showFill();
                yield return new WaitForSeconds(3);
                bossOnes.activeConsole.repair();
                hideFill();
        }
        else
        {
            alreadyFixed.SetActive(true);
            yield return new WaitForSeconds(2);
            alreadyFixed.SetActive(false);


        }


    }

    //coroutine for showing vault open notification
    private IEnumerator VaultCoroutine()
    {
        vault.enabled = true;
        yield return new WaitForSeconds(2);
        vault.enabled = false;
        yield return new WaitForSeconds(1);
        vault.enabled = true;
        yield return new WaitForSeconds(1);
        vault.enabled = false;
        yield return new WaitForSeconds(1);
        vault.enabled = true;
        yield return new WaitForSeconds(2);
        vault.enabled = false;
        secondObj.enabled = true;
        secBG.enabled = true;

    }



    //shows objects with Start_Menu tag
    public void showStart()
    {
        foreach (GameObject g in startObjects)
        {
            g.SetActive(true);
        }
    }

    //shows objects with Start_Menu tag
    public void showLost()
    {
        Debug.Log("Showing lost screen");
        foreach (GameObject g in loseObjects)
        {
            g.SetActive(true);
        }
    }

    //shows objects with Start_Menu tag
    public void showWon()
    {
        foreach (GameObject g in wonObjects)
        {
            g.SetActive(true);
        }
    }

    //shows fillbar for repairs
    public void showTop()
    {
        foreach (GameObject g in UItop)
        {
            g.SetActive(true);
        }
    }

    //shows fillbar for repairs
    public void showFill()
    {
        foreach (GameObject g in brokenProgressObjects)
        {
            g.SetActive(true);
        }
    }


    //shows objects on first howto page
    public void showHTOne()
    {
        Debug.Log("Showing ht 1");
        onPgOne = true;
        foreach (GameObject g in howtoObjects)
        {
            g.SetActive(true);
        }
   
    }

    //shows objects on first howto page
    public void showHTTwo()
    {
        onPgTwo = true;
            foreach (GameObject g in howtoObjectsTwo)
            {
                g.SetActive(true);
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

    //shows objects with NotEnough tag
    public void showError()
    {
        error.enabled = true;
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
    public void hideTop()
    {
        foreach (GameObject g in UItop)
        {
            g.SetActive(false);
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

    //hides objects for repair progress
    public void hideFill()
    {
        foreach (GameObject g in brokenProgressObjects)
        {
            g.SetActive(false);
        }
    }

    //hides objects for win overlay
    public void hideLost()
    {
        foreach (GameObject g in loseObjects)
        {
            g.SetActive(false);
        }
    }

    //hides objects for win overlay
    public void hideError()
    {
        error.enabled = false;
    }

    //hides objects for win overlay
    public void hideWon()
    {
        foreach (GameObject g in wonObjects)
        {
            g.SetActive(false);
        }
    }

    //hides stuff when finishing tutotial and starting the actual game
    public void playPressed()
    {
        startMenu = false;
        Time.timeScale = 1;
        showTop();
        //UItop[0].GetComponent<Timer>().start();
        timer.start();


        foreach (GameObject g in startObjects)
        {
            g.SetActive(false);
        }

        foreach (GameObject g in howtoObjects)
        {
            g.SetActive(false);
        }

        foreach (GameObject g in howtoObjectsTwo)
        {
            g.SetActive(false);
        }
    }

    //hides start menu and all related
    public void hideStart()
    {
        Debug.Log("Hide start");
        startMenu = false;

        foreach (GameObject g in startObjects)
        {
            g.SetActive(false);
        }

        showTop();
    }

    //handels howto menu back buttons
    public void backPressed()
    {
        if (onPgOne)
        {
            onPgOne = false;
            hideHT();
            showStart();
        }
        if (onPgTwo)
        {
            onPgTwo = false;
            onPgOne = true;
            hideHT();
            showHTOne();
        }
    }

    //handels howto menu next button(s)
    public void nextHT()
    {
        if (onPgOne)
        {
            onPgOne = false;
            onPgTwo = true;
            hideHT();
            showHTTwo();
        }
    }

    //shows objects on first howto page
    public void hideHT()
    {
        if (onPgOne == false)
        {
            foreach (GameObject g in howtoObjects)
            {
                g.SetActive(false);
            }
        }

        if (onPgTwo == false)
        {
            foreach (GameObject g in howtoObjectsTwo)
            {
                g.SetActive(false);
            }
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

    //hide all submenus but the start
    public void hideAllSub()
    {
        hideWorkbench();
        //hidePaused();
        hideHT();
        hideFill();
        hideWon();
        hideLost();
        hideError();
        hideTop();
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
