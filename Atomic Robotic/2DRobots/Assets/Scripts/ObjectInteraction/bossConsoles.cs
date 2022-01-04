using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossConsoles : MonoBehaviour
{
    // Start is called before the first frame update
    public bool repaired;
   
    public int[] parts;
    //private PartCatelog catalog;
    public Player player;
    public BossBehavior boss;

   


    // Start is called before the first frame update
    void Start()
    {
        //catalog = new PartCatelog(player.NUM_PARTS);
        repaired = false;
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    //repair the console
    public bool repair()
    {
        if (!repaired)
        {

            repaired = true;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            boss.TakeDamage(1);
            Debug.Log("Repaired the console!");
            return true;

        }

        else
        {
            Debug.Log("This console has already been repaired");
            return true;
        }
    }



}
