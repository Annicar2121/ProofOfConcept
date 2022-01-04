using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float timer = 0.0f;
    public float waitTime;
    private float scrollBar = 1.0f;
    public GameObject EnemyPrefab;
    public int enemyLimit = 0; 
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = scrollBar;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        timer += Time.deltaTime;

        if (enemies.Length < enemyLimit)
        {
            if (timer > waitTime)
            {
                SpawnEnemy();
                timer = timer - waitTime;
                Time.timeScale = scrollBar;
            }
        }
    }

    void SpawnEnemy()
    {
        GameObject Baddie = Instantiate(EnemyPrefab, transform.position, transform.rotation);
    }
}
