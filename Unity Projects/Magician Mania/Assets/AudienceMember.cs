using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceMember : MonoBehaviour
{
    //adjust this to change speed
    float speed;
    //adjust this to change how high it goes
    float height = 0.03f;
  
    //adjust this to change speed
  

    Vector3 pos;

    private void Start()
    {
        speed = Random.Range(3f,5f);
        pos = transform.position;
    }

    public void setSpeed(float NewSpeed)
    {
        speed = NewSpeed;
    }
    void Update()
    {

        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
