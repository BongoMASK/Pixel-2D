using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public static GameObject Canvas;

    public GameObject pauseCanvas, optionCanvas, deathsText, dataLostText;

    int dataInit, dataCurrent;

    Text death, dataLost;

    void Start() {
        Canvas = pauseCanvas;
        dataInit = GameManager.data;

        if (deathsText != null) {
            death = deathsText.GetComponent<Text>();
        }

        if (dataLostText != null) {
            dataLost = dataLostText.GetComponent<Text>();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused) {
                GameResume();
            }
            else {
                GamePause();
            }
        }

        DeathCount();
        DataLostCount();
    }

    void DataLostCount() {
        if (dataLostText != null) {
            dataLost.text = (Movement.dataFinal - dataInit).ToString();
        }
    }

    public void DeathCount() {
        if (deathsText != null) {
            death.text = GameManager.deaths.ToString();
        }
    }

    public void GameResume() {
        optionCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        GameManager.canvas.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GamePause() {
        optionCanvas.SetActive(false);
        pauseCanvas.SetActive(true); 
        
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void RestartGame() {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
    }

    public void Quit() {
        Application.Quit();
    }

    public void MainMenu() {
        SceneManager.LoadScene("Start");
    }

    public void Options() {
        optionCanvas.SetActive(true);
        pauseCanvas.SetActive(false);

        Time.timeScale = 0f;
        isPaused = true;
    }
}
