using UnityEngine;

public class SoundController
{
    private AudioSource soundEffect, backgroundMusic;
    private SoundType[] soundType;
    public SoundController(AudioSource soundEffect, AudioSource backgroundMusic, SoundType[] soundType)
    {
        this.soundEffect = soundEffect;
        this.backgroundMusic = backgroundMusic;
        this.soundType = soundType;
    }
    public void PlayBGMusic(Sounds sound)
    {
        AudioClip clip = GetAudioClip(sound);
        if (clip != null)
        {
            backgroundMusic.clip = clip;
            backgroundMusic.Play();
        }
        else
        {
            Debug.LogError(string.Format("{0}, Audio clip not found.", sound.ToString()));
        }
    }
    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = GetAudioClip(sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError(string.Format("{0}, Audio clip not found.", sound.ToString()));
        }
    }
    private AudioClip GetAudioClip(Sounds sound)
    {
        SoundType existingSound = System.Array.Find<SoundType>(soundType, item => item.soundType == sound);
        if (existingSound != null)
        {
            return existingSound.soundAudio;
        }
        return null;
    }
}

[System.Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundAudio;
}