using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteController : MonoBehaviour
{
    public GameObject playerObj;
    private Player playerScript;
    public Animator anim;
    private float prevHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerObj.GetComponent<Player>();
        anim = GetComponent<Animator>();
        prevHealth = playerScript.health;
    }

    // Update is called once per frame
    void Update()
    {
        //float curHealth = playerScript.health;
        //if (curHealth < prevHealth)
        //{
        //    anim.SetTrigger("PlayerHit");
        //    prevHealth = curHealth;
        //}
        anim.SetBool("IsRads", playerScript.isIn);
        
    }
}
