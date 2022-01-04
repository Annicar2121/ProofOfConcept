using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManagerScript : MonoBehaviour
{

    public static AudioClip playerHit, bulletSound, bulletSound2, enemyHit, enemyAttack, playerToxicDrain, bossHit, bossAttack, bossDead;
    static AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {

        playerHit = Resources.Load<AudioClip>("playerHit");
        bulletSound = Resources.Load<AudioClip>("bulletSound");
        bulletSound2 = Resources.Load<AudioClip>("bulletSound2");
        enemyHit = Resources.Load<AudioClip>("enemyHit");
        enemyAttack = Resources.Load<AudioClip>("enemyAttack");
        playerToxicDrain = Resources.Load<AudioClip>("playerToxicDrain");
        bossHit = Resources.Load<AudioClip>("bossHit");
        bossAttack = Resources.Load<AudioClip>("bossAttack");
        bossDead = Resources.Load<AudioClip>("bossDead");

        audioSource = GetComponent<AudioSource>();
    }
    
    public static void PlaySound(string clip) {
        switch (clip) {
            case "playerHit":
                audioSource.PlayOneShot(playerHit);
                break;
            case "enemyHit":
                audioSource.PlayOneShot(enemyHit);
                break;
            case "enemyAttack":
                audioSource.PlayOneShot(enemyAttack);
                break;
            case "bulletSound":
                audioSource.PlayOneShot(bulletSound);
                break;
            case "bulletSound2":
                audioSource.PlayOneShot(bulletSound2);
                break;
            case "playerToxicDrain":
                audioSource.PlayOneShot(playerToxicDrain);
                break;
            case "bossHit":
                audioSource.PlayOneShot(bossHit);
                break;
            case "bossAttack":
                audioSource.PlayOneShot(bossAttack);
                break;
            case "bossDead":
                audioSource.PlayOneShot(bossDead);
                break;
        }
    }
}
