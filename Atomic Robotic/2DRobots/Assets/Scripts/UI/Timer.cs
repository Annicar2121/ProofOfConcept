using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public Boolean timerIsRunning= false;
    public Text timeText;
    public Boolean outOfTime;

    private void Start()
    {
        timerIsRunning = false;
        timeText.text = "";
        outOfTime = false;
    }


    //start the timer
    public void start()
    {
        Debug.Log("Started the timer");
        timerIsRunning = true;
        Update();
    }

    void Update()
    {
        //Debug.Log("In timer update, timerIsRunning is " + timerIsRunning);
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                //Debug.Log("Time running is "+ timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                outOfTime = true;
            }
        }

    }


    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}