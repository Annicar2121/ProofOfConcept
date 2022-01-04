using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public Text text;
    string update;

    // Start is called before the first frame update
    void Start()
    {
        update = "$$ ";
    }

    // Update is called once per frame
    void Update()
    {
        PersistentPlayer p= GameObject.FindObjectOfType<PersistentPlayer>();
        int amount = p.money;
        update = "$$ " + amount;
        text.text = update;
    }

}
