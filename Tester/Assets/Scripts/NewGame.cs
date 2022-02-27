using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public Button NewGameButton;
    public Button exitButton;

    void Start()
    {
        NewGameButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);

    }

    void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    void ExitGame()
    {
        Application.Quit();
    }


}
