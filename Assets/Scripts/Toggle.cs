using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Toggles : MonoBehaviour
{
    public Toggle myToggle;
    int integer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("toggle")) //checks for key
        {
            integer = PlayerPrefs.GetInt("toggle");//sets integer to key
        }
        else
        {
            PlayerPrefs.SetInt("toggle", 1);//else make toggle 1
            integer = PlayerPrefs.GetInt("toggle");//and set integer to toggle
        }

        if (integer == 1)//sets the Toggle ui to on or off
        {
            myToggle.isOn = true;
        }
        else
        {
            myToggle.isOn = false;
        }
        //print(integer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(bool value)//when clicked create dynamic boolean value synced with toggle
    {
        if (value)
        {
            LevelManager.instance.MusicOn();
            integer = 1;
        }
        else
        {
            LevelManager.instance.MusicOff();
            integer = 0;
        }

        PlayerPrefs.SetInt("toggle", integer);
    }
}
