using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    List<Sound> sounds = new List<Sound>();

    private void Awake()
    {
        if (SoundManager.instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        GetAllSoundsFromFolder();
    }

    public void PlaySound(string name)
    {
        foreach(Sound s in sounds)
        {
            if (s.name == name)
            {
                s.Play();
                break;
            }
        }
    }

    private void GetAllSoundsFromFolder()
    {
        UnityEngine.Object[] audioClips = Resources.LoadAll("Audio", typeof(AudioClip));

        foreach(UnityEngine.Object obj in audioClips)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            Sound sound = new Sound(obj.name, source, (AudioClip)obj);
            sounds.Add(sound);
        }
    }
}
