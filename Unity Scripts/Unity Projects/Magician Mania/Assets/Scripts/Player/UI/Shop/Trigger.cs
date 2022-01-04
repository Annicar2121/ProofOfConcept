using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject UIObject;
    public GameObject trigger;

    public bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        UIObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UIObject.SetActive(true);
            Debug.Log("Active trigger");
            pressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Deactive trigger");
        UIObject.SetActive(false);
        pressed = false;
    }
}
