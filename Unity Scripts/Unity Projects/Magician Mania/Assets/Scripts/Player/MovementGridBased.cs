using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGridBased : MonoBehaviour
{

    public float movespeed;
    public Transform movePoint;
    public Transform shootPoint;
    public Rigidbody2D rb;
    public LayerMask whatStopsMovement;
    public Animator animator;
    //private int dir;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movespeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                float direction = Input.GetAxisRaw("Horizontal");
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .1f, whatStopsMovement))
                {
                    
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }

                if (direction == 1f)
                {
                    //dir = 0;
                    animator.SetInteger("direction", 1);
                    shootPoint.position = new Vector3(transform.position.x + 1f, transform.position.y , transform.position.z);
                    shootPoint.eulerAngles = new Vector3(0f, 0f, 270f);
                    
                }
                else
                {
                    animator.SetInteger("direction", 3);
                    shootPoint.position = new Vector3(transform.position.x - 1f, transform.position.y , transform.position.z);
                    shootPoint.eulerAngles = new Vector3(0f, 0f, 90f);
                }
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                float direction = Input.GetAxisRaw("Vertical");
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .1f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }


                if (direction == 1f)
                {
                    animator.SetInteger("direction", 0);
                    shootPoint.position = new Vector3(transform.position.x , transform.position.y + 1f, transform.position.z);
                    shootPoint.eulerAngles = new Vector3(0f, 0f, 0f);

                }
                else
                {
                    animator.SetInteger("direction", 2);
                    shootPoint.position = new Vector3(transform.position.x , transform.position.y - 1f, transform.position.z);
                    shootPoint.eulerAngles = new Vector3(0f, 0f, 180f);

                }
            }
        }
    }

}
