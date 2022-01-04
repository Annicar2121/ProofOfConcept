
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.PlayerLoop;

public class UI_Shop : MonoBehaviour
{
    public GameObject foodShopCanvas;
    public GameObject clothesShopCanvas;
    public GameObject cardShopCanvas;
    GameObject shopCanvas;
    public GameObject itemDescription;
    public GameObject itemCost;
    string typeSelected;
    public PersistentPlayer inv;
    public GameObject noMoney;

  
    public void Start()
    {
        //set all shops to non active to start
        cardShopCanvas.SetActive(false);
        clothesShopCanvas.SetActive(false);
        foodShopCanvas.SetActive(false);
        itemDescription.SetActive(false);
        itemCost.SetActive(false);
        noMoney.SetActive(false);
        inv= GameObject.FindObjectOfType<PersistentPlayer>();

    }


    public void Open(string type)
    {
        if (type == "food")
        {
            foodShopCanvas.SetActive(true);
            itemDescription.SetActive(true);
            itemCost.SetActive(true);
        }
        else if (type == "card")
        {
            cardShopCanvas.SetActive(true);
            itemDescription.SetActive(true);
            itemCost.SetActive(true);
        }
        else
        {
            clothesShopCanvas.SetActive(true);
            itemDescription.SetActive(true);
            itemCost.SetActive(true);
        }
    }

    public void Close()
    {
        Debug.Log("Should be closing in ShopManager");
        cardShopCanvas.SetActive(false);
        clothesShopCanvas.SetActive(false);
        foodShopCanvas.SetActive(false);
        itemDescription.SetActive(false);
        itemCost.SetActive(false);
    }

    public void ItemDescription(string type)
    {
        Debug.Log("Pressed the button: "+ type);
        typeSelected = type;
        Debug.Log("ItemDescription is " + itemDescription);
        ItemDesc d = itemDescription.GetComponent<ItemDesc>();
        d.setItem(typeSelected);
        ItemCost c= itemCost.GetComponent<ItemCost>();
        c.setItem(Costs(type));
    }


    //buy things
    public void Buy()
    {
        Debug.Log("Current thing waiting to be bought is " + typeSelected);
        Boolean stat= inv.buy(Costs(typeSelected), typeSelected);
        Debug.Log("returned " + stat + " from buy");
        if (stat == false)
        {
            Debug.Log("Should be showing no munz");
            StartCoroutine(noMoneyRoutene());
        }
        else
        {
            //purchase successful, disable clothing buttons if applicable
            disableItems(typeSelected);
            inv.printInventory();
        }

    }

    //coroutine for no money
    private IEnumerator noMoneyRoutene()
    {
        Debug.Log("Should be showing no munz in coroutene");
        noMoney.SetActive(true);
        yield return new WaitForSeconds(2);
        noMoney.SetActive(false);

    }


    public void disableItems(string type)
    {
        if (type == "wand")
        {
            GameObject b = GameObject.Find("Wand_Button");
            Button bb = b.GetComponent<Button>();
            b.SetActive(false);
        }
        else if(type == "coat")
        {
            GameObject b = GameObject.Find("Coat_Button");
            Button bb = b.GetComponent<Button>();
            b.SetActive(false);
        }
        else if(type == "tophat")
        {
            GameObject b = GameObject.Find("Tophat_Button");
            Button bb = b.GetComponent<Button>();
            b.SetActive(false);
        }
        else if (type == "gloves")
        {
            GameObject b = GameObject.Find("Gloves_Button");
            Button bb = b.GetComponent<Button>();
            b.SetActive(false);
        }
        else if (type == "ball")
        {
            GameObject b = GameObject.Find("8ball_Button");
            Button bb = b.GetComponent<Button>();
            b.SetActive(false);
        }
    }




    //all costs
    public int Costs(string type)
    {
        switch (type)
        {
            case "tophat":
                return 35;

            case "coat":
                return 15;

            case "gBears":
                return 5;

            case "popcorn":
                return 5;

            case "wand":
                return 10;

            case "soda":
                return 3;

            case "hotdog":
                return 5;

            case "chocolate":
                return 6;

            case "gloves":
                return 10;

            case "ball":
                return 20;

            default:
                return 0;
        }
    }



}