using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenConsole : MonoBehaviour
{

    public Boolean repaired;
    public int[] numParts;
    public string[] allParts;
    //public Part[] parts;
    public int[] parts;
    //private PartCatelog catalog;
    public Player player;
    public int numScrews;
    public int numSprings;

    public BrokenConsole(int[] numParts, string[] allParts)
    {

        //catalog = new PartCatelog();
        this.repaired = false;
        this.numParts = numParts;
        this.allParts = allParts;
        //this.parts = catalog.makeParts();
    }


    // Start is called before the first frame update
    void Start()
    {
        //catalog = new PartCatelog(player.NUM_PARTS);
        repaired = false;
        parts = new int[2];
        parts[0] = numScrews;
        parts[1] = numSprings;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //repair the console
    public Boolean repair(int[] playerNumParts)
    {
        if (!repaired)
        {
            if(player.allParts[0] >= numScrews && player.allParts[1] >= numSprings)
            {
                repaired = true;
                this.GetComponent<SpriteRenderer>().color = Color.white;
                player.spendScrews("5,rc,0");
                player.spendSprings("5,rc,0");
                Debug.Log("Repaired the console!");
                return true;
            }
            else
            {
                Debug.Log("Not enough parts to fix!");
                return false;
            }
            
    
            
        }
        else
        {
            Debug.Log("This console has already been repaired");
            return true;
        }
    }



}
