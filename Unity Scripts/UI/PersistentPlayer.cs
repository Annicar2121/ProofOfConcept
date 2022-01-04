using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
A Persistent Player class that keeps record of inventory and status for the player between different scene loads
This specific class was a part of the Magician Mania game that can be found here;
https://itch.io/jam/unm-advanced-game-development-2021-phase-2/rate/995043
**/
public class PersistentPlayer : MonoBehaviour
{
    private CardDatabase cd;
    public int money;
    public Boolean hasTophat;
    public Boolean hasWand;
    public Boolean hasCoat;
    public Boolean hasBall;
    public Boolean hasGloves;
    public int gummyBears;
    public int popcorn;
    public int soda;
    public int chocolate;
    public int hotdog;
    private string wornItem;
    private string heldItem;
    private static List<Card> myDeck = new List<Card>();
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        cd = GameObject.FindObjectOfType<CardDatabase>();
        money = 20;
        wornItem = "NULL";
        heldItem = "NULL";
        myDeck.Add(new Card(1, "Cup and Balls", 2, 10, "Gain 10 Audience Affection", 99));
        myDeck.Add(new Card(3, "Linking Rings", 2, 20, "Gain 20 Affection, if Audience is distracted gain 40 affection", 70));
        myDeck.Add(new Card(4, "Levitation", 2, 10, "Gain 10 Affection", 75));
        myDeck.Add(new Card(7, "Bad Pun", 1, 5, "Gain 5 Affection, if audience is primed gain 35 affection", 80));
        myDeck.Add(cd.cardList[13]);
        myDeck.Add(cd.cardList[14]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addMoney(int pay)
    {
        money += pay;
        return;
    }
    public void spendMoney(int cost)
    {
        money -= cost;
        return;
    }
    public string getWornItem()
    {
        return wornItem;
    }
    public string getHeldItem()
    {
        return heldItem;
    }
    public List<Card> getDeck()
    {
        return myDeck;
    }

    //add the effects of items held
    public void addItemEffects()
    {
        if (hasCoat)
        {
            GameObject.FindObjectOfType<Audience>().changePlayerAffection(10);
        }
        if (hasTophat)
        {
            GameObject.FindObjectOfType<Audience>().changePlayerAffection(15);
        }
        if (hasWand)
        {
            GameObject.FindObjectOfType<Audience>().changePlayerAffection(5);
        }
        if (hasGloves)
        {
            GameObject.FindObjectOfType<Audience>().changePlayerAffection(8);
        }
        if (hasBall)
        {
            int r= UnityEngine.Random.Range(0, 20);
            GameObject.FindObjectOfType<Audience>().changePlayerAffection(r);
        }

    }


    //buy things
    public Boolean buy(int amount, string item)
    {
        if (money - amount >= 0)
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

            case "chocolate":
                return chocolate;

            case "hotdog":
                return hotdog;

            default:
                return -1;
        }
    }


    //add an effect
    public void addEffect(string item)
    {
        if (item == "gBears" || item == "hotdog")
        {
            GameObject.FindObjectOfType<Audience>().changePlayerAffection(10);
        }else if(item == "chocolate")
        {
            GameObject.FindObjectOfType<Audience>().changePlayerAffection(15);
        }
        else
        {
            GameObject.FindObjectOfType<Audience>().changePlayerAffection(5);
        }
        GameObject.FindObjectOfType<InventoryManager>().Close();
    }


    //use things
    public Boolean use(int amount, string item)
    {
        if (item == "gBears")
        {
            if (gummyBears > 0)
            {
                //have enough
                gummyBears -= 1;
                //update
                addEffect(item);
                return true;
            }
            else
            {
                //don't
                return false;
            }

        }
        else if (item == "soda")
        {
            if (soda > 0)
            {
                //have enough
                soda -= 1;
                //update
                addEffect(item);
                return true;
            }
            else
            {
                //don't
                return false;
            }

        }
        else if (item == "hotdog")
        {
            if (hotdog > 0)
            {
                //have enough
                hotdog -= 1;
                //update
                addEffect(item);
                return true;
            }
            else
            {
                //don't
                return false;
            }

        }
        else if (item == "chocolate")
        {
            if (chocolate > 0)
            {
                //have enough
                chocolate -= 1;
                //update
                addEffect(item);
                return true;
            }
            else
            {
                //don't
                return false;
            }

        }
        else
        {
            if (popcorn > 0)
            {
                //have enough
                popcorn -= 1;
                //update
                addEffect(item);
                return true;
            }
            else
            {
                //don't
                return false;
            }

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
        else if (item == "ball")
        {
            return hasBall;
        }
        else if (item == "gloves")
        {
            return hasGloves;
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
        if (item == "wand")
        {
            setHeld(item);
        }
        else if (item == "coat")
        {
            setHeld(item);
        }
        else if (item == "tophat")
        {
            setHeld(item);
        }
        else if (item == "gloves")
        {
            setHeld(item);
        }
        else if (item == "ball")
        {
            setHeld(item);
        }
        else if (item == "gBears")
        {
            gummyBears += 1;
        }
        else if (item == "soda")
        {
            soda += 1;
        }
        else if (item == "popcorn")
        {
            popcorn += 1;
        }
        else if (item == "hotdog")
        {
            hotdog += 1;
        }
        else if (item == "chocolate")
        {
            chocolate += 1;
        }
    }

    //setstatus for held items to true
    public void setHeld(string item)
    {
        if (item == "wand")
        {
            hasWand = true;
        }
        else if (item == "coat")
        {
            hasCoat = true;
        }
        else if (item == "tophat")
        {
            hasTophat = true;
        }
        else if (item == "gloves")
        {
            hasGloves = true;
        }
        else if (item == "ball")
        {
            hasBall = true;
        }

    }


    public void printInventory()
    {

        Debug.Log("You have " + money + " amount of Money");
        Debug.Log("Wand is " + hasWand);
        Debug.Log("Coat is " + hasCoat);
        Debug.Log("Hat is " + hasTophat);
        Debug.Log("GBears is " + gummyBears);
        Debug.Log("Popcorn is " + popcorn);
        Debug.Log("Soda is " + soda);
        Debug.Log("Chocolate is " + chocolate);
        Debug.Log("Hotdog is " + hotdog);
    }

}
