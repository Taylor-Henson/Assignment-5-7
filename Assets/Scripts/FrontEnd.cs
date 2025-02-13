using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FrontEnd : MonoBehaviour
{    
    #region variables/references

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject instructionsMenu;
    public GameObject quitMenu;
    public GameObject audioMenu;
    public GameObject difficultyMenu;

    public string difficulty = "Easy";

    #endregion

    #region Buttons

    //starts dummy
    public void StartButton()
    {
        SceneManager.LoadScene("DummyGame");
    }

    public void PressButton() // when a button is pressed
    {
        LevelManager.instance.PlaySFX(0);
    }

    public void ChangedSetting()
    {
        LevelManager.instance.PlaySFX(1);
    }

    public void Back()
    {
        LevelManager.instance.PlaySFX(2);
    }

    //goes to main menu
    public void MainMenu()
    {
        PressButton();
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        instructionsMenu.SetActive(false);
        quitMenu.SetActive(false);
    }
    
    //goes to options menu
    public void OptionsMenu()
    {
        PressButton();
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        difficultyMenu.SetActive(false);
        audioMenu.SetActive(false);
    }

    //goes to difficulty menu
    public void DifficultyMenu()
    {
        PressButton();
        optionsMenu.SetActive(false);
        difficultyMenu.SetActive(true);
    }

    //goes to audio menu
    public void AudioMenu()
    {
        PressButton();
        optionsMenu.SetActive(false);
        audioMenu.SetActive(true);
    }

    //goes to instructions menu
    public void InstructionsMenu()
    {
        PressButton();
        mainMenu.SetActive(false);
        instructionsMenu.SetActive(true);
    }

    //goes to quit menu
    public void QuitMenu()
    {
        PressButton();
        mainMenu.SetActive(false);
        quitMenu.SetActive(true);
    }

    //quits application
    public void QuitApplication()
    {
        PressButton();
        Application.Quit();
    }

    #endregion

    #region PlayerPrefs

    //difficulty 
    public void Easy()
    {
        LevelManager.instance.difficulty = "Easy";
    }

    public void Medium()
    {
        LevelManager.instance.difficulty = "Medium";
    }

    public void Hard()
    {
        LevelManager.instance.difficulty = "Hard";
    }

    #endregion

    #region music on/off
    private void Start()
    {
        Invoke("Play", 0.5f);
    }

    private void Play()
    {
        LevelManager.instance.PlayMusic(1); // plays frontend music
    }

    private void OnDisable()
    {
        LevelManager.instance.StopMusic(); // stops frontend music
    }

    #endregion
}
