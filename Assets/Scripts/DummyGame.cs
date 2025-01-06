using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DummyGame : MonoBehaviour
{
    public TextMeshProUGUI difficulty;
    

    void Start()
    {
        LevelManager.instance.PlayMusic(0);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("FrontEnd");
        }

        difficulty.text = "Difficulty: " + LevelManager.instance.difficulty;
    }
    private void OnDisable()
    {
        LevelManager.instance.StopMusic();
    }
}
