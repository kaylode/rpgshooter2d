using UnityEngine;
using UnityEngine.Audio;

public class Sound
{
    public string name;
    private AudioSource source;

    private AudioClip clip;
    private float volume = 0.5f;
    private float pitch = 0.5f;

    public Sound(string name, AudioSource source, AudioClip clip)
    {
        this.name = name;
        this.source = source;
        this.clip = clip;
        SetSource(clip, this.pitch, this.volume);
    }

    public void SetSource(AudioClip clip, float pitch, float volume)
    {
        this.source.clip = clip;
        this.source.pitch = pitch;
        this.source.volume = volume;
    }

    public void SetPitch(float pitch)
    {
        this.source.pitch = pitch;
    }

    public void SetVolume(float volume)
    {
        this.source.volume = volume;
    }
    public void Play()
    {
        this.source.Play();
    }
}
