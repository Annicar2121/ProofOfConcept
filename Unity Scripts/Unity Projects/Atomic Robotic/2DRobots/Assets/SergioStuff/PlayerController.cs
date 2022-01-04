using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera sceneCamera;
    public float moveSpeed;
    public Rigidbody2D rb;
    public Transform shootPoint;
    public Transform myTransform;
    private Vector2 moveDirection;
    private Vector2 mousePosition;
    public Animator animator;
    private float lastHorizontal;
    private float lastVertical;

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
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        if(moveX == 0 && moveY == 0) { 
        animator.SetFloat("Horizontal", lastHorizontal);
        animator.SetFloat("Vertical", lastVertical);
            }
        else
        {
            animator.SetFloat("Horizontal", moveX);
            animator.SetFloat("Vertical", moveY);
            setLast(moveX, moveY);
        }
        
    }
    void setLast(float a, float b)
    {
        lastHorizontal = a;
        lastVertical = b;
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        if (!(moveDirection.x == 0 && moveDirection.y == 0))
        {
            shootPoint.position = new Vector3(rb.position.x + moveDirection.x, rb.position.y + moveDirection.y, myTransform.position.z);
            float aimAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
            shootPoint.eulerAngles = new Vector3(0, 0, aimAngle);
        }
        

      

    }
}
