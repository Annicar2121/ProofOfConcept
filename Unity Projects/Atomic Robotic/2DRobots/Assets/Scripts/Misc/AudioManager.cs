using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource BGM;
    //public AudioClip winSong, loseSong;

    public void Start()
    {
        
    }
    //change music when you enter different rooms
    public void changeBGM(AudioClip music)
    {

        if (BGM.clip.name == music.name)
        {
            return;
        }
        float mTime = BGM.time;

        BGM.Stop();
        BGM.clip = music;
        BGM.time = mTime + 0.01f;
        BGM.Play();


    }

    public void initMainMusic(AudioClip music)
    {
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }

    public void initEndSong(AudioClip music)
    {
        
        BGM.loop = false;
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
   
}
