using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip laserSound, explosionSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        laserSound = Resources.Load<AudioClip>("Lazer1");
        explosionSound = Resources.Load<AudioClip>("Explosion");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "lazer":
                audioSrc.PlayOneShot(laserSound);
                break;
            case "explosion":
                audioSrc.PlayOneShot(explosionSound);
                break;
        }
    }
}
