using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    public Transform myTransform;
    private Vector3 moveDirection;
    //private Animator animator;
    private float lastHorizontal;
    private float lastVertical;
    private float lastZ;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

    }
    
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveZ = 0;
        moveDirection = new Vector3(moveHorizontal, moveZ, moveVertical ).normalized;



        if (moveHorizontal == 0 && moveVertical == 0) { 
        //animator.SetFloat("Horizontal", lastHorizontal);
        //animator.SetFloat("Vertical", lastVertical);
            }
        else
        {
            //animator.SetFloat("Horizontal", moveX);
            //animator.SetFloat("Vertical", moveY);
            setLast(moveHorizontal, moveVertical, moveZ);
        }
        
    }
    void setLast(float a, float b, float c)
    {
        lastHorizontal = a;
        lastVertical = b;
        lastZ = c;

    }
    void Move()
    {
       // Vector3 movement = new Vector3(moveDirection.x * moveSpeed, 0.0f, moveDirection.z * moveSpeed);
        //rb.AddForce(movement * moveSpeed);
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, 0.0f, moveDirection.z * moveSpeed);

    }
}
