using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public static bool GameIsPaused = true;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject inGameUI;
    public ControllerMain playerController;

    private void Start()
    {
        Paused();
        playerController= GameObject.Find("NumberBox").GetComponent<ControllerMain>();

        inGameUI.SetActive(false);
        gameOverUI.SetActive(false);
        pauseMenuUI.SetActive(true);

    }
    void Update()
    {
        CheckPaused();
        CheckDeath();

    }

    private void CheckPaused()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void ReTry()
    {
        SceneManager.LoadScene("GameRun");
    }

    private void CheckDeath()
    {
        if (playerController.playerIsDeath)
        {
            inGameUI.SetActive(false);
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
