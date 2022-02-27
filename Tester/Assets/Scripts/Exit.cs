using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Button exitButton;
    public Button RestartButton;
    public Button MainButton;

    void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
        RestartButton.onClick.AddListener(RestartGame);
        MainButton.onClick.AddListener(MainGame);

    }

    void ExitGame()
    {
        Application.Quit();
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    void MainGame()
    {
        SceneManager.LoadScene("NewGame");
    }

}
