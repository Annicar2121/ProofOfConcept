using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAmount : MonoBehaviour
{
    public Text text;
    string update;
    public UI_Shop shop;

    // Start is called before the first frame update
    void Start()
    {
        update = "Quantity: ???";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = update;
    }

    public void setItem(int amount)
    {
        update = "Quantity: " + amount;
    }

}
