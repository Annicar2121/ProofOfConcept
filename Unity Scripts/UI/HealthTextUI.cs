using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
A simple class for desplaying Health Text in the UI
**/
public class HealthTextUI : MonoBehaviour
{
    // An attatched text object that contains the # of health points
    public Text healthText;
    // A script which houses the player class and all it's components
    private Player script;

    void Start()
    {
        GameObject player = GameObject.Find("PlayerCharacter");
        script = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + script.health;
    }
}
