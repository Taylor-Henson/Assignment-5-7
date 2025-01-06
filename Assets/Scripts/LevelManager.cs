using UnityEngine;
using UnityEngine.Audio;

public class LevelManager : MonoBehaviour
{
    #region Variables and References
    //makes it a singleton
    public static LevelManager instance;

    //variables

    //audioClips
    public AudioClip[] music;
    public AudioClip[] sfx;

    public string difficulty = "Easy";

    //playerprefs volume keys
    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";

    //references
    AudioSource musicSource;
    AudioSource sfxSource;
    public AudioMixer audioMixer;

    #endregion

    #region start and update
    public void Start()
    {
        //playerPrefs

        //difficulty

        if (PlayerPrefs.HasKey("Difficulty") == true)//if there is a playerpref
        {
            difficulty = PlayerPrefs.GetString("Difficulty");//get it
        }
        else
        {
            PlayerPrefs.SetString("Difficulty", "Easy");//set to easy
        }

        //refernces
        musicSource = GameObject.Find("Music").GetComponent<AudioSource>();
        sfxSource = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    public void Update()
    {
        PlayerPrefs.SetString("Difficulty", difficulty);//set playerpref to new state
    }

    #endregion

    #region singleton

    void Awake()
    {
        if (instance == null)
        {
            //store reference to instance
            instance = this;
            DontDestroyOnLoad(gameObject);
            //print("dont destroy");
        }
        else
        {
            //another instance has been made so destroy it
            //print("do destroy");
            Destroy(gameObject);
        }

        LoadVolume(); // loads playerprefs for volume
    }
    #endregion

    #region audio

    //plays audio
    public void PlaySFX(int clipNumber)
    {
        sfxSource.PlayOneShot(sfx[clipNumber]); //play sfx by clip number
    }

    public void PlayMusic(int clipNumber)
    { 
        musicSource.PlayOneShot(music[clipNumber]); //play music by clip number
    }

    //stops audio
    public void StopSFX()
    {
        sfxSource.Stop();
    }

    //stops music
    public void StopMusic()
    {
        musicSource.Stop();
    }

    //mutes music
    public void MusicOff()
    { 
        musicSource.mute = true;
    }

    //unmutes music
    public void MusicOn()
    {
        musicSource.mute = false;
    }

    #endregion

    #region PlayerPrefs

    void LoadVolume() // volume saved in volumeSettings
    {
        //sets volume floats to stored keys, if not to 1
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 0.5f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 0.5f);

        //sets audio mixer values to the previes floats, converted to log10
        audioMixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        audioMixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
    }

    #endregion

}
