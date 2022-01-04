using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    Animator anim;
    public Transition ts;
    public int DoorNumber;
    private PersistentPlayer pp;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInParent<Animator>();
        pp = Object.FindObjectOfType<PersistentPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (pp == null)
        {
            if (DoorNumber == 1)
            {
                anim.SetTrigger("Triggered");
                ts.LoadLevel(DoorNumber);
                anim.SetBool("DoorState", true);
            }
        }
        else if(DoorNumber - 1 <= pp.whichBattle)
        {
            anim.SetTrigger("Triggered");
            ts.LoadLevel(DoorNumber);
            anim.SetBool("DoorState", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("DoorState", false);
    }
}
