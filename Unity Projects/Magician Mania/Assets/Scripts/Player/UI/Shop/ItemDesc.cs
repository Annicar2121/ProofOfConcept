using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDesc : MonoBehaviour
{
    public Text text;
    string update;

    // Start is called before the first frame update
    void Start()
    {
        update = "[Click on Item To See Decsription]";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = update;
    }

    public void setItem(string type)
    {
        Debug.Log("Looking for " + type);
        //grab from a dictionary eventually, for now just filling in
        if(type == "popcorn")
        {
            update = "A Savory, Buttery Classic" +
                "\n+5 Affection";
        }else if(type == "gBears")
        {
            update = "Are you a Gummy Bear? Cause these are." +
                "\n +10 Affection";
        }
        else if (type == "soda")
        {
            update = "Are you one of those people who call it 'Pop'? Disgrace" +
                "\n +5 Affection";
        }
        else if (type == "coat")
        {
            update = "A snazzy coat for a snazzy Magician" +
                "\n +10 Boost to Affection";
        }
        else if (type == "wand")
        {
            update = "A Wand that.... may or may not actually work. Who knows?" +
                "\n +5 Boost to Affection";
        }
        else if (type == "tophat")
        {
            update = "What Magician is without a tophat? May contain Rabbits" +
                "\n +15 Boost to Affection";
        }
        else if (type == "hotdog")
        {
            update = "Hotdog! Hotdog! Get your hotdogs!" +
                "\n +10 Boost to Affection";
        }
        else if (type == "chocolate")
        {
            update = "Melty, gooey, goody-good CHOCO-LATE" +
                "\n +15 Boost to Affection";
        }
        else if (type == "ball")
        {
            update = "The Answer is... Cannot Predict Now, Try Again Later" +
                "\n Random Boost to Affection, 0-20";
        }
        else if (type == "gloves")
        {
            update = "A must-have for any sleight of hand" +
                "\n +8 Boost to Affection";
        }
    }
}
