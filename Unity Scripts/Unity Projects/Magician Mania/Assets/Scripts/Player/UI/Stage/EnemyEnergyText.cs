using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyEnergyText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    private Enemy1 script;
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy 1");
        script = enemy.GetComponent<Enemy1>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Enemy Energy: "+ script.energy;
    }
}
