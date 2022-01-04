using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootingscript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform shootPoint;
    public GameObject LaserPrefab;
    public float bulletForce = 20f;
    public float rof;
    public Camera cam;
    private bool canFire = true;
    private float gunCooldown;
    private bool doubleFire = false;
    private bool angleFire = false;
    //private bool StrongFire = false;
    private float doubleFireWait = 0f;
  

    public void Start()
    {
    }
    public void setDoubleFire(bool x)
    {
        doubleFire = x;
    }
    public void setAngleFire(bool x)
    {
        doubleFire = x;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
		    if(canFire){
               	Shoot();
                gunCooldown = Time.time + rof;
                doubleFireWait = Time.time + .25f;
		        canFire = false;
		    }
        }
        if (doubleFire && (doubleFireWait != 0f) && Time.time > doubleFireWait)
        {
            Shoot();
            doubleFireWait = 0f;
        }
        if (!canFire && Time.time > gunCooldown){
	canFire = true;
	}
    }
    
    void Shoot()
    {
        //shooting logic
        if (angleFire)
        {
            shootPoint.Rotate(shootPoint.rotation.x, shootPoint.rotation.y, shootPoint.rotation.x + 5f);
            GameObject bullet = Instantiate(LaserPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootPoint.up * bulletForce, ForceMode2D.Impulse);
            SoundFXManagerScript.PlaySound("bulletSound2");
            shootPoint.Rotate(shootPoint.rotation.x, shootPoint.rotation.y, shootPoint.rotation.x - 10f);
            GameObject bullet2 = Instantiate(LaserPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.AddForce(shootPoint.up * bulletForce, ForceMode2D.Impulse);
            SoundFXManagerScript.PlaySound("bulletSound2");
            shootPoint.Rotate(shootPoint.rotation.x, shootPoint.rotation.y, shootPoint.rotation.x + 5f);
        }
        else
        {
            GameObject bullet = Instantiate(LaserPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootPoint.up * bulletForce, ForceMode2D.Impulse);
            SoundFXManagerScript.PlaySound("bulletSound");
        }
    }
}
