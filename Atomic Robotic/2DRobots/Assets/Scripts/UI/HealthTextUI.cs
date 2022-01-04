using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthTextUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text healthText;
    private Player script;
    // Start is called before the first frame update
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
