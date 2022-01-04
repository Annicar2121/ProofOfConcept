using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartCount : MonoBehaviour
{
    private Text thisText;
    private int count;
    public Player player;
    public int partIndex;

    void Start()
    {
        thisText = GetComponent<Text>();
        count = player.allParts[partIndex];

    }

    void Update()
    {
        // update text of Text element
        count = player.allParts[partIndex];
        thisText.text = "X" + count ;
    }

}
