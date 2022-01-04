using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    GameObject[] shopObjects;
    public UI_Shop shops;
    Boolean open;
    public InventoryManager inv;
    public Boolean trigger;
    public int isFood;
    public GameObject pause;
    public GameObject howTo;


    Boolean showed;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        shopObjects = GameObject.FindGameObjectsWithTag("descript");
        open = false;
        pause.SetActive(false);
        howTo.SetActive(false);
        hideAllSub();
        trigger = false;
        isFood = -1;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("isFood is " + isFood);

        //open up the shop menu- FOOD
        if (Input.GetKeyDown(KeyCode.E) && trigger == true && open == false && isFood == 1)
        {
            Debug.Log("Registered e press for open");
            Debug.Log("open is " + open);
            if (!open)
            {
                shops.Open("food");
                StartCoroutine(SomeCoroutine());
                open = true;
            }

        }//open up the shop menu- CLOTHES
        else if (Input.GetKeyDown(KeyCode.E) && trigger == true && open == false && isFood == 0)
        {
            if (!open)
            {
                shops.Open("clothes");
                StartCoroutine(SomeCoroutine());
                open = true;
            }

        }//escape shop
        else if (Input.GetKeyDown(KeyCode.E) && open == true)
        {
            Debug.Log("Registered e press for closing");

            if (open)
            {
                Debug.Log("Should be closing");
                shops.Close();
                inv.Close();
                open = false;
            }

        }

        //open up the Inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!open)
            {
                inv.Open();
                open = true;
            }
            else
            {
                inv.Close();
                open = false;
            }

        }


        //open up the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (!open)
            {
                pause.SetActive(true);
                open = true;
                Time.timeScale = 0;
            }
            else
            {
                open = false;
                pause.SetActive(false);
                Time.timeScale = 1;
            }

        }






    }


    //hidehowto page
    public void hideHow()
    {
        howTo.SetActive(false);
    }

    //show howto page
    public void showHow()
    {
        howTo.SetActive(true);
    }

    //coroutine 
    private IEnumerator SomeCoroutine()
    {
        yield return new WaitForSeconds(1);

    }


    //collision trigger
    public void setTrigger(Boolean set, int food)
    {
        trigger = set;
        isFood = food;
    }

    //shows objects with descript tag
    public void showDescript()
    {
        foreach (GameObject g in shopObjects)
        {
            g.SetActive(true);
        }
    }

    //shows objects with descript tag
    public void hideDescript()
    {
        foreach (GameObject g in shopObjects)
        {
            g.SetActive(false);
        }
    }




    //hide all submenus but the start
    public void hideAllSub()
    {
        hideDescript();
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    //Reloads the Level
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
