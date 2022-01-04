using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DoorInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform myTransform;
    public Text UItext;
    public LayerMask playerMask;
    public int partsNeeded;
    public GameObject door;
    private bool NearConsole;
    private bool DoorLocked = true;
    public void UnlockDoor()
    {
        DoorLocked = false;
        Destroy(door);
        Debug.Log("OPEN DOOR");
        UItext.text = "Door Unlocked";
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle( new Vector2(myTransform.position.x, myTransform.position.y ), 1f, playerMask);
        if (collider != null)
        {
            Debug.Log(collider.name);
            if (DoorLocked)
            {
                UItext.text = "Repair Door? Use " + partsNeeded + " Parts";
            }
            NearConsole = true;
        }
        else
        {
            NearConsole = false;
            UItext.text = "";
        }
    }
    
    public bool getNear()
    {
        return NearConsole;
    }
    public bool getLocked()
    {
        return DoorLocked;
    }
    public int getPartsNeeded()
    {
        return partsNeeded;
    }
}
