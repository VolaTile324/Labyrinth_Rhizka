using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource bgmInst;
    static AudioSource sfxInst;
    static AudioSource sfxInst2;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioSource sfx2;

    public bool IsBGMMuted { get => bgm.mute; }
    public bool IsSFXMuted { get => sfx.mute; }
    public float BGMVolume { get => bgm.volume; }
    public float SFXVolume { get => sfx.volume; }

    private void Awake()
    {
        // load from player prefs
        bgm.mute = PlayerPrefs.GetInt("BGMMute", 0) == 1;
        sfx.mute = PlayerPrefs.GetInt("SFXMute", 0) == 1;
        bgm.volume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        sfx.volume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        if (bgmInst != null)
        {
            Destroy(bgm.gameObject);
            bgm = bgmInst;
        }
        else
        {
            bgmInst = bgm;
            bgm.transform.SetParent(null);
            DontDestroyOnLoad(bgm.gameObject);
        }

        if (sfxInst != null)
        {
            Destroy(sfx.gameObject);
            sfx = sfxInst;
        }
        else
        {
            sfxInst = sfx;
            sfx.transform.SetParent(null);
            DontDestroyOnLoad(sfx.gameObject);
        }

        if (sfxInst2 != null)
        {
            Destroy(sfx2.gameObject);
            sfx2 = sfxInst2;
        }
        else
        {
            sfxInst2 = sfx2;
            sfx2.transform.SetParent(null);
            DontDestroyOnLoad(sfx2.gameObject);
        }
    }

    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (bgm.isPlaying)
        {
            bgm.Stop();
        }

        bgm.clip = clip;
        bgm.loop = loop;
        bgm.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.clip = clip;
        sfx.Play();
    }

    public void PlaySFX2(AudioClip clip)
    {
        sfx2.clip = clip;
        sfx2.Play();
    }

    public void SetBGMMute(bool value)
    {
        bgm.mute = value;
        // save to player prefs
        PlayerPrefs.SetInt("Mute", value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetSFXMute(bool value)
    {
        sfx.mute = value;
        sfx2.mute = value;
        // save to player prefs
        PlayerPrefs.SetInt("SFXMute", value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetBGMVolume(float value)
    {
        bgm.volume = value;
        // save to player prefs
        PlayerPrefs.SetFloat("BGMVolume", value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float value)
    {
        sfx.volume = value;
        sfx2.volume = value;
        // save to player prefs
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }
}
