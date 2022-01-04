using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
A rudimentary inventory class with boolean values for whether predefined objects in game are aquired or not
This specific inventory was a part of the Magician Mania game that can be found here;
https://itch.io/jam/unm-advanced-game-development-2021-phase-2/rate/995043
**/
public class Inventory : MonoBehaviour
{
    public int money;
    public Boolean hasTophat;
    public Boolean hasWand;
    public Boolean hasCoat;
    public int gummyBears;
    public int popcorn;
    public int soda;

    // Start is called before the first frame update
    void Start()
    {
        money = 20;
        hasCoat = false;
        hasTophat = false;
        hasWand = false;
        gummyBears = 0;
        popcorn = 0;
        soda = 0;
    }

    //add money
    public void addMoney(int amount)
    {
        money += amount;
    }

    //buy things
    public Boolean buy(int amount, string item)
    {
        if(money-amount >= 0)
        {
            //have enough
            money -= amount;
            //update
            addInventory(item);
            return true;
        }
        else
        {
            //don't
            return false;
        }
    }


    //all costs
    public int grabThing(string type)
    {
        switch (type)
        {
            case "gBears":
                return gummyBears;

            case "popcorn":
                return popcorn;

            case "soda":
                return soda;

            default:
                return -1;
        }
    }


    //use things
    public Boolean use(int amount, string item)
    {
        int thing = grabThing(item);

        if (thing >= 0)
        {
            //have enough
            thing -= 1;
            return true;
        }
        else
        {
            //don't
            return false;
        }
    }


    //return status of helditems
    public Boolean getStatus(string item)
    {
        if (item == "wand")
        {
            return hasWand;
        }
        else if (item == "coat")
        {
            return hasCoat;
        }
        else if (item == "tophat")
        {
            return hasTophat;
        }
        else
        {
            return false;
        }
    }


    //get how many we have of items of int status
    public int getCount(string item)
    {
        return grabThing(item);
    }


    //add things to inventory
    public void addInventory(string item)
    {
        if(item == "wand")
        {
            setHeld(item);
        }else if(item == "coat")
        {
            setHeld(item);
        }else if(item == "tophat")
        {
            setHeld(item);
        }else if(item == "gBears")
        {
            gummyBears += 1;
        }else if(item == "soda")
        {
            soda += 1;
        }else if(item == "popcorn")
        {
            popcorn += 1;
        }
    }

    //setstatus for held items to true
    public void setHeld(string item)
    {
        if(item == "wand")
        {
            hasWand = true;
        }else if(item == "coat")
        {
            hasCoat = true;
        }else if(item == "tophat")
        {
            hasTophat = true;
        }

    }


    //prints the inventory, for debugging/logging purposes
    public void printInventory()
    {

        Debug.Log("You have " + money + " amount of Money" );
        Debug.Log("Wand is " + hasWand);
        Debug.Log("Coat is " + hasCoat);
        Debug.Log("Hat is " + hasTophat);
        Debug.Log("GBears is " + gummyBears);
        Debug.Log("Popcorn is " + popcorn);
        Debug.Log("Soda is " + soda);
    }
}
