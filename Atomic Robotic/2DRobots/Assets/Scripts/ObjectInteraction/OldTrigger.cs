using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldTrigger : MonoBehaviour
{
    private bool benchEnabled = false;
    //private bool pressed;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger COllision");
        if (other.CompareTag("Player"))
        {
            benchEnabled = true;
        }
    } 

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Out Collission");
        if (other.CompareTag("Player"))
        {
            benchEnabled = false;
           // pressed = false;
        }
    }

    private void Update()
    {
        Debug.Log("Update loop in Console Trigger");

        if (benchEnabled)
        {
            Debug.Log("Registered c press");
            SomeCoolAction();
        }
    }

    public void SomeCoolAction()
    {
        //open UI
        //for now though just print to console
        Debug.Log("Registered the interaction with the console");
       // pressed = true;


    }
}
