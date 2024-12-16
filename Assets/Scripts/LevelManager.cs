using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //makes the class static 
    public static LevelManager instance;

    //static variables

    #region Singleton
    void Awake()
    {
        //keeps the LevelManager in each scene without duplicating

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
            //
            //print("do destroy");
            Destroy(gameObject);
        }
    }
    #endregion

    #region Buttons

    public void StartButton()
    {
        SceneManager.LoadScene("DummyGame");
    }

    #endregion
    private void Start()
    {

    }
}
