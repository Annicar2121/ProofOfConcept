using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int curHealth = 0;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public Animator feedBack;
    public GameObject decal;
    private bool beenDamaged = false;
    private float decalTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        GameObject emote = GameObject.FindGameObjectWithTag("Emote");
        feedBack = emote.GetComponent<Animator>();

        decal = GameObject.FindGameObjectWithTag("DamageDecal");
        decal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (beenDamaged)
        {
            decalTime -= Time.deltaTime;
            if ( decalTime <= 0.0f)
            {
                decalTime = 0.5f;
                beenDamaged = false;
                decal.SetActive(false);
            }
        }
    }

    //For healthbar UI
    public void DamagePlayer(int damage)
    {
        if ((curHealth - damage) <= 0)
        {
            curHealth = 0;
        }
        else
        {
            curHealth -= damage;
        }
        beenDamaged = true;
        decal.SetActive(true);
        healthBar.setHealth(curHealth);
        feedBack.SetTrigger("PlayerHit");
    }

    //heal player by specified amount
    public void healPlayer(int amount)
    {
        if (curHealth + amount > maxHealth)
        {
            curHealth = maxHealth;
        }
        else
        {
            curHealth = curHealth + amount;
        }
    }

    //heal player by specified amount
    public void upgradeHealth(int amount)
    {
        maxHealth = maxHealth + amount;
    }

}
