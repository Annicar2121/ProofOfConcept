using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollision : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
 
        Player player = hitInfo.GetComponent<Player>();
        if(player != null){
            //pass whatever part it is to addPart() in player
            player.addPart(this.gameObject);
            Destroy(gameObject);
        }
    }
}
