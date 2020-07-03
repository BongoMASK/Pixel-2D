using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public static GameObject Canvas;
    public GameObject pauseCanvas;

    void Start() {
        Canvas = pauseCanvas;        
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
    }
    public void GameResume() {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void GamePause() {
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
}
