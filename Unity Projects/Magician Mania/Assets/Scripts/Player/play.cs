using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
	 public AudioSource AudioClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    { 
       // If the left mouse button is pressed down...
       if(Input.GetMouseButtonDown(0) == true)
       {
         //GetComponent<AudioSource>().Play();
        AudioClip.Play();
       } 
        // If the left mouse button is released...
        if(Input.GetMouseButtonUp(0) == true)
        {
        //GetComponent<AudioSource>().Stop();
          AudioClip.Stop();
        }
    }

}
