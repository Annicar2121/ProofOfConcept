using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{
    public GameObject UIObject;
    public GameObject trigger;

    // private bool benchEnabled = false;
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
            Debug.Log("Active trigger for door");
            pressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Deactive trigger for door");
        UIObject.SetActive(false);
        pressed = false;
    }
}
