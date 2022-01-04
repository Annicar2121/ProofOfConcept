using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePercentage : MonoBehaviour
{
    private Text thisText;
    private int life;
    public Health playerHealth;

    void Start()
    {
        thisText = GetComponent<Text>();
        life = playerHealth.curHealth;

    }

    void Update()
    {
        // update text of Text element
        life = playerHealth.curHealth;
        thisText.text = ""+life+"%";
    }

}
