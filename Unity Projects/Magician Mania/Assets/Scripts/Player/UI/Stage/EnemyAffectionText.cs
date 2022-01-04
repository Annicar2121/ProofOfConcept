using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAffectionText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public Enemy1 script;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Enemy Affection: " + script.audience.EnemyAffection + " / " + script.audience.eaffectionSlider.maxValue;
    }
}
