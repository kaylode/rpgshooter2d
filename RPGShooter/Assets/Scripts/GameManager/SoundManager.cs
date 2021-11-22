using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

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
        PlaySoundTrackForScene();
    }

    public void PlaySound(string name)
    {
        foreach(Sound s in sounds)
        {
            if (s.name == name)
            {
                s.Play();
                return;
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

    private void PlaySoundTrackForScene()
    {
        int y = SceneManager.GetActiveScene().buildIndex;

        switch (y)
        {
            case 0:
                PlaySound("Opening");
                break;
            case 1:
                PlaySound("Windless Slopes");
                break;

            case 2:
                PlaySound("Cozy Inn");
                break;

            case 3:
                PlaySound("Wind Walker");
                break;

            default:
                break;
        }

    }
}
