using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public string GameScene= "RPS";

    public Button playButton;

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        playButton.onClick.AddListener(StartGame);
    }
}
