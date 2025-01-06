using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class VolumeSettings : MonoBehaviour
{
    //variables
    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SFX = "SFXVolume";

    //references
    public AudioMixer mixer;
    public Slider sfxSlider;
    public Slider musicSlider;

    private void Awake()
    {
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    private void Start()
    {
        //sets slider values to stored keys, if not 0.5
        musicSlider.value = PlayerPrefs.GetFloat(LevelManager.MUSIC_KEY, 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat(LevelManager.SFX_KEY, 0.5f);
    }

    private void OnDisable()
    {
        //when the scene is unloaded, set playerprefs keys to slider values
        PlayerPrefs.SetFloat(LevelManager.MUSIC_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(LevelManager.SFX_KEY, sfxSlider.value);
    }

    //converts to log10
    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }

    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }
}
