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

    public void StopSound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.Stop();
                return;
            }
        }
        Debug.LogWarning("Sound: " + name + " not found");
    }

    public void PlaySong(string name)
    {
        this.StopAllSounds();
        this.PlaySound(name);
    }

    private void StopAllSounds()
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.Stop();
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

    private void PlaySoundTrackForScene()
    {
        int y = SceneManager.GetActiveScene().buildIndex;

        switch (y)
        {
            case 0:
                PlaySong("Opening");
                break;
            case 1:
                PlaySong("Windless Slopes");
                break;

            case 2:
                PlaySong("Cozy Inn");
                break;

            case 3:
                PlaySong("Wind Walker");
                break;

            default:
                break;
        }

    }
}
