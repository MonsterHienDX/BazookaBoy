using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonobehaviour<AudioManager>
{
    [SerializeField] private List<SoundInfo> audioList = null;

    private AudioSource audioSource;
    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    public AudioClip GetSound(string stringName)
    {
        Enum.TryParse(stringName, out SoundName s);
        return GetSound(s);
    }

    public AudioClip GetSound(SoundName soundName)
    {
        for (int i = 0; i < audioList.Count; i++)
        {
            if (audioList[i].soundName == soundName)
                return audioList[i].sound;
        }
        return null;
    }

    public static void PlaySound(AudioSource source, AudioClip clip, bool isLoop = false)
    {
        if (!UserData.SoundSetting) return;

        if (source && clip)
        {
            source.clip = clip;
            source.loop = isLoop;
            source.Play();
        }
    }

    public static void PlaySound(AudioSource source, SoundName soundName, bool isLoop = false)
    {
        if (!UserData.SoundSetting) return;
        AudioClip clip = AudioManager.instance.GetSound(soundName);
        PlaySound(source, clip);
    }

    public void PlayManagerSound(SoundName soundName)
    {
        if (!UserData.SoundSetting) return;

        this.audioSource.clip = GetSound(soundName);
        this.audioSource.loop = false;
        this.audioSource.Play();
    }
}
