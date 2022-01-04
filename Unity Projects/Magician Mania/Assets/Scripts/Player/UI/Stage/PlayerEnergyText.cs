using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    private Player script;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        script = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Player Energy: " + script.energy ;
    }
}
