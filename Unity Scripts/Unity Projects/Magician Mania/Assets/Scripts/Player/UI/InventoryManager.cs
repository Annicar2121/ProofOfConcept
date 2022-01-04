using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryCanvas;
    public GameObject itemDescription;
    public GameObject itemImage;
    public GameObject itemAmount;
    public ButtonManager buttonManager;
    private PersistentPlayer inv;
    string typeSelected;
    public Text hat;
    public Text coat;
    public Text wand;
    public Text gloves;
    public Text ball;


    public void Start()
    {
        //set all shops to non active to start
        inventoryCanvas.SetActive(false);
        itemDescription.SetActive(false);
        itemAmount.SetActive(false);
        itemImage.SetActive(false);
        inv = GameObject.FindObjectOfType<PersistentPlayer>();
       // Debug.Log("persistent player is " + inv.name);


    }


    public void Open()
    {
        //setWorn();
            inv = GameObject.FindGameObjectWithTag("PP").GetComponent<PersistentPlayer>();
        setWorn();
        inventoryCanvas.SetActive(true);
            itemDescription.SetActive(true);
            itemAmount.SetActive(true);
            itemImage.SetActive(true);

    }

    public void setWorn()
    {
        if (inv.hasCoat)
        {
            coat.color = Color.black;
        }
        if (inv.hasWand)
        {
            wand.color = Color.black;
        }
        if (inv.hasTophat)
        {
            hat.color = Color.black;
        }
        if (inv.hasGloves)
        {
            gloves.color = Color.black;
        }
        if (inv.hasBall)
        {
            ball.color = Color.black;
        }
    }

    public void Close()
    {
        Debug.Log("Should be closing in ShopManager");
        inventoryCanvas.SetActive(false);
        itemDescription.SetActive(false);
        itemAmount.SetActive(false);
        itemImage.SetActive(false);
    }

    //get the item description based on type
    public void ItemDescription(string type)
    {
        Debug.Log("Pressed the button: " + type);
        typeSelected = type;
        Debug.Log("ItemDescription is " + itemDescription);
        ItemDesc d = itemDescription.GetComponent<ItemDesc>();
        d.setItem(typeSelected);
        ItemAmount c = itemAmount.GetComponent<ItemAmount>();
        c.setItem(inv.getCount(type));
    }


    //use things
    public void Use()
    {
        Debug.Log("Current thing waiting to be used is " + typeSelected);
        Boolean stat = inv.use(improveAffection(typeSelected), typeSelected);
        Debug.Log("returned " + stat + " from buy");
        inv.printInventory();

    }




    //all costs
    public int improveAffection(string type)
    {
        switch (type)
        {
            case "tophat":
                return 15;

            case "coat":
                return 10;

            case "gBears":
                return 10;

            case "popcorn":
                return 5;

            case "wand":
                return 5;

            case "soda":
                return 5;

            default:
                return 0;
        }
    }
}
