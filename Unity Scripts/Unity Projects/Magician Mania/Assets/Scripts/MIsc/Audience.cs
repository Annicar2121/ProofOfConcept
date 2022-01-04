using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audience : MonoBehaviour
{
    public bool primed;
    public bool distracted;
    public GameLoop gameLoop;
    public float Affection;
    public float playerAffection; 
    public float EnemyAffection;
    public Slider affectionSlider;
    public Slider paffectionSlider;
    public Slider eaffectionSlider;
    public Text playerAffectionText;
    public Text enemyAffectionText;
    public float MAX;
    float MaxTime = 2f;
    public float ActiveTime = 0f;
    public int moneyPot;
    private float currentValue = 0f;
    

    void start()
    {
        Affection = 60;
        primed = false;
        distracted = false;
        affectionSlider.value = 60f;
        MAX = 120f;
        MAX = 60f;
        playerAffection = 0;
        EnemyAffection = 0;
    }

    private void Update()
    {
        fill();
        checkStatus();
        CheckEndCondition();
    }

    public void changePlayerAffection(float affection)
    {
        Affection += affection;
        playerAffection += affection;
        paffectionSlider.value += affection;
        ActiveTime = 0;
        float step = affection;
        
        if ((MAX + step) > 120)
        {
            MAX = 120;
        }
        else
        {
            MAX += step;
        }

        

    }

    public void changeEnemyAffection(float affection)
    {
        Affection -= affection;
        EnemyAffection += affection;
        eaffectionSlider.value += affection;
        ActiveTime = 0;
        float step = affection;
       

        if ((MAX - step) < 0)
        {
            MAX = 0;
        }
        else
        {
            MAX -= step;
        }

        gameLoop.Whosturn = 0;
    }


    public void fill()
    {
        if (!((affectionSlider.value > Affection + 1) && (affectionSlider.value < Affection - 1)))
        {
            if ((affectionSlider.value < MAX))
            {

                ActiveTime += Time.deltaTime;
                float percent = ActiveTime / MaxTime;
                currentValue = Mathf.Lerp(0, 1, percent);
                affectionSlider.value += currentValue;
            }

            else if ((affectionSlider.value > MAX) && affectionSlider.value > 0)
            {

                ActiveTime += Time.deltaTime;
                float percent = ActiveTime / MaxTime;
                currentValue = Mathf.Lerp(0, 1, percent);
                affectionSlider.value -= currentValue;
            }
        }
    }
    public void checkStatus()
    {
        GameObject[] amarks = GameObject.FindGameObjectsWithTag("amarks");
        GameObject[] qmarks = GameObject.FindGameObjectsWithTag("qmarks");
        if (primed)
        {           
            
            foreach (GameObject amark in amarks)
            {
                amark.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
         
            foreach (GameObject amark in amarks)
            {
                amark.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (distracted)
        {
            
            foreach (GameObject qmark in qmarks)
            {
                qmark.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            
            foreach (GameObject qmark in qmarks)
            {
                qmark.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
    public void CheckEndCondition()
    {
        if(playerAffection >= paffectionSlider.maxValue ){
            float percentage = affectionSlider.value / affectionSlider.maxValue;
            float Payout = moneyPot * percentage;
            int pay = (int)Payout;
            gameLoop.End(pay,1);
        }
        if((EnemyAffection >= eaffectionSlider.maxValue))
        {
            float percentage = affectionSlider.value / affectionSlider.maxValue;
            float Payout = moneyPot * percentage;
            int pay = (int)Payout;
            gameLoop.End(pay,0);
        }
    }
}
