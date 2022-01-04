using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleCount : MonoBehaviour
{
    private Text thisText;
    private int count;
    private int fixedC;
    public BrokenConsoleManager manager;

    void Start()
    {
        thisText = GetComponent<Text>();
        count = manager.numConsoles();
        fixedC = manager.numFixed();

    }

    void Update()
    {
        // update text of Text element
        count = manager.numConsoles();
        fixedC = manager.numFixed();
        thisText.text = "[Repair Consoles: (" + fixedC + "/"+ count + ")]";
    }

}

