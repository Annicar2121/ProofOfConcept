using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public int health;
    public float waitTime;
    public Transform myTransform;
    public Transform pTransform;
    public Transform shootPoint;
    public float bulletForce;
    public GameObject LaserPrefab;
    private bool actionTimer = true;

    // Start is called before the first frame update
    void Start()
    {
        health = 2;
        shootPoint.position = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Boss Health is " + health);
        if (health == 0)
        {
            Debug.Log("BOSS SHOULD BE DEAD!!!");
            
            Die();
        }
        else
        {

            if (Vector3.Distance(myTransform.position, pTransform.position) < 20)
            {

                if (actionTimer)
                {
                    Vector3 targetPos = pTransform.position;
                    Vector3 thisPos = myTransform.position;
                    targetPos.x = targetPos.x - thisPos.x;
                    targetPos.y = targetPos.y - thisPos.y;
                    float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
                    shootPoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 85f));
                    int choice = Random.Range(0, 4);
                    switch (choice)
                    {
                        case 0:
                            spreadShot();
                            SoundFXManagerScript.PlaySound("bossAttack");
                            break;
                        case 1:
                            directShot();
                            SoundFXManagerScript.PlaySound("bossAttack");
                            break;
                        case 2:
                            FrenzyShot();
                            SoundFXManagerScript.PlaySound("bossAttack");
                            break;
                        default:
                            directShot();
                            SoundFXManagerScript.PlaySound("bossAttack");
                            break;
                    }
                    waitTime = Time.time + 1f;
                    actionTimer = false;

                }
                if (!actionTimer && Time.time > waitTime)
                {
                    actionTimer = true;
                }
            }
        }
        
    }
    private void spreadShot()
    {
        shootPoint.Rotate(shootPoint.rotation.x, shootPoint.rotation.y, -60f);
        for (int i = 0; i < 8; i++)
        {
            shootPoint.Rotate(shootPoint.rotation.x, shootPoint.rotation.y, shootPoint.rotation.x + 15f);
            GameObject bullet = Instantiate(LaserPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootPoint.up * bulletForce, ForceMode2D.Impulse);
        }
       // shootPoint.eulerAngles = new Vector3(shootPoint.rotation.x, shootPoint.rotation.y, -180f);
    }

    private void FrenzyShot()
    {
        spreadShot();
        directShot();
        spreadShot();
        directShot();
       
       // shootPoint.eulerAngles = new Vector3(shootPoint.rotation.x, shootPoint.rotation.y, -180f);
    }

    private void directShot()
    {
        bulletForce = bulletForce + 5f;
    for (int i = 0; i < 3; i++)
    {
            Vector3 targetPos = pTransform.position;
            Vector3 thisPos = myTransform.position;
            targetPos.x = targetPos.x - thisPos.x;
            targetPos.y = targetPos.y - thisPos.y;
            float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
            shootPoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 85f));

            GameObject bullet = Instantiate(LaserPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootPoint.up * bulletForce, ForceMode2D.Impulse);
        }
      //  shootPoint.eulerAngles = new Vector3(shootPoint.rotation.x, shootPoint.rotation.y, -180f);
        bulletForce = bulletForce - 5f;
    }
    
    public void TakeDamage(int damage)
    {
        Debug.Log("BOSS TOOK DAMAGE");
        health -= damage;
        SoundFXManagerScript.PlaySound("bossHit");

    }
    private void Die()
    {
        Destroy(this);
        Destroy(GameObject.Find("bossplant (1)"));
        SoundFXManagerScript.PlaySound("bossDead");
    }
}
