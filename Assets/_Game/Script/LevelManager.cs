using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    public static LevelManager instance;
    public Button myButton;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public enum SceneName
    {
        Level_1 = 0,
        Level_2 = 1,
        Level_3 = 2,
        Level_4 = 3,
        Level_5 = 4,

    }
    public SceneName scene;

    private void Start()
    {
        scene = SceneName.Level_1;
        //myButton.onClick.AddListener(ExitGame);

    }
    public void NextLevel()
    {
        scene = (SceneName)(((int)scene) + 1);

        if (SceneManager.GetSceneByName(scene.ToString()) != null)
        {
            SceneManager.LoadScene(scene.ToString());
        }
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void ExitGame()
    {
        Debug.Log("Thoat game");
        Application.Quit();
    }
}
