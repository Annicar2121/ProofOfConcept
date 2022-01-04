using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //not the most efficient way to do this but meh
    GameObject[] repairsObjects;
    GameObject[] upgradesObjects;
    GameObject[] repairsButtons;
    GameObject[] upgradesButtons;
    Button repairHealth;
    Button upgradeHealth;
    Button upgradeGun;
    Button upgradeGunRange;
    Button upgradeGunSpeed;
    Button upgradeMagnet;
    public int numScrews;
    public int numSprings;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        repairHealth = GameObject.Find("Repair_Health_Button").GetComponent<Button>();
        upgradeHealth = GameObject.Find("Upgrade_Health_10").GetComponent<Button>();
        upgradeGun = GameObject.Find("Upgrade_Blast_Button").GetComponent<Button>();
        upgradeGunRange = GameObject.Find("Upgrade_Weaon_Range").GetComponent<Button>();
        upgradeGunSpeed = GameObject.Find("Upgrade_Firespeed").GetComponent<Button>();
        upgradeMagnet = GameObject.Find("Upgrade_PartsCollector").GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        numScrews = player.allParts[0];
        numSprings = player.allParts[1];
        checkButtons();
        
    }

    //check buttons and set disables enabled on if player has enough parts
    public void checkButtons()
    {
        //restore health is 5 screws
        //upgrade magnet is 10 springs
        //firing speed is 8 screws
        //weapon range is 8 springs
        //weapon power is 5 springs
        //upgrade health is 5 springs
        if (numScrews < 5)
        {
            repairHealth.interactable = false;
            upgradeHealth.interactable = false;
            upgradeGun.interactable = false;
            upgradeGunRange.interactable = false;
            upgradeGunSpeed.interactable = false;
            upgradeMagnet.interactable = false;
        }
        else if (numScrews < 8)
        {
            repairHealth.interactable = true;
            upgradeHealth.interactable = true;
            upgradeGun.interactable = true;
            upgradeGunRange.interactable = false;
            upgradeGunSpeed.interactable = false;
            upgradeMagnet.interactable = false;
        }
        else if (numScrews < 10)
        {
            repairHealth.interactable = true;
            upgradeHealth.interactable = true;
            upgradeGun.interactable = true;
            upgradeGunRange.interactable = true;
            upgradeGunSpeed.interactable = true;
            upgradeMagnet.interactable = false;
        }
        else
        {
            repairHealth.interactable = true;
            upgradeHealth.interactable = true;
            upgradeGun.interactable = true;
            upgradeGunRange.interactable = true;
            upgradeGunSpeed.interactable = true;
            upgradeMagnet.interactable = true;
        }

    }
}
