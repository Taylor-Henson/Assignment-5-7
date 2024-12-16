using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DummyGame : MonoBehaviour
{
    public TextMeshProUGUI difficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("FrontEnd");
        }

        difficulty.text = "Difficulty: " + LevelManager.instance.difficulty;
    }
}
