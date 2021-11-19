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
        else
        {
            GetAllSoundsFromFolder();
        }
        instance = this;
        // Prevent being destroyed between scenes
        DontDestroyOnLoad(gameObject);
        PlaySound("Windless Slopes");
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
        Debug.LogWarning("Sound: " + name + " not found");
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
