using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 3;
    public float moveSpeed;
    public Rigidbody2D rb;
   // private float timer = 0.0f;
    public float waitTime;
   // private float scrollBar = 1.0f;
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 1f;
    private float characterVelocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public GameObject PartOnePrefab;
    public GameObject PartTwoPrefab;

    public void TakeDamage(int damage)
    {
        health -= damage;
        SoundFXManagerScript.PlaySound("enemyHit");
        
    }

    void Start()
    {
         
     latestDirectionChangeTime = 0f;
     calcuateNewMovementVector();
    }
    void calcuateNewMovementVector(){
    //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
     movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
     movementPerSecond = movementDirection * characterVelocity;
 }
    void FixedUpdate()
    {
        if (Time.time - latestDirectionChangeTime > directionChangeTime){
         latestDirectionChangeTime = Time.time;
         calcuateNewMovementVector();
     }
     
     //move enemy: 
     rb.MovePosition(rb.position + movementDirection * Time.fixedDeltaTime);

        if (health <= 0)
        {
            Die();
        }
    }
    // Update is called once per frame
    void Die()
    {
        GameObject spring = Instantiate(PartOnePrefab, transform.position, transform.rotation);
        GameObject bolt = Instantiate(PartTwoPrefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        
     calcuateNewMovementVector();
       
    }

}