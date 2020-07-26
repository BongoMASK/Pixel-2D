using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private Text difficultyText;
    public GameObject difficultyButton;

    void Awake() {
        if(!Movement.difficult) {
            difficultyText.text = "Hard";
        }
        else {
            difficultyText.text = "Easy";
        }
        difficultyText = difficultyButton.GetComponent<Text>();
    }
    
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Options() {
        SceneManager.LoadScene("Options");
        //Lmaoooo this has been empty since I made this game
        //add volume control, camera shake intensity, music, sounds, difficulty etc.
    }
    public void difficulty() {
        if(Movement.difficult) {
            difficultyText.text = "Easy";
            Movement.difficult = false;
        }
        else {
            difficultyText.text = "Hard";
            Movement.difficult = true;
        }
    }
    public void Quit() {
        Application.Quit();
    }
    public void Restart() {
        SceneManager.LoadScene("Level 1");
    }
    public void Continue() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Level1() {
        SceneManager.LoadScene("Level 1");
    }
    public void Claustrophobia() {
        SceneManager.LoadScene("Claustrophobia");
    }
    public void Maze() {
        SceneManager.LoadScene("Maze");
    }
    public void Survive() {
        SceneManager.LoadScene("Survive");
    }
    public void Glitch() {
        SceneManager.LoadScene("Glitch");
    }
    public void mainMenu() {
        SceneManager.LoadScene("Start");
    }
}
