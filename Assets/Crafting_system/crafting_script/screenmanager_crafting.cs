using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screenmanager_crafting : MonoBehaviour
{
    public static bool GameIsPaused = true;
    public GameObject gameOverUI;
    public GameObject inGameUI;
    public GameObject selectQIUI;
    public SliderPynya sliderPynya;

   
    void Start()
    {
        Paused();
        sliderPynya = GameObject.Find("EventSystem").GetComponent<SliderPynya>();
        selectQIUI.SetActive(true);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(false);

    }
    void Update()
    {
        CheckGameOver();
    }

    public void Paused()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void ReTry()
    {
        SceneManager.LoadScene("crafting");
    }

    private void CheckGameOver()
    {
        if (sliderPynya.gameIsOver)
        {
            inGameUI.SetActive(false);
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void StartButtonOnclick()
    {
        sliderPynya.SetCraftedItemQIToSpeed();
        selectQIUI.SetActive(false);
        inGameUI.SetActive(true);
        Resume();

    }
}
