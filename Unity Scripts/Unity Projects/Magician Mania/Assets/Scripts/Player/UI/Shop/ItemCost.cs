using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCost : MonoBehaviour
{
    public Text text;
    string update;
    public UI_Shop shop;

    // Start is called before the first frame update
    void Start()
    {
        update = "Cost: ???";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = update;
    }

    public void setItem(int cost)
    {
        update = "Cost: " + cost;
    }
}
