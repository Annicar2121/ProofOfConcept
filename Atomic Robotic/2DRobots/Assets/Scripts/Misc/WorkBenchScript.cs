using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkBenchScript : MonoBehaviour
{
    public Transform myTransform;
    public Text UItext;
    public LayerMask playerMask;
    public GameObject UIobject;
    
    // Start is called before the first frame update

    public void OpenWorkBench()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Collider2D collider = Physics2D.OverlapCircle(new Vector2(myTransform.position.x, myTransform.position.y), 1f, playerMask);
        if (collider != null)
        {
            Debug.Log("ON WORKBENCH");
            UItext.text = "Press F to open Workbench";
                {
                    if (Input.GetKeyUp("f"))
                    {
                        UIobject.transform.localScale = new Vector3(1f, 1f, 1f);

                }
                }
            }
     }
 
}
