using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    bool isMute = false;

    [SerializeField]
    AudioSource backgroundMusic, soundEffect;

    [SerializeField]
    SoundSfx[] soundEffects;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            PlayMusic();
        }
    }
    public void PlayMusic()
    {
        if (isMute)
        {
            return;
        }
        backgroundMusic.Play();
    }

    public void PlayEffect(SoundTypesSfx effectType)
    {
        if (isMute)
        {
            return;
        }

        AudioClip effectClip = GetSoundEffectClip(effectType);
        if (soundEffect.clip == effectClip)
        {
            return;
        }
        soundEffect.PlayOneShot(effectClip);
    }

    public void ToggleMute()
    {
        isMute = !isMute;
        PlayMusic();
    }

    AudioClip GetSoundEffectClip(SoundTypesSfx effectType)
    {
        SoundSfx soundEffect = Array.Find(soundEffects, item => item.soundType == effectType);
        if (soundEffect != null)
        {
            return soundEffect.soundClip;
        }
        return null;
    }
}

[Serializable]
public class SoundSfx
{
    public SoundTypesSfx soundType;
    public AudioClip soundClip;
}

public enum SoundTypesSfx
{
    ButtonClick,
    ButtonLocked,
    PlayerDeath,
    PlayerJump

}
