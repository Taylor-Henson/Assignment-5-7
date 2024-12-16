using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    //goes to main menu
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        instructionsMenu.SetActive(false);
        quitMenu.SetActive(false);
    }
    
    //goes to options menu
    public void OptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        difficultyMenu.SetActive(false);
        audioMenu.SetActive(false);
    }

    //goes to difficulty menu
    public void DifficultyMenu()
    {
        optionsMenu.SetActive(false);
        difficultyMenu.SetActive(true);
    }

    //goes to audio menu
    public void AudioMenu()
    {
        optionsMenu.SetActive(false);
        audioMenu.SetActive(true);
    }

    //goes to instructions menu
    public void InstructionsMenu()
    {
        mainMenu.SetActive(false);
        instructionsMenu.SetActive(true);
    }

    //goes to quit menu
    public void QuitMenu()
    {
        mainMenu.SetActive(false);
        quitMenu.SetActive(true);
    }

    //quits application
    public void QuitApplication()
    {
        Application.Quit();
    }

    #endregion

    #region settings

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
    private void Start()
    {

    }
}
