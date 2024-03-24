using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    // public Sound[] sounds;

    public void PlayAudio(AudioClip audio, float volumn)
    {

        //throw new System.NotImplementedException();
        GameObject audioSourceObject = new GameObject("TemporaryAudioSource");
        AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();

        audioSource.PlayOneShot(audio, volumn);
        // Invoke("audioSource.Stop()", 1);
        Destroy(audioSourceObject, audio.length);
    }
}

/*
// no singleton

using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance; // replace singleton
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {   // avoid rep during scene switch
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volumn;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Misspelling of the audio " + name + "!");
            return;
        }
        s.source.Play();
    }
    void Start()
    {
        Play("background");
    }
}
*/
// if you gonna implement a singleton, try the following

/*
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] sounds;
    // public static AudioManager instance; // replace singleton
    void Awake()
    {

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volumn;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Misspelling of the audio " + name + "!");
            return;
        }
        s.source.Play();
    }
    void Start()
    {
        Play("background");
    }
}
*/