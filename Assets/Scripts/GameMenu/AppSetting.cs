using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Audio;

public class AppSetting : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] TMP_Text bgmValue;
    [SerializeField] TMP_Text sfxValue;

    // Start is called before the first frame update
    private void Start()
    {
        var dbBGM = PlayerPrefs.GetFloat("BGMVolume", 0);
        var volBGM = DBToVolValue(dbBGM);
        mixer.SetFloat("BGMVolume", dbBGM);
        bgmValue.text = (volBGM * 100).ToString("F0");
        bgmSlider.SetValueWithoutNotify(volBGM);

        var dbSFX = PlayerPrefs.GetFloat("SFXVolume", 0);
        var volSFX = DBToVolValue(dbSFX);
        mixer.SetFloat("SFXVolume", dbSFX);
        sfxValue.text = (volSFX * 100).ToString("F0");
        sfxSlider.SetValueWithoutNotify(volSFX);
    }

    private void OnEnable()
    {
        bgmSlider.onValueChanged.AddListener(SetBgmVol);
        sfxSlider.onValueChanged.AddListener(SetSfxVol);
    }

    private void OnDisable()
    {
        bgmSlider.onValueChanged.RemoveListener(SetBgmVol);
        sfxSlider.onValueChanged.RemoveListener(SetSfxVol);
    }

    private void SetBgmVol(float vol)
    {
        var db = VolToDBValue(vol);
        mixer.SetFloat("BGMVolume", db);
        bgmValue.text = (vol * 100).ToString("F0");
        PlayerPrefs.SetFloat("BGMVolume", db);
        PlayerPrefs.Save();
    }

    private void SetSfxVol(float vol)
    {
        var db = VolToDBValue(vol);
        mixer.SetFloat("SFXVolume", db);
        sfxValue.text = (vol * 100).ToString("F0");
        PlayerPrefs.SetFloat("SFXVolume", db);
        PlayerPrefs.Save();
    }

    private float DBToVolValue(float db)
    {
        return Mathf.Pow(10, db / 20);
    }

    private float VolToDBValue(float vol)
    {
        if (vol == 0)
        {
            return -80;
        }
        return 20 * Mathf.Log10((float)vol);
    }
}
