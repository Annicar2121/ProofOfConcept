using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health = 100;
    //NUM_PARTS is the # of dropped parts in the game
    public int NUM_PARTS = 2;
    public int parts;
    public LayerMask propMask;
    public Transform myTransform;
    public Health playerHealth;
    public int[] allParts;
    public BulletLogic[] spawners;
    //0= screws, 1= springs, ...
    public bool isIn = false;
    public Text errorText;

    private float t;
    private bool partRet = false;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        Physics2D.IgnoreLayerCollision(13, 8, true);
        Physics2D.IgnoreLayerCollision(13, 14, true);
        Physics2D.IgnoreLayerCollision(13, 15, true);
        Physics2D.IgnoreLayerCollision(13, 13, true);
        allParts = new int[NUM_PARTS];
        spawners = FindObjectsOfType<BulletLogic>();



        //differentiating parts, initialize
        for (int i = 0; i < NUM_PARTS; i++)
        {
            allParts[i] = 0;
        }
    }


    public void HealPlayer()
    {
        int partsRequired = 1;
        int heal = 5;
        if (parts >= partsRequired)
        {
            playerHealth.DamagePlayer(0 - heal);
            parts -= partsRequired;
        }
    }



    //method to be used passing a game object that is picked up,
    //and sorting it into allParts array based on what it is
    public void addPart(GameObject obj)
    {
        Part p = obj.GetComponent<Part>();
        allParts[p.getIndex()]++;

    }

    public void addPart()
    {
        parts++;
        Debug.Log(parts);
    }


    // Update is called once per frame
    void Update()
    {

        if (isIn)
        {

            if (Time.time - t > 1)
            {
                playerHealth.DamagePlayer(1);
                SoundFXManagerScript.PlaySound("playerToxicDrain");
                t = Time.time;
            }

        }

        Collider2D collider = Physics2D.OverlapCircle(new Vector2(myTransform.position.x, myTransform.position.y), 1f, propMask);
        doorInteraction(collider);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "RadTile")
        {
            isIn = true;
            t = Time.time;
        }

        if (col.gameObject.tag == "Wall") {
            Debug.Log("Blorp");
        }

    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "RadTile")
        {
            isIn = false;
        }
    }


    //---------------- OTHER METHODS ---------------------------

    //spend screws given some cost, and some tag to what it pertains, and an amount for
    //the upgrade
    public void spendScrews(string vals)
    {
        int cost = 0;
        string tag = "";
        int amount = 0;

        string[] splittedParams = vals.Split(',');

        //tag rc is for repairing the consoles, doesn't require anything but deducting parts

        cost = System.Convert.ToInt32(splittedParams[0]);
        tag = splittedParams[1];
        amount = System.Convert.ToInt32(splittedParams[2]);


        if (cost <= allParts[0])
        {
            allParts[0] = allParts[0] - cost;
            //repair health
            if (tag == "rh")
            {
                playerHealth.healPlayer(amount);
            }
            //upgrade health
            else if (tag == "uh")
            {
                playerHealth.upgradeHealth(amount);
            }
            //upgrade gun damage
            else if (tag == "ug")
            {
                foreach (BulletLogic g in spawners)
                {
                    g.increaseGunDamage(amount);
                }
            }
            //upgrade gun speed
            else if (tag == "ugs")
            {
                this.GetComponent<Shootingscript>().setDoubleFire(true);
            }
            //upgrade gun range
            else if (tag == "ugr")
            {
                this.GetComponent<Shootingscript>().setAngleFire(true);
            }
            //upgrade parts magnet
            else if (tag == "pm")
            {
                setPartRet(true);
            }

        }
        else
        {
            //dont have enough funds
            StartCoroutine(InsufficientCoroutine());
        }
    }


    //spend springs given some cost, and some tag to what it pertains, and an amount for the
    //upgrade
    public void spendSprings(string vals)
    {

        int cost = 0;
        string tag = "";
        int amount = 0;

        string[] splittedParams = vals.Split(',');

        cost = System.Convert.ToInt32(splittedParams[0]);
        tag = splittedParams[1];
        amount = System.Convert.ToInt32(splittedParams[2]);


        if (cost <= allParts[1])
        {
            allParts[1] = allParts[1] - cost;

            //repair health
            if (tag == "rh")
            {
                playerHealth.healPlayer(amount);
            }
            //upgrade health
            else if (tag == "uh")
            {
                playerHealth.upgradeHealth(amount);
            }
            //upgrade gun damage
            else if (tag == "ug")
            {
                foreach (BulletLogic g in spawners)
                {
                    g.increaseGunDamage(amount);
                }
            }
            //upgrade gun speed
            else if (tag == "ugs")
            {
                this.GetComponent<Shootingscript>().setDoubleFire(true);
            }
            //upgrade gun range
            else if (tag == "ugr")
            {
                this.GetComponent<Shootingscript>().setAngleFire(true);
            }
            //upgrade parts magnet
            else if (tag == "pm")
            {
                setPartRet(true);
            }
        }
        else
        {
            //dont have enough funds
            StartCoroutine(InsufficientCoroutine());
           
        }


    }

    //coroutine for repairing consoles
    private IEnumerator InsufficientCoroutine()
    {
        Time.timeScale = 1;
            errorText.enabled = true;
            Time.timeScale = 1;
            yield return new WaitForSeconds(2);
            errorText.enabled = false;
            Time.timeScale = 0;



    }


    void doorInteraction(Collider2D collider)
    {
        if (collider != null)
        {
            DoorInteraction doorInteraction = collider.GetComponent<DoorInteraction>();
            if (doorInteraction != null)
            {
                if (doorInteraction.getLocked())
                {
                    if (parts >= doorInteraction.getPartsNeeded())
                    {
                        if (Input.GetKeyUp("f"))
                        {
                            doorInteraction.UnlockDoor();
                            parts = parts - doorInteraction.getPartsNeeded();
                        }
                    }
                }
            }
        }
    }
    public void setPartRet(bool x)
    {
        partRet = x;
    }
   public bool getPartRet()
    {
        return partRet;
    }

}
