using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    GameObject[] inventoryButtons;
    public PersistentPlayer inv;
    // Start is called before the first frame update
    void Start()
    {
        inventoryButtons = GameObject.FindGameObjectsWithTag("I_button");
        Debug.Log("There are " + inventoryButtons.Length + " inventoryButtons");
        inv = GameObject.FindObjectOfType<PersistentPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        checkButtons();

    }


    //get a button
    public GameObject getButton(string type)
    {
        for(int i = 0; i<inventoryButtons.Length; i++)
        {
            if (inventoryButtons[i].name == type)
            {
                return inventoryButtons[i];
            }
        }

        return null;
    }

    //check buttons and set disables enabled on if player has enough parts
    public void checkButtons()
    {
        if(inv.popcorn > 0)
        {
            GameObject b= getButton("Popcorn_Inv_Button");
            b.SetActive(true);
        }
        else
        {
            GameObject b = getButton("Popcorn_Inv_Button");
            b.SetActive(false);
        }

        if(inv.soda > 0)
        {
            GameObject b = getButton("Soda_Inv_Button");
            b.SetActive(true);
        }
        else
        {
            GameObject b = getButton("Soda_Inv_Button");
            b.SetActive(false);
        }

        if(inv.gummyBears > 0)
        {
            GameObject b = getButton("GBears_Inv_Button");
            b.SetActive(true);
        }
        else
        {
            GameObject b = getButton("GBears_Inv_Button");
            b.SetActive(false);
        }

    }
}
