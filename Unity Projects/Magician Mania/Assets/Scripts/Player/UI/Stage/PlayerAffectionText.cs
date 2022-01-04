using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAffectionText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public Player script;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Player Affection: "+ script.audience.playerAffection +  " / " + script.audience.eaffectionSlider.maxValue;
    }
}
