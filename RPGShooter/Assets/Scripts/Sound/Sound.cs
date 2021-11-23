using UnityEngine;
using UnityEngine.Audio;

public class Sound
{
    public string name;
    private AudioSource source;

    private AudioClip clip;
    private float volume = 0.5f;
    private float pitch = 0.5f;
    private bool isLoop = false;
    public Sound(string name, AudioSource source, AudioClip clip, bool loop=false)
    {
        this.name = name;
        this.source = source;
        this.clip = clip;
        this.isLoop = loop;
        SetSource(clip, this.pitch, this.volume, loop);
    }

    public void SetSource(AudioClip clip, float pitch, float volume, bool loop)
    {
        this.source.clip = clip;
        this.source.pitch = pitch;
        this.source.volume = volume;
        this.source.loop = loop;
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
        this.source.PlayOneShot(this.clip);
    }

    public void Stop()
    {
        this.source.Stop();
    }
}
