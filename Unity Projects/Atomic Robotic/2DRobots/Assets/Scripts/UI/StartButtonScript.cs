using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    AudioClip clip,clip2,clip3;
    AudioManager audio;

    public void Start()
    {
        clip = Resources.Load<AudioClip>("MainTrack1");
        clip2 = Resources.Load<AudioClip>("winSong");
        clip3 = Resources.Load<AudioClip>("loseSong");
        audio = FindObjectOfType<AudioManager>();

    }

    public void PlayGameMusic() {

        audio.initMainMusic(clip);
    }

   
}
