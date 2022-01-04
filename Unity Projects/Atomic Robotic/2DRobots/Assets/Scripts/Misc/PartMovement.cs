using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartMovement : MonoBehaviour
{
    public Transform mytransform;
    public Rigidbody2D rb;
    public float direction;
    public float speed;
    public GameObject PlayerChar;
    public Player player;
    public Transform playerTransform;
    private Vector3 target;
    
   // public rigidBody rb;
    // Start is called before the first frame update
    void Start()
    {
        PlayerChar = GameObject.Find("PlayerCharacter");
        player = PlayerChar.GetComponent<Player>();
        rb.velocity = new Vector2(direction * speed, 0);
        speed = 0.5f;
      
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = PlayerChar.transform;
        if (player.getPartRet())
        {
        
            float step = speed * Time.deltaTime;
            mytransform.position = Vector3.MoveTowards(mytransform.position, playerTransform.position, step);
        }

    }
}
