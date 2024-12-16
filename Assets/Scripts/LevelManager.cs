using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //makes it a singleton
    public static LevelManager instance;

    //variables
    public AudioClip[] music;
    public AudioClip[] sfx;
    public float musicVol;
    public float sfxVol;

    AudioSource audioSource;

    public string difficulty = "Easy";

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
    }
    #endregion

    #region audio

    public void PlayMusic(int clipNumber)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(music[clipNumber], musicVol);
    }

    public void PlaySfx(int clipNumber)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sfx[clipNumber], sfxVol);
    }

    public void StopClip()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    #endregion

}
