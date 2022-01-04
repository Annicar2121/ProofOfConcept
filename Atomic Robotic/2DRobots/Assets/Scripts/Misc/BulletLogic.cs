using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 1;
    public GameObject hitEffect;
    private int EnemyDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //hardcoded for now, increase the damage the players gun does
    //to enemies
    public void increaseGunDamage(int amount)
    {
        damage = damage + 1;
    }

    // Update is called once per frame
   

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Player player = hitInfo.GetComponent<Player>();
        if (enemy != null)
        {
            //Debug.Log("Enemy hit");
            enemy.TakeDamage(damage);
        }

        //player hit, lose health
        if (player != null)
        {
            Debug.Log("Player hit");
            player.playerHealth.DamagePlayer(EnemyDamage);
            SoundFXManagerScript.PlaySound("playerHit");
        }
        //Debug.Log(hitInfo.name);
        
        Destroy(gameObject);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    }
}
