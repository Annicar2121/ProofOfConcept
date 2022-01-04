using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform myTransform;
    public Transform shootPoint;
    public GameObject projectilePrefab;
    public LayerMask playerMask;
    public float waitTime;
    public float bulletForce;
    private float scrollBar = 1.0f;
    private float timer = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = scrollBar;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            Shoot();
            timer = timer - waitTime;
            Time.timeScale = scrollBar;
        }
    }

    //call function in bulletlogic
    public void upgradeGun(int amount)
    {
        projectilePrefab.GetComponent<BulletLogic>().increaseGunDamage(1);
    }

    void Shoot()
    {
        Debug.DrawRay(myTransform.position, Vector2.up, Color.magenta, 20f);
     
        RaycastHit2D hitRight = Physics2D.Raycast(myTransform.position, Vector2.right, 20f, playerMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(myTransform.position, Vector2.left, 20f, playerMask);
        RaycastHit2D hitUp = Physics2D.Raycast(myTransform.position, Vector2.up, 20f, playerMask);
        RaycastHit2D hitDown = Physics2D.Raycast(myTransform.position, Vector2.down, 20f, playerMask);
        
        if (hitRight.collider != null) 
        {
            Debug.Log(hitRight.collider.name);
            shootPoint.position = new Vector3(myTransform.position.x + 1f, myTransform.position.y, myTransform.position.z);
            shootPoint.eulerAngles = new Vector3(0f, 0f, -90f);
            GameObject bullet = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootPoint.up * bulletForce, ForceMode2D.Impulse);
        }

        

        if (hitLeft.collider != null)
        {
           // Debug.Log(hitRight.collider.name);
            shootPoint.position = new Vector3(myTransform.position.x - 1.5f, myTransform.position.y, myTransform.position.z);
            shootPoint.eulerAngles = new Vector3(0f, 0f, -270f);
            GameObject bullet = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootPoint.up * bulletForce, ForceMode2D.Impulse);
        }
        

        if (hitUp.collider != null)
        {
            Debug.Log(hitUp.collider.name);
            shootPoint.position = new Vector3(myTransform.position.x , myTransform.position.y + 1f, myTransform.position.z);
            shootPoint.eulerAngles = new Vector3(0f, 0f, 0f);
            GameObject bullet = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootPoint.up * bulletForce, ForceMode2D.Impulse);
        }
        

        if (hitDown.collider != null)
        {
            Debug.Log(hitDown.collider.name);
            shootPoint.position = new Vector3(myTransform.position.x , myTransform.position.y - 1f, myTransform.position.z);
            shootPoint.eulerAngles = new Vector3(0f, 0f, -180f);
            GameObject bullet = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootPoint.up * bulletForce, ForceMode2D.Impulse);
        }



    }
}
