using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Toggles : MonoBehaviour
{
    public Toggle myToggle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick()
    {
        if (myToggle.isOn == true)
        {
            LevelManager.instance.MusicOn();
        }
        else
        {
            LevelManager.instance.MusicOff();
        }
    }
}
